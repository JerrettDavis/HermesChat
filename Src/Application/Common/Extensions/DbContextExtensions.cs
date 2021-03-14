using System.Linq;
using Application.Common.Interfaces.Data;

namespace Application.Common.Extensions
{
    public static class DbContextExtensions
    {
        public static bool Attached<T>(this IApplicationDbContext context, T entity)
            where T : class
        {
            return context.Set<T>().Local.Any(e => Equals(e, entity));
        }

        public static T? GetAttached<T>(this IApplicationDbContext context, T entity)
            where T : class
        {
            return context.Set<T>().Local
                .ToList()
                .SingleOrDefault(e => Equals(e, entity));
        }

        public static T EnsureAttached<T>(this IApplicationDbContext context, T entity)
            where T : class
        {
            var attached = GetAttached(context, entity);

            if (attached != null) return attached;

            context.Set<T>().Attach(entity);

            return entity;
        }
    }
}