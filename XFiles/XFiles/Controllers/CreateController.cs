using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using xFiles.Services;
using XFiles.Models;
using PagedList;
using XFiles.Exeptions;
using xFiles.Models;

namespace XFiles.Controllers
{
    public class CreateController : Controller
    {
        private readonly ICreateService createService;

        //public HomeController()
        //

        //}

        public CreateController(ICreateService createService)
        {
            this.createService = createService ?? throw new ArgumentNullException(nameof(createService));
        }
        // GET: Create
        public ActionResult Index(int? page)
        {
            //var cities = createService.GetAllCities();
            var countries = createService.GetAllCountries();
            var listView = new List<CreateCityAndCountryViewModel>();

            foreach (var item in countries)
            {
                

                foreach (var town in item.Cities)
                {
                    var form = new CreateCityAndCountryViewModel();
                    form.countryName = item.name;
                    form.cityName = town.name;
                    listView.Add(form);
                }

                

            }
            int pageSize =3;
            int pageNumber = (page ?? 1);
            return View(listView.ToPagedList(pageNumber, pageSize));

            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCityAndCountryViewModel model)
        {
            var CNT = new Country();
            CNT.name = model.countryName;

            var city = new City();
            city.name = model.cityName;

            if (city.name.Equals(CNT.name))
            {
                ModelState.AddModelError("", "Can`t have a country and a city named the same.");
                return View();
            }

            try
            {
                this.createService.Add(city, CNT);
            }
            catch (Exception e)
            {

                ModelState.AddModelError("",e.Message);
                return View();
            }




            ViewBag.Message = "Data Updated";
            return View();
        }
    }
}