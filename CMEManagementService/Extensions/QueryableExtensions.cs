using System.Linq.Expressions;

namespace CMEManagementService.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TBase> OfType<TBase>(this IQueryable<TBase> source, Type derivedType)
        {
            // Create Parameter "p => ..."
            var parameter = Expression.Parameter(typeof(TBase), "p");

            // "p is <derivedType>"
            var body = Expression.TypeIs(parameter, derivedType);

            // "p => p is <derivedType>"
            var predicate = Expression.Lambda<Func<TBase, bool>>(body, parameter);

            return source.Where(predicate);
        }
    }

}