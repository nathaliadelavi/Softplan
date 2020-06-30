using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftplanCore.ApiBoot;
using Microsoft.AspNetCore.Authorization;
using SoftplanRule;
using Microsoft.AspNetCore.Http;

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
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///     
        /// </remarks>
        /// <param name="valorOriginal">Valor original da dívida</param>
        /// <param name="meses">Quantidade de meses de atraso</param>
        /// <returns>Valor total do juros</returns>
        [HttpPost, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public decimal Post(decimal valorOriginal, int meses)
        {
            

            return 1.05M;
        }
    }
}
