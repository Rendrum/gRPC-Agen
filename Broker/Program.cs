using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Common;
using System;

namespace Broker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(EndpointsConstants.BrokerAddress)
                .Build()
                .Run();
        }

        
    }
}
