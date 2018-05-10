using CheckListProlins.Repositorio.Configuracao;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CheckListProlins.Repositorio.Repositorio
{
    public class Repositorio : IRepositorio
    {
        private DbContext dataContext { get; set; }

        public Repositorio()
        {
            this.dataContext = new Contexto();
        }

        private Repositorio(DbContext context)
        {
            this.dataContext = context; 
        }

        public static IRepositorio Create()
        {
            try
            {
                return new Repositorio();
            }
            catch (Exception exception)
            {
                throw new DataException(exception.ToString());
            }
        }

        public static IRepositorio Create(DbContext context)
        {
            try
            {
                return new Repositorio(context);
            }
            catch (Exception exception)
            {
                throw new DataException(exception.ToString());
            }
        }

        public TEntity Insert<TEntity>(TEntity entity) where TEntity : class, new()
        {
            try
            {
                return this.dataContext.Set<TEntity>().Add(entity);
            }
            catch (Exception exception)
            {
                throw new DataException(exception.ToString());
            }
        }

        public TEntity InsertAndSaveChanges<TEntity>(TEntity entity) where TEntity : class, new()
        {
            TEntity newEntity = Insert<TEntity>(entity);
            SaveChanges();

            return newEntity;
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class, new()
        {
            try
            {
                dataContext.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception exception)
            {
                throw new DataException(exception.ToString());
            }
        }

        public void UpdateAndSaveChanges<TEntity>(TEntity entity) where TEntity : class, new()
        {
            Update<TEntity>(entity);
            SaveChanges();
        }

        public void Delete<TEntity>(Expression<Func<TEntity, bool>> query) where TEntity : class, new()
        {
            try
            {
                IQueryable<TEntity> result = this.dataContext.Set<TEntity>().Where(query);

                if (result.Any())
                    this.dataContext.Set<TEntity>().Remove(result.Single());
            }
            catch (Exception exception)
            {
                throw new DataException(exception.ToString());
            }
        }

        public void DeleteAndSaveChanges<TEntity>(Expression<Func<TEntity, bool>> query) where TEntity : class, new()
        {
            Delete<TEntity>(query);
            SaveChanges();
        }

        public TEntity Find<TEntity>(Expression<Func<TEntity, bool>> query) where TEntity : class, new()
        {
            try
            {
                IQueryable<TEntity> result = this.dataContext.Set<TEntity>().Where(query);

                if (result.Any())
                    return result.Single();

                return null;
            }
            catch (Exception exception)
            {
                throw new DataException(exception.ToString());
            }
        }

        public IQueryable<TEntity> List<TEntity>() where TEntity : class, new()
        {
            try
            {
                return this.dataContext.Set<TEntity>().AsQueryable<TEntity>();
            }
            catch (Exception exception)
            {
                throw new DataException(exception.ToString());
            }
        }

        public IQueryable<TEntity> List<TEntity>(Expression<Func<TEntity, bool>> query) where TEntity : class, new()
        {
            try
            {
                return this.dataContext.Set<TEntity>().AsQueryable<TEntity>().Where(query);
            }
            catch (Exception exception)
            {
                throw new DataException(exception.ToString());
            }
        }

        public void SaveChanges()
        {
            try
            {
                this.dataContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new DataException(exception.ToString());
            }
        }

        public DbContext GetContext()
        {
            return this.dataContext;
        }

        private bool disposed;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    dataContext.Dispose();
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Repositorio()
        {
            Dispose(false);
        }
    }
}
