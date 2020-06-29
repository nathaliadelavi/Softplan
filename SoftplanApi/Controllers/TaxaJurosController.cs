using Microsoft.AspNetCore.Authorization;
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

        [HttpGet, AllowAnonymous]
        [ProducesResponseType(typeof(string), 200)]
        //[ProducesResponseType(typeof(CoreException<CoreError>), 400)]
        //[ProducesResponseType(typeof(InternalError), 500)]
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
