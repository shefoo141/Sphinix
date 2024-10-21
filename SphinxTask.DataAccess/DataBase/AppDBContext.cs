using Microsoft.EntityFrameworkCore;
using SphinxTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SphinxTask.DataAccess.DataBase
{
    public class AppDB: DbContext
    {
        public AppDB(DbContextOptions<AppDB> options) : base(options)   
        {
                
        }
        public DbSet<Client> clients { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ClientProducts> clientProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(C => C.CId);
            modelBuilder.Entity<Client>().HasIndex(C => C.Code).IsUnique();
            modelBuilder.Entity<Product>().HasKey(P => P.PId);
            modelBuilder.Entity<ClientProducts>().HasKey(CP => CP.ClientproductsId);
            modelBuilder.Entity<ClientProducts>().HasOne(cp => cp.client).WithMany(c => c.ClientProducts).HasForeignKey(cp => cp.ClientId);
            modelBuilder.Entity<ClientProducts>().HasOne(cp => cp.product).WithMany(p => p.ClientProducts).HasForeignKey(cp => cp.ProductId);


            base.OnModelCreating(modelBuilder);
        }

    }
}
