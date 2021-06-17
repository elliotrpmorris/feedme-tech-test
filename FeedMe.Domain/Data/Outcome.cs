// <copyright file="Outcome.cs" company="SkyBet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FeedMe.Domain
{
    using System;

    /// <summary>
    /// Outcome object.
    /// </summary>
    public class Outcome : Header
    {
        public Outcome(
            int msgId,
            string operation,
            string type,
            int timestamp,
            string marketId,
            string outcomeId,
            string name,
            string price,
            bool displayed,
            bool suspended)
            : base(msgId, operation, type, timestamp)
        {
            if (string.IsNullOrWhiteSpace(marketId))
            {
                throw new ArgumentException(nameof(marketId));
            }

            if (string.IsNullOrWhiteSpace(outcomeId))
            {
                throw new ArgumentException(nameof(outcomeId));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(price))
            {
                throw new ArgumentException(nameof(price));
            }

            this.MarketId = marketId;
            this.OutcomeId = outcomeId;
            this.Name = name;
            this.Price = price;
            this.Displayed = displayed;
            this.Suspended = suspended;
        }

        public string MarketId { get; set; }

        public string OutcomeId { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public bool Displayed { get; set; }

        public bool Suspended { get; set; }
    }
}
