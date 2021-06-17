// <copyright file="IRecordParser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FeedMe.Domain
{
    using System.Collections.Generic;

    public interface IRecordParser
    {
        public List<string> ParseRecord(string record);

        public Event BuildEvent(List<string> recordProperties);

        public Market BuildMarket(List<string> recordPropertiesd);

        public Outcome BuildOutcome(List<string> recordProperties);
    }
}
