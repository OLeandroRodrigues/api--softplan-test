using System.Threading.Tasks;
using SoftPllan.Test.Domain.Entities;


namespace SoftPlan.Test.Application.Interfaces
{
    public interface IJurosAppService : IAppServiceBase<Juros>, IJurosStrategy
    {
        Task<Juros> GetJuros();
        Task<decimal> GetTaxaJurosOnline();
    }
}
