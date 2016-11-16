using Calamari.Models;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Calamari.Repository.Context
{
    public partial class CalamariContext : DbContext
    {
        public CalamariContext()
            : base("name=CalamariContext")
        {
        }

        public CalamariContext(bool enableLazyLoading, bool enableProxyCreation)
          : base("Name=CalamariContext")
        {
            Configuration.ProxyCreationEnabled = enableProxyCreation;
            Configuration.LazyLoadingEnabled = enableLazyLoading;
        }

        public CalamariContext(DbConnection connection)
          : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Suppress code first model migration check
            Database.SetInitializer<CalamariContext>(new AlwaysCreateInitializer());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<CalamariContext>
        {
            protected override void Seed(CalamariContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<CalamariContext>
        {
            protected override void Seed(CalamariContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class AlwaysCreateInitializer : DropCreateDatabaseAlways<CalamariContext>
        {
            protected override void Seed(CalamariContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public void Seed(CalamariContext Context)
        {
            var listProducts = new List<Product>() {
            new Product
            {
                Id = 1, RefId = new System.Guid("d3cac20f-a57f-48cb-a47a-356aff5b23ae"),
                Name = "Battered Rings", Description = "1Kg Calamari Rings in Batter.",
                Price = 120
            },
            new Product
            {
                Id = 2, RefId = new System.Guid("3c9f12fa-3079-4b39-a1f7-a3bf0193223e"),
                Name = "Griller Rings", Description = "1Kg Calamari Rings.",
                Price = 80
            },
            new Product
            {
                Id = 3, RefId = new System.Guid("262d6309-9f29-45d9-8716-0e2f24929a55"),
                Name = "Steaks", Description = "1Kg Calamari steaks.",
                Price = 120
            },
            new Product
            {
                Id = 4, RefId = new System.Guid("f1b89cdc-e900-4ffd-99fb-81130a9bf132"),
                Name = "Tubes", Description = "1Kg Calamari tubes, great for stuffing.",
                Price = 120
            },
            new Product
            {
                Id = 5, RefId = new System.Guid("2f654ded-f8c1-48ca-b1ab-a3c7070f5140"),
                Name = "Tentacles", Description = "500grams Calamari Heads with tentacles.",
                Price = 80
            },
            new Product
            {
                Id = 6, RefId = new System.Guid("2643489c-4942-4e1f-9b77-5c9e1c9a773f"),
                Name = "Mix", Description = "1Kg Party Mix",
                Price = 120
            }
          };
            Context.Products.AddRange(listProducts);
            Context.SaveChanges();
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}