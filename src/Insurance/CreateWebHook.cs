using FluffySpoon.AspNet.NGrok;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trinsic.ServiceClients;
using Trinsic.ServiceClients.Models;

namespace Insurance
{
    internal class CreateWebHook : IHostedService
    {
        public CreateWebHook(INGrokHostedService nGrokHostedService, ICredentialsServiceClient credentialsServiceClient)
        {
            NGrokHostedService = nGrokHostedService;
            CredentialsServiceClient = credentialsServiceClient;
        }

        public INGrokHostedService NGrokHostedService { get; }
        public ICredentialsServiceClient CredentialsServiceClient { get; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Create a webhoook

        }


        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}