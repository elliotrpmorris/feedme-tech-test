// <copyright file="Event.cs" company="SkyBet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;

namespace FeedMe.RecordParser.Domain.Data
{
    /// <summary>
    /// Event object.
    /// </summary>
    public class Event : Header
    {
        public Event(
            int msgId,
            string operation,
            string type,
            long timestamp,
            string eventId,
            string category,
            string subCategory,
            string name,
            int startTime,
            bool displayed,
            bool suspended)
            : base(msgId, operation, type, timestamp)
        {
            if (string.IsNullOrWhiteSpace(eventId))
            {
                throw new ArgumentException(nameof(eventId));
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException(nameof(category));
            }

            if (string.IsNullOrWhiteSpace(subCategory))
            {
                throw new ArgumentException(nameof(subCategory));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            if (startTime < 0)
            {
                throw new ArgumentException(nameof(startTime));
            }

            this.EventId = eventId;
            this.Category = category;
            this.SubCategory = subCategory;
            this.Name = name;
            this.StartTime = startTime;
            this.Displayed = displayed;
            this.Suspended = suspended;
        }

        public string EventId { get; set; }

        public string Category { get; set; }

        public string SubCategory { get; set; }

        public string Name { get; set; }

        public int StartTime { get; set; }

        public bool Displayed { get; set; }

        public bool Suspended { get; set; }
    }
}