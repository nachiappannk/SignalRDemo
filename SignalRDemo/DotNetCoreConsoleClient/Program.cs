using System;
using Microsoft.AspNet.SignalR.Client;

namespace DotNetCoreConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HubConnection hub = new HubConnection("http://localhost:64277");
            IHubProxy proxy = hub.CreateHubProxy("TimeQuery");

            proxy.On("addMessage", message =>
            {
                Console.WriteLine(message);
            });

            hub.Start().Wait();
            proxy.Invoke("StartTimer");

            string line = null;
            while ((line = Console.ReadLine()) != null)
            {
            }
        }
    }
}
