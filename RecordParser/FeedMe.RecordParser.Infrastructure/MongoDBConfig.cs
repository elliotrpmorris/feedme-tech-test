// <copyright file="MongoDBConfig.cs" company="SkyBet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FeedMe.RecordParser.Infrastructure
{
    public class MongoDBConfig
    {
        // TODO: This would be moved into app settings.
        public string Database { get; set; } = "FeedMe";

        public string Host { get; set; } = "0.0.0.0";

        public int Port { get; set; } = 8081;

        public string User { get; set; } = "admin";

        public string Password { get; set; } = "pass";

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password))
                    return $@"mongodb://{Host}:{Port}";
                return $@"mongodb://{User}:{Password}@{Host}:{Port}";
            }
        }
    }
}
