using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SoftplanApi;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SoftplanXUnitTest
{
    public class SoftplanApi_IntegrationTests
    {
        private readonly HttpClient _client;

        public SoftplanApi_IntegrationTests()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET")]
        public async Task TaxaJurosAsync(string method)
        {
            // arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api1/taxaJuros");

            // act
            var response = await _client.SendAsync(request);

            // assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("POST", 100, 5)]
        public async Task CalcularJurosAsync(string method, double valorOriginal, int meses)
        {
            // arrange
            var request = new HttpRequestMessage(new HttpMethod(method), 
                $"/api2/CalculaJuros?valorOriginal={valorOriginal}&meses={meses}");

            // act
            var response = await _client.SendAsync(request);

            // assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("GET")]
        public async Task ShowMeTheCodeAsync(string method)
        {
            // arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api2/showMeTheCode");

            // act
            var response = await _client.SendAsync(request);

            // assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
