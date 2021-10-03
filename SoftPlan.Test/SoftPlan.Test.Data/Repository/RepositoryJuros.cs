using SoftPlan.Test.Domain.Factories;
using SoftPllan.Test.Domain.Entities;
using SoftPllan.Test.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace SoftPlan.Test.Data.Repository
{
    public class RepositoryJuros : RepositoryBase<Juros>, IRepositoryJuros
    {
        public RepositoryJuros(Context Db)
        {
            this.Db = Db;
        }
        public async Task<Juros> GetJuros()
        {
            return await Task.FromResult(JurosFactory.Create());
        }
    }
}
