// <copyright file="Market.cs" company="SkyBet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;

namespace FeedMe.RecordParser.Domain.Data
{
    /// <summary>
    /// Market object.
    /// </summary>
    public class Market : Header
    {
        public Market(
            int msgId,
            string operation,
            string type,
            long timestamp,
            string eventId,
            string marketId,
            string name,
            bool displayed,
            bool suspended)
            : base(msgId, operation, type, timestamp)
        {
            if (string.IsNullOrWhiteSpace(eventId))
            {
                throw new ArgumentException(nameof(eventId));
            }

            if (string.IsNullOrWhiteSpace(marketId))
            {
                throw new ArgumentException(nameof(marketId));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            this.EventId = eventId;
            this.MarketId = marketId;
            this.Name = name;
            this.Displayed = displayed;
            this.Suspended = suspended;
        }

        public string EventId { get; set; }

        public string MarketId { get; set; }

        public string Name { get; set; }

        public bool Displayed { get; set; }

        public bool Suspended { get; set; }
    }
}
