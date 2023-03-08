using Microsoft.AspNetCore.Mvc;

namespace COMMANDER.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class Httpclient : ControllerBase    
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public Httpclient(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string clientIpAddress = this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            return new string[] { "clientIpAddress ", clientIpAddress };
        }

    }
}