using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftplanCore.ApiBoot;
using SoftplanRule;
using System;
using System.Linq;

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

        /// <summary>
        /// Retorna a url do GitHub para este código fonte
        /// </summary>
        /// <returns>URL do código fonte</returns>
        [HttpGet, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public string Get()
        {
            var caminhoRepository = AppDomain.CurrentDomain
                .BaseDirectory.Split("SoftplanApi").FirstOrDefault();

            var repositoryInfo = RepositoryInformation.GetRepositoryInformationForPath(caminhoRepository);

            return repositoryInfo.Url;
        }
    }
}
