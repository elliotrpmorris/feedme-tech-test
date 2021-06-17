// <copyright file="RecordParser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FeedMe.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Parses records.
    /// </summary>
    public class RecordParser : IRecordParser
    {
        /// <summary>
        /// Gets the record properties from a record.
        /// </summary>
        /// <param name="record">The record.</param>
        /// <returns>The list of record properties as strings.</returns>
        public List<string> ParseRecord(string record)
        {
             var values = new List<string>();

            // Ignore first pipe.
             var position = 1;
             while (position < record.Length)
             {
                // Get packet start.
                var start = position;

                // Get packet end.
                position = record.IndexOf('|', position);

                while (position > 0 && record[position - 1] == '\\')
                {
                    position++;
                    position = record.IndexOf('|', position);
                }

                // Adjust for pipe not found.
                if (position < 0)
                {
                    position = record.Length;
                }

                // Extract this packet.
                values.Add(record.Substring(start, position - start));

                // Skip over pipe.
                if (position < record.Length)
                {
                    position++;
                }
            }

             return values;
        }

        public Event BuildEvent(List<string> eventToBuild)
        {
            return new Event(
                int.Parse(eventToBuild.ElementAtOrDefault(0)),
                eventToBuild.ElementAtOrDefault(1),
                eventToBuild.ElementAtOrDefault(2),
                int.Parse(eventToBuild.ElementAtOrDefault(3)),
                eventToBuild.ElementAtOrDefault(4),
                eventToBuild.ElementAtOrDefault(5),
                eventToBuild.ElementAtOrDefault(6),
                eventToBuild.ElementAtOrDefault(7),
                int.Parse(eventToBuild.ElementAtOrDefault(8)),
                Convert.ToBoolean(
                    Convert.ToInt16(eventToBuild.ElementAtOrDefault(9))),
                Convert.ToBoolean(
                    Convert.ToInt16(eventToBuild.ElementAtOrDefault(10))));
        }

        public Market BuildMarket(List<string> marketToBuild)
        {
            return new Market(
                int.Parse(marketToBuild.ElementAtOrDefault(0)),
                marketToBuild.ElementAtOrDefault(1),
                marketToBuild.ElementAtOrDefault(2),
                int.Parse(marketToBuild.ElementAtOrDefault(3)),
                marketToBuild.ElementAtOrDefault(4),
                marketToBuild.ElementAtOrDefault(5),
                marketToBuild.ElementAtOrDefault(6),
                Convert.ToBoolean(
                    Convert.ToInt16(marketToBuild.ElementAtOrDefault(7))),
                Convert.ToBoolean(
                    Convert.ToInt16(marketToBuild.ElementAtOrDefault(8))));
        }

        public Outcome BuildOutcome(List<string> outcomeToBuild)
        {
            return new Outcome(
                int.Parse(outcomeToBuild.ElementAtOrDefault(0)),
                outcomeToBuild.ElementAtOrDefault(1),
                outcomeToBuild.ElementAtOrDefault(2),
                long.Parse(outcomeToBuild.ElementAtOrDefault(3)),
                outcomeToBuild.ElementAtOrDefault(4),
                outcomeToBuild.ElementAtOrDefault(5),
                outcomeToBuild.ElementAtOrDefault(6),
                outcomeToBuild.ElementAtOrDefault(7),
                Convert.ToBoolean(
                    Convert.ToInt16(outcomeToBuild.ElementAtOrDefault(8))),
                Convert.ToBoolean(
                    Convert.ToInt16(outcomeToBuild.ElementAtOrDefault(9))));
        }
    }
}
