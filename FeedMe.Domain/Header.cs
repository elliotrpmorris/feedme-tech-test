﻿// <copyright file="Header.cs" company="SkyBet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FeedMe.Domain
{
    using System;

    /// <summary>
    /// Header Object for the types.
    /// </summary>
    public class Header
    {
        public Header(
            int msgId,
            string operation,
            string type,
            int timestamp)
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

        public int Timestamp { get; }

        public string Type { get; set; }
    }
}