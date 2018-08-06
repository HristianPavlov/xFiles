using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFiles.Models;

namespace xFiles.Data
{
   public interface IXFilesSystemContext
    {
        IDbSet<City> Cities { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        int SaveChanges();

    }
}
