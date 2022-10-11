using Broker.Models;
using Broker.Services.Interfaces;
using Grpc.Core;
using gRPCAgent;
using System.Threading.Tasks;
using System;

namespace Broker.Services
{
    public class SubscriberService: Subscriber.SubscriberBase
    {
        private readonly IConnectionStorageService _connectionStorage;

        public SubscriberService(IConnectionStorageService connectionStorage)
        {
            _connectionStorage = connectionStorage;
        }

        public override Task<SubscribeReply> Subscribe(SubscribeRequest request, ServerCallContext context)
        {
            Console.WriteLine($"New client subscribed: {request.Address} {request.Topic}");
            try
            {
                var connection = new Connection(request.Address, request.Topic);

                _connectionStorage.Add(connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not add the new connection {request.Address} {request.Topic}");
            }

            return Task.FromResult(new SubscribeReply()
            {
                IsSuccess = true,
            });

        }
    }
}
