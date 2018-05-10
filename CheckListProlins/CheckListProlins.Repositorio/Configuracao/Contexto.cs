using Entidades;
using System.Data.Entity;

namespace CheckListProlins.Repositorio.Configuracao
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("CheckListProlins")
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> USUARIO { get; set; }
    }
}