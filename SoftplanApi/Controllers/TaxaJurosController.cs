using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftplanCore.ApiBoot;
using SoftplanRule;

namespace SoftplanApi.Controllers
{
    [ApiVersion("1")]
    public class TaxaJurosController : ApiController
    {
        private readonly ILogger<TaxaJurosController> _logger;

        public TaxaJurosController(ILogger<TaxaJurosController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retorna o valor da taxa de juros
        /// </summary>
        /// <returns>Objeto com o valor da taxa de juros</returns>
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public TaxaJuros Get()
        {
            IJuros juros = new Juros();

            var taxaJuros = new TaxaJuros()
            {
                TaxaJurosDecimal = juros.ValorTaxaJuros() / 100,
                TaxaJurosPercentagem = juros.ValorTaxaJuros()
            };

            return taxaJuros;
        }
    }
}
