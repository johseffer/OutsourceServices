namespace ServiçosExternos.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext()
            : base("name=AppContext")
        {

        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ApplicationUserFornecedor> ApplicationUserFornecedors { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Service> Service { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
