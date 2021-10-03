using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SoftPllan.Test.Domain.Entities;

namespace SoftPlan.Test.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        private void RegisterMaps(ModelBuilder builder)
        {
            var maps = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrWhiteSpace(type.Namespace)
                && typeof(EntitiesConfig).IsAssignableFrom(type) && type.IsClass).ToList();


            foreach (var item in maps)
                if (item.Name != "IEntityMap")
                {
                    Activator.CreateInstance(item, BindingFlags.Public |
                    BindingFlags.Instance, null, new object[] { builder }, null);
                }
        }

        public DbSet<Juros> Juros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RegisterMaps(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
