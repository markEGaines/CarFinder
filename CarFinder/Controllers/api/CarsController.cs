using CarFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarFinder.Controllers.api
{
    [RoutePrefix("api/Cars")]
    public class CarsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public class SelectedValues
        {
            public string year;
            public string make;
            public string model;
            public string trim;
            public string filter;
            public bool paging;
            public int page;
            public int perPage;
        }

        [HttpPost]
        [Route("GetByYear")]
        public async Task<IHttpActionResult> GetByYear(SelectedValues selected)
        {
            if (string.IsNullOrWhiteSpace(selected.year))
                return BadRequest();
            return Ok(await db.GetMakes(selected.year));
        }

        [HttpPost]
        [Route("GetMakes")]
        public async Task<List<string>> GetMakes(SelectedValues selected)
        {
            return await db.GetMakes(selected.year);
        }

        [HttpPost]
        [Route("GetModels")]
        public async Task<List<string>> GetModels(SelectedValues selected)
        {
            return await db.GetModels(selected.year, selected.make);
        }

        [HttpPost]
        [Route("GetTrims")]
        public async Task<List<string>> GetTrims(SelectedValues selected)
        {
            return await db.GetTrims(selected.year, selected.make, selected.model);
        }

        [HttpPost]
        [Route("GetCars")]
        public async Task<List<Car>> GetCars(SelectedValues selected)
        {
            return await db.GetCars(selected.year, selected.make, selected.model, selected.trim, selected.filter, selected.paging, selected.page, selected.perPage);
        }


        [HttpPost]
        [Route("GetCarsCount")]
        public async Task<int> GetCarsCount(SelectedValues selected)
        {
            return await db.GetCarsCount(selected.year, selected.make, selected.model, selected.trim, selected.filter);
        }

        [HttpGet]
        [Route("GetCar")]
        public Car GetCar(int id)
        {
            return db.Cars.Find(id);
        }

        [HttpPost]
        [Route("GetYears")]
        public async Task<List<string>> GetYears()
        {
            return await db.GetYears();
        }
    }
}

//        public async Task<List<string>> GetCars(string year, string make, string model, string trim,  string filter, string paging, string page, string perPage)
