const express = require('express');
const http = require('http');
const { Server } = require('socket.io');
const path = require('path');

const app = express();
const server = http.createServer(app);

// Configure Socket.IO with specific IP
const io = new Server(server, {
  path: '/chat/', // This is the important part for the path
  transports: ['polling', 'websocket'], // explicit transport order
  cors: {
    origin: "*", // Adjust this for production
    methods: ["GET", "POST"]
  }
});

const config = {
    messageLimit: 500,
    sendLimit: 3,
    sendResetDelay: 5 // seconds
  };
  
  // Server state
  const users = new Map(); // key: uno, value: socket.id
  const channels = new Map(); // key: channelName, value: Set of socket.ids
  const userChannels = new Map(); // key: socket.id, value: Set of channels
  const messageQueues = new Map(); // key: channelName, value: Array of messages
  
  // Helper functions
  function getNamespaceFromChannel(channelName) {
    const parts = channelName.split('_');
    return parts.slice(0, 3).join('_');
  }
  
  function validateChannelName(channelName) {
    // Implement validation logic matching client's GetServerChannelName
    return typeof channelName === 'string' && channelName.length > 0;
  }
  
  // Socket.IO connection handler
  io.on('connection', (socket) => {
    console.log(`New connection: ${socket.id}`);
  
    // Store user's channels
    userChannels.set(socket.id, new Set());
  
    // Handle login
    socket.on('login', (uno) => {
      if (!uno) {
        socket.emit('err', { code: 400, message: 'Invalid user ID' });
        return;
      }
      
      users.set(uno, socket.id);
      console.log(`User ${uno} logged in`);
    });
  
    // Handle joining channels
    socket.on('join', (channelNames, ack) => {
      if (!Array.isArray(channelNames)) {
        channelNames = [channelNames];
      }
  
      const joinedChannels = [];
      
      channelNames.forEach(channelName => {
        if (!validateChannelName(channelName)) {
          console.log(`Invalid channel name: ${channelName}`);
          return;
        }
  
        // Initialize channel if not exists
        if (!channels.has(channelName)) {
          channels.set(channelName, new Set());
          messageQueues.set(channelName, []);
        }
  
        // Add user to channel
        channels.get(channelName).add(socket.id);
        userChannels.get(socket.id).add(channelName);
        joinedChannels.push(channelName);
  
        console.log(`Socket ${socket.id} joined channel ${channelName}`);
      });
  
      // Send acknowledgment with joined channels
      if (typeof ack === 'function') {
        ack(joinedChannels);
      }
    });
  
    // Handle leaving channels
    socket.on('leave', (channelNames, ack) => {
      if (!Array.isArray(channelNames)) {
        channelNames = [channelNames];
      }
  
      const leftChannels = [];
      
      channelNames.forEach(channelName => {
        if (!validateChannelName(channelName)) {
          return;
        }
  
        if (channels.has(channelName)) {
          channels.get(channelName).delete(socket.id);
          userChannels.get(socket.id).delete(channelName);
          leftChannels.push(channelName);
  
          console.log(`Socket ${socket.id} left channel ${channelName}`);
        }
      });
  
      // Send acknowledgment with left channels
      if (typeof ack === 'function') {
        ack(leftChannels);
      }
    });
  
    // Handle chat messages
    socket.on('message', (channelName, message) => {
      if (!validateChannelName(channelName) || !message) {
        socket.emit('err', { code: 400, message: 'Invalid channel or message' });
        return;
      }
  
      // Check if user is in the channel
      if (!userChannels.get(socket.id)?.has(channelName)) {
        socket.emit('err', { code: 403, message: 'Not in channel' });
        return;
      }
  
      // Rate limiting would be implemented here (matching client's sendLimit logic)
  
      // Broadcast message to channel
      const messageData = {
        channel: channelName,
        msg: message,
        timestamp: new Date().toISOString()
      };
  
      // Store message in queue (for history)
      const queue = messageQueues.get(channelName);
      queue.push(messageData);
      if (queue.length > config.messageLimit) {
        queue.shift();
      }
  
      // Broadcast to channel members
      io.to(Array.from(channels.get(channelName))).emit('broadcast', messageData);
      console.log(`Message on ${channelName}: ${message}`);
    });
  
    // Handle disconnection
    socket.on('disconnect', () => {
      console.log(`Socket disconnected: ${socket.id}`);
  
      // Leave all channels
      const userChannelSet = userChannels.get(socket.id);
      if (userChannelSet) {
        userChannelSet.forEach(channelName => {
          channels.get(channelName)?.delete(socket.id);
        });
      }
  
      // Clean up user data
      userChannels.delete(socket.id);
      for (let [uno, sid] of users) {
        if (sid === socket.id) {
          users.delete(uno);
          break;
        }
      }
    });
  
    // Force disconnect (admin command)
    socket.on('forceDisconnect', (uno) => {
      // Implement admin logic to force disconnect users
      const targetSocketId = users.get(uno);
      if (targetSocketId) {
        io.to(targetSocketId).emit('forceDisconnect', { reason: 'Admin action' });
      }
    });
  });
  
  server.on('upgrade', (req, socket, head) => {

    console.log(head.Date);
  });
  
const PORT = 3000;
const HOST = '192.168.0.89';
server.listen(PORT, '192.168.0.89', () => {
  console.log(`Server running at http://${HOST}:${PORT}/chat/`);
  });