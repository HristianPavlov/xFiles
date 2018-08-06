using System;
using System.ComponentModel.DataAnnotations;

namespace xFiles.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]

        public string name { get; set; }
                
        public int CountryId { get; set; }
        public virtual Country Cnt { get; set; }

        public bool IsDeleted { get; set; }

    }
}