﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StreamLabsDotNet.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace StreamLabsDotNet.Test.Console
{
    class Program
    {

        public static void Main(string[] args)
     => new Program().MainAsync().GetAwaiter().GetResult();

        private static Mutex mutex = new Mutex(true, "{886D4E8D-0962-4174-85FC-FA36C0FFCB6D}");
        private Client.StreamlabsClient _client;
        public async Task MainAsync()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                var socketToken = "{{SocketToken}}";

                var serviceCollection = new ServiceCollection()
               .AddLogging()
               .AddSingleton<StreamlabsClient>();
                
                var serviceProvider = serviceCollection.BuildServiceProvider();

                serviceProvider
                    .GetService<ILoggerFactory>()
                    .AddConsole();

                _client = serviceProvider.GetService<StreamlabsClient>();
                _client.OnConnected += _client_OnConnected;
                _client.OnDisconnected += _client_OnDisconnected;
                _client.Connect(socketToken);

            }

            while (true)
            {
                Thread.Sleep(TimeSpan.FromDays(1));
            }
        }

        private void _client_OnDisconnected(object sender, bool e)
        {
        }

        private void _client_OnConnected(object sender, bool e)
        {
        }
    }
}