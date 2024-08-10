using AGENDAMED.Application.Interface.AppServices;
using AGENDAMED.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.AppServices.serviceBase
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {

        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var result = await _serviceBase.Create(entity);

            return result;
        }

        public async Task<TEntity> FindById(int id)
        {
            var result = await _serviceBase.FindById(id);

            return result;
        }

        public async Task<IList<TEntity>> GetAll()
        {
            var result = await _serviceBase.GetAll();

            return result;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var result = await _serviceBase.Update(entity);
            return result;
        }
    }
}
