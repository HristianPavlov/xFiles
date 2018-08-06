using System.Collections.Generic;

using xFiles.Models;

namespace xFiles.Services
{
    public interface ICreateService
    {
        void Add(City city, Country Cnt);
         IEnumerable<City> GetAllCities();
        IEnumerable<Country> GetAllCountries();
    }
}