using Microsoft.AspNetCore.Mvc;
using Moq;
using SoftPlan.Test.API2.Controllers;
using System.ComponentModel;
using System.Net;
using Xunit;

namespace SoftPlan.Test.API.Test
{
    public class DesafioControllerTest
    {
        protected DesafioController _target;
        public DesafioControllerTest()
        {
            _target = new DesafioController();
        }

        [Fact(DisplayName= "GetUrlSourceProjectInGitWithSuccess")]
        [Description("O Index retorna uma URL com sucesso")]
        public void GetUrlSourceProjectInGitWithSuccess()
        {
            // arrange
            string urlGit = "https://how";

            // action
            var result = _target.GetUrlSourceProjectInGit();
            var objectResult = (ObjectResult)result.Result.Result;

            // assert 
            Assert.Equal(urlGit, objectResult.Value);
            Assert.Equal((int)HttpStatusCode.OK, objectResult.StatusCode);
        }
    }
}
