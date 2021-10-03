using Microsoft.AspNetCore.Mvc;
using SoftPlan.Test.Application.Interfaces;
using SoftPlan.Test.CrossCutting.API;
using SoftPlan.Test.Domain.Validations;
using System.Net;
using System.Threading.Tasks;

namespace SoftPlan.Test.API1.Controllers
{
    public class JurosController : ApiController
    {
        protected IJurosAppService _jurosApp;

        public JurosController(IJurosAppService jurosApp)
        {
            _jurosApp = jurosApp;
        }

        /// <summary>
        /// Retorna Taxa de Juros
        /// </summary>
        /// <returns></returns>
        [HttpGet("taxaJuros")]
        public async Task<ActionResult<decimal>>GetTaxaJuros()
        {
            try
            {
                var juros = await _jurosApp.GetJuros();

                if (!IsEntityValid(new JurosValidator(), juros, out string[] erros))
                    return ResponseMessage(HttpStatusCode.BadRequest, erros);

                return ResponseMessage(HttpStatusCode.OK, juros.Taxa);
            }
            catch (System.Exception ex)
            {
                return ResponseMessage(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
