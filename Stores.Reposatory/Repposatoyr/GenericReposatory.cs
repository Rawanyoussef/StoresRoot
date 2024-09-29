using Microsoft.EntityFrameworkCore;
using Stores.Data.Context;
using Stores.Data.Entities;
using Stores.Reposatory.Interface;
using Stores.Reposatory.Spesification;

namespace Stores.Reposatory.Repposatoyr
{
    public class GenericReposatory<TEntity, TKey> : IGenericReposatory<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoresDBContext _context;

        public GenericReposatory(StoresDBContext context)
        {
           _context = context;
        }
        public async Task AddAsync(TEntity entity)
       =>await _context.Set<TEntity>().AddAsync(entity);

        public async void DeleteAsync(TEntity entity)
      => _context.Set<TEntity>().Remove(entity);

        public  async Task<IReadOnlyList<TEntity>> GetAllAsNoTrakingAsync()
       => await _context.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
       => await _context.Set<TEntity>().ToListAsync();

        public  async Task<TEntity> GetByIdAsync(TKey id)
       =>await _context.Set<TEntity>().FindAsync(id);

        public  async Task<TEntity> GetWithSpecificationByIdAsync(ISpesfication<TEntity> specs)
             => await SpecificationEvaloater<TEntity, TKey>.GetQuery(_context.Set<TEntity>(), specs).FirstOrDefaultAsync();


        public async Task<IReadOnlyList<TEntity>> GetAllspecsAsync(ISpesfication<TEntity> specs)
      => await SpecificationEvaloater<TEntity ,TKey>.GetQuery(_context.Set<TEntity>(), specs).ToListAsync();
        public void UpdateAsync(TEntity entity)
      =>  _context.Set<TEntity>().Update(entity);

        public async Task<int> GetCountSpecificationAsync(ISpesfication<TEntity> specs)
      => await ApplySpecification(specs).CountAsync(); 



        //public Task<TEntity> GetByIdAsNoTrakingAsync(TKey id)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
