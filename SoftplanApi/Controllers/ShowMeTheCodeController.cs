using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftplanCore.ApiBoot;

namespace SoftplanApi.Controllers
{
    [ApiVersion("2")]
    public class ShowMeTheCodeController : ApiController
    {
        private readonly ILogger<ShowMeTheCodeController> _logger;

        public ShowMeTheCodeController(ILogger<ShowMeTheCodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet, AllowAnonymous]
        [ProducesResponseType(typeof(string), 200)]
        //[ProducesResponseType(typeof(CoreException<CoreError>), 400)]
        //[ProducesResponseType(typeof(InternalError), 500)]
        public string Get()
        {
            return "Nathalia P Delavi";
        }
    }
}
