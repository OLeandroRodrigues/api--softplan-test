using Microsoft.Extensions.Configuration;
using SoftPlan.Test.Application.Interfaces;
using SoftPllan.Test.Domain.Entities;
using SoftPllan.Test.Domain.Interfaces.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoftPlan.Test.Application
{
    public class JurosAppService : AppServiceBase<Juros>, IJurosAppService 
    {
        protected IServiceJuros _serviceJuros;
        private IConfiguration _configuration;
        public JurosAppService(IServiceJuros serviceJuros, IConfiguration configuration) :base(serviceJuros)
        {
            _serviceJuros = serviceJuros;
            _configuration = configuration;
        }

        public async Task<decimal> CalcularJuros(decimal valorInicial, decimal valorTaxa, int numeroMeses)
        {
            double principal = (double)valorInicial;
            double taxa = (double)valorTaxa / 100;
            double montante = principal * Math.Pow((1 + taxa), numeroMeses);

            return await Task.FromResult(Convert.ToDecimal(montante));
        }

        public async Task<Juros> GetJuros()
        {
            return await _serviceJuros.GetJuros();
        }

        public async Task<decimal> GetTaxaJurosOnline()
        {
            decimal taxaJuros = 0; 
            var httpClient = new HttpClient();
            var pathTaxaJuros = _configuration.GetSection("JurosIntegration:PathTaxaJuros").Value;
            HttpResponseMessage response = await httpClient.GetAsync(pathTaxaJuros);
            if (response.IsSuccessStatusCode)
                taxaJuros = Convert.ToDecimal(await response.Content.ReadAsStringAsync());

            return taxaJuros;
        }
    }
}
