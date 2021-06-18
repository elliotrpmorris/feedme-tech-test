// <copyright file="FeedMeClient.cs" company="SkyBet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FeedMe.RecordParser.Domain
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;

    public class FeedMeClient : IFeedMeClient
    {
        // TODO: We could store this in config like appsettings.json.
        private const string Address = "localhost";
        private const int Port = 8282;

        public TcpClient Client { get; set; }

        public StreamReader StreamReader { get; set; }

        public IRecordParser RecordParser { get; set; }

        public FeedMeClient(IRecordParser recordParser)
        {
            this.RecordParser = recordParser;
            this.Client = new TcpClient(Address, Port);
            this.StreamReader = new StreamReader(this.Client.GetStream());
        }

        public void HandleStream()
        {
            while (true)
            {
                var record = this.StreamReader.ReadLine();
                if (!string.IsNullOrWhiteSpace(record))
                {
                    if (string.IsNullOrWhiteSpace(record))
                    {
                        throw new ArgumentException(nameof(record));
                    }

                    var recordProperties = this.RecordParser.ParseRecord(record);

                    string operation = recordProperties.ElementAtOrDefault(1);
                    string type = recordProperties.ElementAtOrDefault(2).ToLower();

                    object x = type switch
                    {
                        "event" => this.RecordParser.BuildEvent(recordProperties),
                        "market" => this.RecordParser.BuildMarket(recordProperties),
                        "outcome" => this.RecordParser.BuildOutcome(recordProperties),
                        _ => throw new NotImplementedException()
                    };

                    Console.WriteLine(record);
                }

                if (!this.Client.Connected)
                {
                    break;
                }
            }

            Console.WriteLine("Server closed connection.");
        }
    }
}
