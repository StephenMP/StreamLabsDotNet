using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace StreamLabsDotNet.Test.Console
{
    class Program
    {

        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        private static Mutex mutex = new Mutex(true, "{886D4E8D-0962-4174-85FC-FA36C0FFCB6D}");
        private Client.Client _client;
        public async Task MainAsync()
        {
            await Task.CompletedTask;

            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                var socketToken = "{{SocketToken}}";

                var serviceCollection = new ServiceCollection()
               .AddLogging()
               .AddSingleton<Client.Client>();

                var serviceProvider = serviceCollection.BuildServiceProvider();

                serviceProvider
                    .GetService<ILoggerFactory>()
                    .AddConsole();

                _client = serviceProvider.GetService<Client.Client>();
                _client.OnConnected += _client_OnConnected;
                _client.OnDisconnected += _client_OnDisconnected;
                _client.Connect(socketToken);

            }

            System.Console.ReadLine();
        }

        private void _client_OnDisconnected(object sender, bool e)
        {
        }

        private void _client_OnConnected(object sender, bool e)
        {
        }
    }
}
