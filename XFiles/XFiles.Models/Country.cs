using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xFiles.Models
{
    public class Country
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Card number should be 16 symbols long.")]
        public string name { get; set; }

        public Country()
        {
            this.Cities = new HashSet<City>();
       
        }

        public virtual ICollection<City> Cities { get; set; }

        public bool IsDeleted { get; set; }

    }
}