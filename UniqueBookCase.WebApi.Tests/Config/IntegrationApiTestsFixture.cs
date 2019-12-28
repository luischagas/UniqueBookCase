using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Mvc.Testing;
using UniqueBookCase.Api;
using UniqueBookCase.Api.ViewModels;
using Xunit;

namespace UniqueBookCase.WebApi.Tests.Config
{

    [CollectionDefinition(nameof(IntegrationApiTestsFixtureCollection))]
    public class IntegrationApiTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<Startup>> { }

    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public string UserEmail;
        public string UserPassword;

        public string UserToken;

        public readonly UniqueBookCaseApiFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true,
                BaseAddress = new Uri("http://localhost"),
                HandleCookies = true,
                MaxAutomaticRedirections = 7
            };

            Factory = new UniqueBookCaseApiFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }

        public async Task LoginApi()
        {
            var userData = new LoginUserViewModel
            {
                Email = "lfchagas1@gmail.com",
                Password = "Teste@123"
            };

            Client = Factory.CreateClient();

            var response = await Client.PostAsJsonAsync("api/account/login", userData);
            response.EnsureSuccessStatusCode();
            UserToken = await response.Content.ReadAsStringAsync();
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
