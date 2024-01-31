using Library.DomainLayer.Book;
using Library.DomainLayer.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.Persistent.EF
{
    public class EFDbContext:DbContext
    {

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(EFDbContext).Assembly);
            base.OnModelCreating(modelbuilder);
        }
    }
    //public class EfDbContextFactory : IDesignTimeDbContextFactory<EFDbContext>
    //{
    //    public EFDbContext CreateDbContext(string[] args)
    //    {
    //        var builder = Microsoft.AspNetCore.Builder. WebApplication.CreateBuilder(args);
    //        var optionsBuilder = new DbContextOptionsBuilder<EFDbContext>();
    //        optionsBuilder.UseSqlServer(builder.Configuration["ConnectionStrings:GoodBookDatabase"]);

    //        return new EFDbContext(optionsBuilder.Options);
    //    }
    //}
}
