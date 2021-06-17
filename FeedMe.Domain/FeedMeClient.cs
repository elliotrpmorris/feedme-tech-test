// <copyright file="Client.cs" company="SkyBet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;

namespace FeedMe.Domain
{
    using System;
    using System.IO;
    using System.Net.Sockets;

    public class FeedMeClient
    {
        // TODO: We could store this in config like appsettings.json.
        private const string Address = "localhost";
        private const int Port = 8282;

        public TcpClient Client { get; set; }

        public StreamReader StreamReader { get; set; }

        public FeedMeClient()
        {
            this.Client = new TcpClient(Address, Port);
            this.StreamReader = new StreamReader(this.Client.GetStream());
        }

        public void ReceiveStream()
        {
            char[] charArray = new char[100];

            while (true)
            {
                var readByteCount = this.StreamReader.Read(charArray, 0, charArray.Length);
                if (readByteCount > 0)
                {
                    var data = new string(charArray, 0, readByteCount);
                    Console.WriteLine(data + " + data");
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
