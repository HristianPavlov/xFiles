using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.AspNet.Identity.EntityFramework;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Common;
using xFiles.Data;
using xFiles.Models;

namespace xFiles.Data
{
    public class XFilesSystemContext : IdentityDbContext<ApplicationUser>,IXFilesSystemContext
    {
        public XFilesSystemContext()
            : base("XFiles")
        {
            
        }

        public XFilesSystemContext(DbConnection connection)
            : base(connection, true)
        {
        }


        public IDbSet<City> Cities { get; set; }

        public IDbSet<Country> Countries { get; set; }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Country>()
                .HasMany(b => b.Cities)
                .WithRequired(t => t.Cnt)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<Country>()
                .HasIndex(u => u.name)
                .IsUnique();

        }

        public static XFilesSystemContext Create()
        {
            return new XFilesSystemContext();
        }

        //RegisterConfigurations
    }
}
