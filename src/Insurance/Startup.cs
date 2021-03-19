using FluffySpoon.AspNet.NGrok;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Trinsic.ServiceClients;
using Trinsic.ServiceClients.Models;

namespace Insurance
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTrinsicClient(options =>
            {
                // For CredentialsClient and WalletClient
                options.AccessToken = Configuration["Trinsic:ApiKey"];
                // For ProviderClient
                // options.ProviderKey = providerKey;
            });

            // ngronk is required so that we can receive webhooks
            if (Environment.IsDevelopment())
            {
                services.AddNGrok();
            }

            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseNGrokAutomaticUrlDetection();

                var ngrokservice = app.ApplicationServices.GetService<INGrokHostedService>();
                ngrokservice.Ready += async obj => {
                    var credentialsServiceClient = app.ApplicationServices.GetService<ICredentialsServiceClient>();
                    var webhookContract = await credentialsServiceClient.CreateWebhookAsync(new WebhookParameters
                    {
                        Url = obj.First().PublicUrl,
                        Type = "Notification"
                    });
                };
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
