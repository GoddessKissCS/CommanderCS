# CommanderCS
some gacha game emu


## Status
"Urgent" to-dos

### Bugs

Getting kicked out of a guild while the game still thinks you are in one will make unable to continue playing (needs to restart the game) (client-sided issue)


### IMPORTANT

This is just a POC and its in WIP while it works somewhat it does has very limited usage and not everything works to 100% like its intend.



### How-To-Use

[Mongodb community database](https://www.mongodb.com/try/download/community)

Its for the database you pratically install it via all the pre selected settings iirc.

[Modified Client APK](https://www.mediafire.com/file/gp6x6c2gweggndh/com.edited.GK.apk/file)

it is the lastest Version GK had just modified so i can easier create this POC, if you have any trust issues with it, you can look at it via tools like dnSpy.

[Game OBB Data](https://www.mediafire.com/file/8cnyb7btjwk9qk0/com.flerogames.GK.rar/file)

This is just the games obb data works with any obb data for the lastest version.

[The ServerSides Files](https://www.mediafire.com/file/v03gsv3tfevkg12/FileCDN.rar/file)

These are just all server sides files you have to download so the game can be used.
 

### Setup

Download all these files above (may change in the future), install the mongodb community database, install the apk to your device or emulator (whatever you prefer), put the OBB file after unpacking it to its path, should be straightforward.

Download this Project from releases or build it yourself (needs net8.0).

Put the FileCDN content into the FileCDN folder.

When you run the game for the first time it will not directly connect your server since it doesnt know the ip of it, however thats very easy to change as it should create a file called config.json in your Pictures folder on your device, locate the pre-input ip and replace it with your ip wherever your server is running.


## Credit

[Inso](https://github.com/insomnyawolf) For essenitaly creating this entire Project Rework +  helping me with more stuff.
