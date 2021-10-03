using System.Threading.Tasks;

namespace SoftPlan.Test.Application
{
    public interface IJurosStrategy
    {
        Task<decimal> CalcularJuros(decimal valorInicial, decimal taxa, int numeroMeses);
    }
}
