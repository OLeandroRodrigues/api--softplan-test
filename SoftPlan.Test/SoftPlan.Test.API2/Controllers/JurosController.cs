using Microsoft.AspNetCore.Mvc;
using SoftPlan.Test.Application;
using SoftPlan.Test.Application.Interfaces;
using SoftPlan.Test.CrossCutting.API;
using SoftPlan.Test.Domain.Validations;
using SoftPlan.Test.Domain.ViewModel;
using System;
using System.Net;
using System.Threading.Tasks;
using SoftPlan.Test.API2.Extensions;

namespace SoftPlan.Test.API2.Controllers
{
    public class JurosController : ApiController
    {
        protected IJurosAppService _jurosApp;
        
        public JurosController(IJurosAppService jurosApp)
        {
            _jurosApp = jurosApp;
        }

        /// <summary>
        /// Retorna Juros Calculado
        /// </summary>
        /// <returns></returns>
        [HttpGet("calculajuros")]
        public async Task<ActionResult<string>> GetTaxaJuros([FromQuery] DadosCalculoJurosViewModel dadosCalculoJurosViewModel)
        {
            try
            {
                if (!IsEntityValid(new DadosCalculoJurosValidator(), dadosCalculoJurosViewModel, out string[] erros))
                    return ResponseMessage(HttpStatusCode.BadRequest, erros);

                decimal taxa = await _jurosApp.GetTaxaJurosOnline();
                var valorJuros = await new StrategyJurosContext(_jurosApp).CalcularJuros(dadosCalculoJurosViewModel.ValorInicial, Convert.ToDecimal(taxa), dadosCalculoJurosViewModel.Meses);
                
                return ResponseMessage(HttpStatusCode.OK, valorJuros.ToMoneyBRLWith2Decimal());
            }
            catch (Exception ex)
            {
                return ResponseMessage(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
