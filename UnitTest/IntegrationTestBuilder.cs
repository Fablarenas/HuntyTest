using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace UnitTest
{
    public abstract class IntegrationTestBuilder : IDisposable
    {
        protected HttpClient? TestClient;
        private bool Disposed;

        protected IntegrationTestBuilder()
        {
            BootstrapTestingSuite();
        }

        protected void BootstrapTestingSuite()
        {
            Disposed = false;
            var environmentName = "develop";
            var appFactory = new WebApplicationFactory<ChatIntegrationsHunty.Api.Program> ()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureAppConfiguration((context, config) =>
                    {
                    });
                });

            TestClient = appFactory.CreateClient();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                TestClient.Dispose();
            }

            Disposed = true;
        }
    }
}
