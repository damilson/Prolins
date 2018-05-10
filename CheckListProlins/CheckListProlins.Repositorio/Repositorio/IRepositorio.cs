using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CheckListProlins.Repositorio.Repositorio
{
    public interface IRepositorio : IDisposable
    {
        TEntity Insert<TEntity>(TEntity entity)
            where TEntity : class, new();

        TEntity InsertAndSaveChanges<TEntity>(TEntity entity)
            where TEntity : class, new();

        void Update<TEntity>(TEntity entity)
            where TEntity : class, new();

        void UpdateAndSaveChanges<TEntity>(TEntity entity)
            where TEntity : class, new();

        void Delete<TEntity>(Expression<Func<TEntity, bool>> query)
            where TEntity : class, new();

        void DeleteAndSaveChanges<TEntity>(Expression<Func<TEntity, bool>> query)
            where TEntity : class, new();

        TEntity Find<TEntity>(Expression<Func<TEntity, bool>> query)
            where TEntity : class, new();

        IQueryable<TEntity> List<TEntity>()
            where TEntity : class, new();

        IQueryable<TEntity> List<TEntity>(Expression<Func<TEntity, bool>> query)
            where TEntity : class, new();

        void SaveChanges();

        DbContext GetContext();
    }
}
