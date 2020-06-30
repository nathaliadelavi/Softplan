using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SoftplanCore.ApiBoot;
using SoftplanRule;
using System;
using System.Net.Http;
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
        public double Post(double valorOriginal, int meses)
        {
            var taxaJuros = new TaxaJuros();

            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync($"http://{HttpContext.Request.Host.Value}/api1/taxaJuros").Result)
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException("Não foi possível obter a Taxa de Juros.");
                    }

                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    taxaJuros = JsonConvert.DeserializeObject<TaxaJuros>(apiResponse);
                }
            }
            
            return new Juros().CalcularJuros(valorOriginal, meses, taxaJuros.TaxaJurosDecimal);
        }
    }
}