using SoftPllan.Test.Domain.Entities;
using System.Data;
using System.Threading.Tasks;

namespace SoftPllan.Test.Domain.Interfaces.Repositories
{
    public interface IRepositoryJuros :IRepositoryBase<Juros>
    {
        Task<Juros> GetJuros();
    }
}
