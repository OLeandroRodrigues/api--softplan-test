using Microsoft.AspNetCore.Mvc;
using Moq;
using SoftPlan.Test.API1.Controllers;
using SoftPlan.Test.Application.Interfaces;
using SoftPlan.Test.Domain.Factories;
using System;
using System.ComponentModel;
using System.Net;
using Xunit;

namespace SoftPlan.Test.API1.Test
{
    public class JurosControllerTest
    {
        protected JurosController _target;
        protected Mock<IJurosAppService> _jurosApp;
        public JurosControllerTest()
        {
            _jurosApp = new Mock<IJurosAppService>();
            _target = new JurosController(_jurosApp.Object);
        }

        [Fact(DisplayName="GetTaxaJurosWithSuccess")]
        [Description("A valor da taxa de juros foi obtido com sucesso")]
        public void GetTaxaJurosWithSuccess()
        {
            // arrange
            var juros = JurosFactory.Create();

            // action
            _jurosApp.Setup(x => x.GetJuros()).ReturnsAsync(juros);
            var result = _target.GetTaxaJuros();
            var objectResult = (ObjectResult)result.Result.Result;

            // assert 
            Assert.Equal(juros.Taxa, objectResult.Value);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }

        [Fact(DisplayName = "GetTaxaJurosWithBadRequest")]
        [Description("A valor da taxa de juros foi executada com falha")]
        public void GetTaxaJurosWithBadRequest()
        {
            // arrange
            var juros = JurosFactory.Create();
            juros.Taxa = 0;

            // action
            _jurosApp.Setup(x => x.GetJuros()).ReturnsAsync(juros);
            var result = _target.GetTaxaJuros();
            var objectResult = (ObjectResult)result.Result.Result;

            // assert 
            Assert.Equal((int)HttpStatusCode.BadRequest, objectResult.StatusCode);
        }

        [Fact(DisplayName = "GetTaxaJurosWithException")]
        [Description("A valor da taxa de juros foi executada com exceção")]
        public void GetTaxaJurosWithException()
        {
            // arrange
            var juros = JurosFactory.Create();

            // action
            _jurosApp.Setup(x => x.GetJuros()).Throws<Exception>();
            var result = _target.GetTaxaJuros();
            var objectResult = (ObjectResult)result.Result.Result;

            // assert 
            Assert.Equal((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
        }
    }
}
