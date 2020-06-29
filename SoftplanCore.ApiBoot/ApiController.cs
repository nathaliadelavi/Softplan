using Microsoft.AspNetCore.Mvc;

namespace SoftplanCore.ApiBoot
{
    /// <summary>
    /// Controller base for api controllers with route for versioning.
    /// It requires authorization, if you need to disable authorization on 
    /// inherited controller, add AllowAnonoymous decoration.
    /// </summary>
    [Route("api{version:apiVersion}/[controller]")]
    public abstract class ApiController : NonVersionedApiController
    {
    }
}
