using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using xFiles.Data;

using xFiles.Models;

namespace xFiles.Services
{
    public class CreateService: ICreateService
    {
        private readonly IXFilesSystemContext dbContext;

        public CreateService(IXFilesSystemContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IEnumerable<City> GetAllCities()
        {
            var list = this.dbContext.Cities.ToList();
            var listDTO = new List<City>();
            foreach (var item in list)
            {
                var form = new City();
                form.name = item.name;
                listDTO.Add(form);
            }
            return listDTO;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            var list = this.dbContext.Countries.ToList();
           
           // var listDTO = new List<CountryDTO>();
            //foreach (var item in list)
            //{
            //    var form = new CountryDTO();
            //    form.name = item.name;

            //    form.Cities = item.Cities;

            //    listDTO.Add(form);
            //}
            return list;
        }


        public void Add(City city,Country CNT)
        {
                        
            try
            {
                var CitySearchForCountry = this.dbContext.Cities.Where(t => t.name == CNT.name).FirstOrDefault();
                var CountrySearchForCity = this.dbContext.Countries.Where(t => t.name == city.name).FirstOrDefault();

                if (CitySearchForCountry != null)
                {
                    throw new Exception("There Is A City With The Same Name As The Country");
                }
                
                if (CountrySearchForCity != null)
                {
                    throw new Exception("There Is A Country With The Same Name As The City");
                }
            }
            catch (Exception x)
            {

                throw ;
            }
            


            var CountrySearch = this.dbContext.Countries.Where(t => t.name == CNT.name).FirstOrDefault();
            if (CountrySearch!=null)
            {
                CountrySearch.Cities.Add(city);
                this.dbContext.SaveChanges();
                return;
            }


            this.dbContext.Cities.Add(city);
            this.dbContext.Countries.Add(CNT);


            this.dbContext.SaveChanges();

        }

    }
}
