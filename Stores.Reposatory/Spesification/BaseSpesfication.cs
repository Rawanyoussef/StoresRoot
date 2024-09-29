using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stores.Reposatory.Spesification
{
    public class BaseSpesfication<T> : ISpesfication<T>
    {
        public BaseSpesfication(Expression<Func<T,bool>>criteria) 
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria {  get;  }

        public List<Expression<Func<T, object>>> Includes { get; } =new List<Expression<Func<T, object>>>();

        public List<Expression<Func<T, object>>> OrderBy { get; private set; }

        public List<Expression<Func<T, object>>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginated { get; private set; }

        Expression<Func<T, object>> ISpesfication<T>.OrderBy => throw new NotImplementedException();

        Expression<Func<T, object>> ISpesfication<T>.OrderByDescending => throw new NotImplementedException();

        protected void AddIclude(Expression<Func<T, object>> includeExpression)
            => Includes.Add(includeExpression);
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
            => OrderBy.Add(orderByExpression);
        protected void AddOrderByDesending(Expression<Func<T, object>> AddOrderByDesending)
          => OrderBy.Add(AddOrderByDesending);
        protected void ApplyPagination (int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPaginated = true;
        }
    }
    
}
