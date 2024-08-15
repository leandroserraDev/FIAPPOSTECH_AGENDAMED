using AGENDAMED.Domain.Interface.Repositories;
using AGENDAMED.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _applicationContext;

        public RepositoryBase(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var result = await _applicationContext.AddAsync(entity);
            await _applicationContext.SaveChangesAsync();

            return await Task.FromResult(entity);

        }

        public async void Delete(int id)
        {
            var entity = await _applicationContext.Set<TEntity>().FindAsync(id);

            _applicationContext.Set<TEntity>().Remove(entity);
        }

        public async Task< TEntity>FindById(int id)
        {
            var result = await _applicationContext.Set<TEntity>().FindAsync(id);

            return await Task.FromResult(result);
        }

        public async virtual Task<IList<TEntity>> GetAll()
        {
            return await _applicationContext.Set<TEntity>().ToListAsync();
        }

        public async Task< TEntity >Update(TEntity entity)
        {
            _applicationContext.Set<TEntity>().Update(entity);
            var result = await _applicationContext.SaveChangesAsync();

            return await Task.FromResult(entity);
        }

    
    }
}
