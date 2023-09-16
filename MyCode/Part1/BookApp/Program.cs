﻿// Copyright (c) 2020 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System.Threading.Tasks;
using BookApp.HelperExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using ServiceLayer.BackgroundServices;

namespace BookApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.Seq("http://localhost:5341"))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();
        var host = CreateHostBuilder(args).Build();
        //This migrates the database and adds any seed data as required
        await host.SetupDatabaseAsync();
        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog()
            //see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-3.1#add-providers
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders(); //Clear logging providers to improve performance
            })
            .ConfigureServices(services =>
            {
                services.AddHostedService<BackgroundServiceCountReviews>();
            })
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}