using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Portfolio.Application.Exceptions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> query, DbContext context) where T : class
        {
            var entityType = context.Model.FindEntityType(typeof(T));
            if (entityType == null) return query;

            foreach (var navigation in entityType.GetNavigations())
            {
                query = query.Include(navigation.Name);
            }

            return query;
        }
        public static IQueryable<TEntity> IncludeMany<TEntity, TProperty>(this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> navigationPropertyPath, params Expression<Func<TProperty, object>>[] nextProperties) where TEntity : class
        {
            foreach (var nextProperty in nextProperties)
            {
                source = source.Include(navigationPropertyPath).ThenInclude(nextProperty);
            }
            return source;
        }

        public static IQueryable<TEntity> IncludeMany<TEntity, TProperty>(this IQueryable<TEntity> source, Expression<Func<TEntity, IEnumerable<TProperty>>> navigationPropertyPath, params Expression<Func<TProperty, object>>[] nextProperties) where TEntity : class
        {
            foreach (var nextProperty in nextProperties)
            {
                source = source.Include(navigationPropertyPath).ThenInclude(nextProperty);
            }
            return source;
        }
    }
}
