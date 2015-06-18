using Bing;
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

        [HttpGet, HttpPost, Route("getCar")]
        public async Task<IHttpActionResult> getCar(int Id)
        {
            HttpResponseMessage response;
            string content = "";
            var Car = db.Cars.Find(Id);
            var Recalls = "";
            var Image = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.nhtsa.gov/");
                try
                {
                    response = await client.GetAsync("webapi/api/Recalls/vehicle/modelyear/" + Car.Model_year +
                                                                                    "/make/" + Car.Make +
                                                                                    "/model/" + Car.Model_name + "?format=json");
                    content = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }
            Recalls = content;

            var image = new BingSearchContainer(new Uri("https://api.datamarket.azure.com/Bing/search/"));

            image.Credentials = new NetworkCredential("accountKey", "5u/0CzVmYrTKDOjlxPePfPkh/G8llMIfVJ7QC/oNEvQ");   //"dwmFt1J2rM45AQXkGTk4ebfcVLNcytTxGMHK6dgMreg"
            var marketData = image.Composite(
                "image",
                Car.Model_year + " " + Car.Make + " " + Car.Model_name + " " + Car.Model_trim,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
                ).Execute();

            Image = marketData.First().Image.First().MediaUrl;
            return Ok(new { car = Car, recalls = Recalls, image = Image });

        }

        [HttpPost]
        [Route("GetYears")]
        public async Task<List<string>> GetYears()
        {
            return await db.GetYears();
        }
    }
}