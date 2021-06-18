// <copyright file="Program.cs" company="SkyBet">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FeedMe.RecordParser.Console
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using FeedMe.RecordParser.Domain;
    using FeedMe.RecordParser.Infrastructure;
    using FeedMe.RecordParser.Infrastructure.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        static async Task Main(string[] args)
        {
            // TODO: We can move this to a service register class.
            var services = new ServiceCollection()
                .AddSingleton<IFeedMeClient, FeedMeClient>()
                .AddScoped<IRecordParser, RecordParser>()
                .BuildServiceProvider();

            var feedMeClient = services.GetService<IFeedMeClient>();

            var feedMeContext = new FeedMeContext(new MongoDBConfig());

            feedMeClient.HandleStream();

            if (services is IDisposable disposable)
            {
                disposable.Dispose();
            }

            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json");

            //var configuration = builder.Build();
        }
    }
}
