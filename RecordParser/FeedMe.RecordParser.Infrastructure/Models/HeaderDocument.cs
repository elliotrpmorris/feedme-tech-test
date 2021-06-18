// <copyright file="HeaderDocument.cs" company="SkyBet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;

namespace FeedMe.RecordParser.Infrastructure.Models
{
    public class HeaderDocument
    {
        public HeaderDocument(
            int msgId,
            string operation,
            string type,
            long timestamp)
        {
            if (msgId < 0)
            {
                throw new ArgumentException(nameof(msgId));
            }

            if (string.IsNullOrWhiteSpace(operation))
            {
                throw new ArgumentException(nameof(operation));
            }

            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException(nameof(type));
            }

            if (timestamp < 0)
            {
                throw new ArgumentException(nameof(timestamp));
            }

            this.MsgId = msgId;
            this.Operation = operation;
            this.Type = type;
            this.Timestamp = timestamp;
        }

        public int MsgId { get; set; }

        public string Operation { get; set; }

        public long Timestamp { get; }

        public string Type { get; set; }
    }
}