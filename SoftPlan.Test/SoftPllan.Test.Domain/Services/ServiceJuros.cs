using SoftPllan.Test.Domain.Entities;
using SoftPllan.Test.Domain.Interfaces.Repositories;
using SoftPllan.Test.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoftPllan.Test.Domain.Services
{
    public class ServiceJuros : ServiceBase<Juros>, IServiceJuros
    {
        protected IRepositoryJuros _jurosRepository;

        public ServiceJuros(IRepositoryJuros jurosRepository):base(jurosRepository)
        {
            _jurosRepository = jurosRepository;
        }

        public async Task<Juros> GetJuros()
        {
            return await _jurosRepository.GetJuros();
        }
    }
}
