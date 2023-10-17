using Microsoft.EntityFrameworkCore;
using RabbitMQAll.Models;

namespace RabbitMQAll.DB
{
    public class Dbconnect : DbContext
    {
        public Dbconnect(DbContextOptions options) : base(options)
        {
        }
        public DbSet<FieldInvoce> fieldInvoces {  get; set; }
        public DbSet<Invoce> invoces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Invoce>()
                .HasOne(k => k.fieldInvoce)
                .WithOne(k => k.Invoce)
                .HasForeignKey<FieldInvoce>(f => f.idInvoce);
        }
    }
}
