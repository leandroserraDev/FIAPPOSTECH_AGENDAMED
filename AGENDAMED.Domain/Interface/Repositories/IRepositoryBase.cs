using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Interface.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAll();  
        Task<TEntity >FindById(int id);
        Task<TEntity >Create(TEntity entity);
        Task<TEntity >Update(TEntity entity);
        void Delete(int id);
        
    }
}
