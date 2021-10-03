using System.Threading.Tasks;

namespace SoftPlan.Test.Application
{
    public class StrategyJurosContext : IJurosStrategy
    {
        protected IJurosStrategy _jurosStrategy;
        public StrategyJurosContext(IJurosStrategy jurosStrategy)
        {
            _jurosStrategy = jurosStrategy;
        }

        public async Task<decimal> CalcularJuros(decimal valorInicial, decimal taxa, int numeroMeses)
        {
            return await _jurosStrategy.CalcularJuros(valorInicial,taxa, numeroMeses);
        }
            
    }
}
