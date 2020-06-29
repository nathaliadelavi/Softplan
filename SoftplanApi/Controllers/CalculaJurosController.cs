using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftplanCore.ApiBoot;
using Microsoft.AspNetCore.Authorization;
using SoftplanRule;

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

        [HttpPost, AllowAnonymous]
        [ProducesResponseType(typeof(decimal), 200)]
        //[ProducesResponseType(typeof(CoreException<CoreError>), 400)]
        //[ProducesResponseType(typeof(InternalError), 500)]
        public decimal Post(decimal valorOriginal, int meses)
        {
            

            return 1.05M;
        }
    }
}
