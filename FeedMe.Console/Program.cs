// <copyright file="Program.cs" company="SkyBet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FeedMe.Console
{
    using System;
    using FeedMe.Domain;
    using Microsoft.Extensions.DependencyInjection;

    class Program
    {
        static void Main(string[] args)
        {
            // TODO: We can move this to a service register class.
            var services = new ServiceCollection()
                .AddSingleton<IFeedMeClient, FeedMeClient>()
                .AddScoped<IRecordParser, RecordParser>()
                .BuildServiceProvider();

            var feedMeClient = services.GetService<IFeedMeClient>();

            feedMeClient.HandleStream();

            if (services is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
