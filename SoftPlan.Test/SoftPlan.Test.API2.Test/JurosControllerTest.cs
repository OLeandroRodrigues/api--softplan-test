using Microsoft.AspNetCore.Mvc;
using Moq;
using SoftPlan.Test.API2.Controllers;
using SoftPlan.Test.Application;
using SoftPlan.Test.Application.Interfaces;
using SoftPlan.Test.Domain.Factories;
using SoftPlan.Test.Domain.ViewModel;
using System;
using System.ComponentModel;
using System.Net;
using Xunit;

namespace SoftPlan.Test.API.Test
{
    public class JurosControllerTest
    {
        protected JurosController _target;
        protected Mock<StrategyJurosContext> _strategyJurosContext;
        protected Mock<IJurosAppService> _jurosApp;
        protected Mock<IJurosStrategy> _jurosStrategy;
        public JurosControllerTest()
        {
            _jurosApp = new Mock<IJurosAppService>();
            _jurosStrategy = new Mock<IJurosStrategy>();
            _strategyJurosContext = new Mock<StrategyJurosContext>();    
            _target = new JurosController(_jurosApp.Object);
        }

        [Fact(DisplayName="GetTaxaJurosWithSuccess")]
        [Description("O calculo do juros foi realizado com sucesso")]
        public void GetTaxaJurosWithSuccess()
        {
            // arrange
            var dadosCalculoJuros = DadosCalculoJurosFactory.Create();
            dadosCalculoJuros.ValorInicial = 100;
            dadosCalculoJuros.Meses = 5;

            decimal taxaJuros = 1;
            decimal valorJurosCalculado = 105.10M;
            string valorJurosCalculadoExpeced = "105,10";

            // action
            _jurosApp.Setup(x => x.GetTaxaJurosOnline()).ReturnsAsync(taxaJuros);
            _jurosApp.Setup(x => x.CalcularJuros(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<int>())).ReturnsAsync(valorJurosCalculado);
            var result = _target.GetTaxaJuros(dadosCalculoJuros);
            var objectResult = (ObjectResult)result.Result.Result;

            // assert 
            Assert.Equal(valorJurosCalculadoExpeced, objectResult.Value);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact(DisplayName= "GetTaxaJurosWithBadRequest")]
        [Description("O calculo do juros foi realizado com falha")]
        public void GetTaxaJurosWithBadRequest()
        {
            // arrange
            var dadosCalculoJuros = DadosCalculoJurosFactory.Create();
            dadosCalculoJuros.ValorInicial = 0;
            dadosCalculoJuros.Meses = 5;

            decimal taxaJuros = 1;
            decimal valorJurosCalculado = 105.10M;

            // action
            _jurosApp.Setup(x => x.GetTaxaJurosOnline()).ReturnsAsync(taxaJuros);
            _jurosApp.Setup(x => x.CalcularJuros(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<int>())).ReturnsAsync(valorJurosCalculado);
            var result = _target.GetTaxaJuros(dadosCalculoJuros);
            var objectResult = (ObjectResult)result.Result.Result;

            // assert 
            Assert.Equal((int)HttpStatusCode.BadRequest, objectResult.StatusCode);
        }

        [Fact(DisplayName="GetTaxaJurosWithBadException")]
        [Description("O calculo do juros foi realizado com exceção")]
        public void GetTaxaJurosWithBadException()
        {
            // arrange
            var dadosCalculoJuros = DadosCalculoJurosFactory.Create();
            dadosCalculoJuros.ValorInicial = 100;
            dadosCalculoJuros.Meses = 5;

            decimal valorJurosCalculado = 105.10M;

            // action
            _jurosApp.Setup(x => x.GetTaxaJurosOnline()).Throws<Exception>();
            _jurosApp.Setup(x => x.CalcularJuros(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<int>())).ReturnsAsync(valorJurosCalculado);
            var result = _target.GetTaxaJuros(dadosCalculoJuros);
            var objectResult = (ObjectResult)result.Result.Result;

            // assert 
            Assert.Equal((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
        }
    }
}
