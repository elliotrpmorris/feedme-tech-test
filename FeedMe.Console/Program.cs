// <copyright file="Program.cs" company="SkyBet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FeedMe.Console
{
    using System.IO;
    using System.Net.Sockets;
    using FeedMe.Domain;

    class Program
    {
        static void Main(string[] args)
        {
            var feedMeClient = new FeedMeClient();
            feedMeClient.ReceiveStream();
        }
    }
}
