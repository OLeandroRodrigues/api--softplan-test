using Microsoft.AspNetCore.Mvc;
using SoftPlan.Test.CrossCutting.API;
using System.Net;
using System.Threading.Tasks;

namespace SoftPlan.Test.API2.Controllers
{
    public class DesafioController : ApiController
    {
        [HttpGet("showmethecode")]
        public async Task<ActionResult<string>> GetUrlSourceProjectInGit()
        {
            return await Task.FromResult(ResponseMessage(HttpStatusCode.OK,"https://how"));
        }
    }
}
