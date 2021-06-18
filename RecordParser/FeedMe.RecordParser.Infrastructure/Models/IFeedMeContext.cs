// <copyright file="IFeedMeContext.cs" company="SkyBet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FeedMe.RecordParser.Infrastructure.Models
{
    using MongoDB.Driver;

    public interface IFeedMeContext
    {
        IMongoCollection<EventDocument> Event { get; }
    }
}
