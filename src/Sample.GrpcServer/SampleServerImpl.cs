using SampleProtos;
using Grpc.Core;
using System.Threading.Tasks;
using System;

namespace SampleServer
{
    public class SampleServiceImpl : GreetingService.GreetingServiceBase
    {
        public override Task<SampleResponse> Greeting(SampleRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Message: {request.SampleText}");
            return Task.FromResult(new SampleResponse { SampleText = request.SampleText });
        }
    }
}
