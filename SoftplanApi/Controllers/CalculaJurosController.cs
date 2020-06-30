using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftplanCore.ApiBoot;
using Microsoft.AspNetCore.Authorization;
using SoftplanRule;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System;
using System.Net.Http.Headers;

namespace SoftplanApi.Controllers
{
    [ApiVersion("2")]
    public class CalculaJurosController : ApiController
    {
        private readonly ILogger<CalculaJurosController> _logger;

        public CalculaJurosController(ILogger<CalculaJurosController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Rota para calcular valor do juros pela quantidade de meses
        /// </summary>
        /// <param name="valorOriginal">Valor original da dívida</param>
        /// <param name="meses">Quantidade de meses de atraso</param>
        /// <returns>Valor total do juros</returns>
        [HttpPost, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public decimal Post(decimal valorOriginal, int meses)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            TaxaJuros product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;

            return 1.05M;
        }
    }
}
