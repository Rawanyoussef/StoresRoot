using Stores.Data.Entities;
using Stores.Reposatory.Spesification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stores.Reposatory.Interface
{
    public interface IGenericReposatory<TEntity ,TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);
       // Task<TEntity> GetByIdAsNoTrakingAsync(TKey id);

        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<IReadOnlyList<TEntity>> GetAllAsNoTrakingAsync();

        Task AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);

        Task<TEntity> GetWithSpecificationByIdAsync(ISpesfication<TEntity> specs);
        Task<IReadOnlyList<TEntity>> GetAllspecsAsync(ISpesfication<TEntity> specs);
        Task<int> GetCountSpecificationAsync(ISpesfication<TEntity> specs);


    }
}
