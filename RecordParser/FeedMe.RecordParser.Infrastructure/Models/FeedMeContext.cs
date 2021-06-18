// <copyright file="FeedMeContext.cs" company="SkyBet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FeedMe.RecordParser.Infrastructure.Models
{
    using MongoDB.Driver;

    public class FeedMeContext : IFeedMeContext
    {
        private readonly IMongoDatabase db;

        public FeedMeContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<EventDocument> Events =>
            db.GetCollection<EventDocument>("Events");

        public IMongoCollection<EventDocument> Event { get; }
    }
}
