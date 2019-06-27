using Gof.Api.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Gof.Api.Domain;

namespace Gof.Api.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<TDomainObject> Get<TDomainObject>() where TDomainObject : class
        {
            return this.Set<TDomainObject>();
        }

        public new EntityEntry<TDomainObject> Add<TDomainObject>(TDomainObject tDomainObject) where TDomainObject : class
        {
            return base.Add(tDomainObject);
        }

        public new EntityEntry<TDomainObject> Update<TDomainObject>(TDomainObject tDomainObject) where TDomainObject : class
        {
            return base.Update(tDomainObject);
        }

        public new EntityEntry<TDomainObject> Remove<TDomainObject>(TDomainObject tDomainObject) where TDomainObject : class
        {
            return base.Remove(tDomainObject);
        }

        public override TDomainObject Find<TDomainObject>(params object[] keyValues)
        {
            return base.Find<TDomainObject>(typeof(TDomainObject), keyValues);
        }
    }
}