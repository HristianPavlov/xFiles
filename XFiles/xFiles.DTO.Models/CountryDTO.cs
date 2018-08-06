using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFiles.Models;

namespace xFiles.DTO.Models
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string name { get; set; }

        public CountryDTO()
        {
            this.Cities = new List<string>();

        }

        public  ICollection<string> Cities { get; set; }

        public bool IsDeleted { get; set; }

    }
}
