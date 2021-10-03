using SoftPllan.Test.Domain.Entities;
using System.Threading.Tasks;

namespace SoftPllan.Test.Domain.Interfaces.Services
{
    public interface IServiceJuros : IServiceBase<Juros>
    {
        Task<Juros> GetJuros();
    }
}
