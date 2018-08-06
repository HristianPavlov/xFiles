using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XFiles.Models
{
    public class CreateCityAndCountryViewModel
    {
        public IList<string> cityNames { get; set; }

        public CreateCityAndCountryViewModel()
        {
            this.cityNames = new List<string>();
        }

        [Required]
        public string cityName { get; set; }
        [Required]
        public string countryName { get; set; }


    }
}