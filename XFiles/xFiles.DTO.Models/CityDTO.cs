using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xFiles.Models;

namespace xFiles.DTO.Models
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string name { get; set; }

        public int CountryId { get; set; }
        public virtual CountryDTO Cnt { get; set; }

        public bool IsDeleted { get; set; }
       
    }
}
