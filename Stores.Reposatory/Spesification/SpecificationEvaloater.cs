using Microsoft.EntityFrameworkCore;
using Stores.Data.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace Stores.Reposatory.Spesification
{
    public class SpecificationEvaloater<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpesfication<TEntity> specs)
        {
            var query = inputQuery;

            if (specs is not null)
            {
                if (specs.Criteria != null)
                {
                    query = query.Where(specs.Criteria);
                }

                if (specs.OrderBy != null)
                {
                    query = query.OrderBy(specs.OrderBy);
                }

                if (specs.OrderByDescending != null)
                {                
                    query = query.OrderByDescending(specs.OrderByDescending);
                }

                if (specs.Includes != null && specs.Includes.Any())
                {
                    query = specs.Includes.Aggregate(query, (current, includeExpression) => current.Include(includeExpression));
                }

                if (specs.IsPaginated)
                {
                    query = query.Skip(specs.Skip).Take(specs.Take);
                }
            }

            return query;
        }
    }
}
