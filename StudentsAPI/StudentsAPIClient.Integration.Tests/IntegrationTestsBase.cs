using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace StudentsAPIClient.Integration.Tests
{
    public class IntegrationTestsBase: IClassFixture<WebApplicationFactory<Startup>>
    {
        WebApplicationFactory<Startup> factory;
        protected readonly HttpClient client ;

        public IntegrationTestsBase(WebApplicationFactory<Startup> factory)
        {
            this.client = factory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:44363/");
            client.DefaultRequestHeaders.Add("api-version", "2.0");
            client.DefaultRequestHeaders.Add("x-api-key", "123456");
            this.factory = factory;
        }

    }
}
