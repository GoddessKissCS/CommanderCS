﻿using MongoDB.Driver;
using CommanderCS.Database.Schemes;

namespace CommanderCS.Database.Handlers
{
    public class DatabaseGameTableVersion : DatabaseTable<DatabaseVersionScheme>
    {
        public DatabaseGameTableVersion() : base("GameTableVersion")
        {
        }

        public DatabaseVersionScheme Insert(double version)
        {
            DatabaseVersionScheme dataInfo = new()
            {
                Version = version
            };

            DatabaseCollection.InsertOne(dataInfo);

            return dataInfo;
        }

        public DatabaseVersionScheme Get()
        {
            return DatabaseCollection.AsQueryable().FirstOrDefault();
        }
    }
}