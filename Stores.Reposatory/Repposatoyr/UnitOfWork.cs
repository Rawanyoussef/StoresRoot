using Stores.Data.Context;
using Stores.Data.Entities;
using Stores.Reposatory.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stores.Reposatory.Repposatoyr
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoresDBContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoresDBContext context)
        {
            _context = context;
        }
        public async Task<int> CompleteAsync()
          => await _context.SaveChangesAsync();

        public IGenericReposatory<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            if (_repositories is null)
                _repositories = new Hashtable();

            var entityKey = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(entityKey))
            {
                var repositoryType = typeof(GenericReposatory<,>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TKey)), _context);
                _repositories.Add(entityKey, repositoryInstance);
            }
            return (IGenericReposatory<TEntity, TKey>)_repositories[entityKey];
        }

       
    }
}