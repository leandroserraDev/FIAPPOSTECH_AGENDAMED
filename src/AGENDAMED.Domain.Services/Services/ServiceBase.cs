﻿using AGENDAMED.Domain.Interface.Repositories;
using AGENDAMED.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Domain.Services.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var result = await _repositoryBase.Create(entity);

            return result;
        }

        public async void Delete(int id)
        {
            _repositoryBase.Delete(id);
        }

        public async Task<TEntity> FindById(int id)
        {
           var result = await _repositoryBase.FindById(id);
            return result;
        }

        public async Task<IList<TEntity>> GetAll()
        {
            var result = await _repositoryBase.GetAll();
            return result;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var result = await _repositoryBase.Update(entity);
            return result;
        }
    }
}
