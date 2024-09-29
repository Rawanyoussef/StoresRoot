using Stores.Data.Entities;
using Stores.Reposatory.Repposatoyr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stores.Reposatory.Interface
{
    public interface IUnitOfWork
    {
        IGenericReposatory<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        Task<int> CompleteAsync();
    }
}
