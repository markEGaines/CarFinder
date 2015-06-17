using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarFinder.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Car> Cars { get; set; }


        public async Task<List<string>> GetYears()
        {
            return await this.Database.SqlQuery<string>("GetYears").ToListAsync();
        }

        public async Task<List<string>> GetMakes(string year)
        {
            var yearParam = new SqlParameter("@year", year);
            return await this.Database.SqlQuery<string>("GetMakes @year", yearParam).ToListAsync();
        }

        public async Task<List<string>> GetModels(string year, string make)
        {
            var yearParam = new SqlParameter("@year", year);
            var makeParam = new SqlParameter("@make", make);
            return await this.Database.SqlQuery<string>("GetModels @year, @make", yearParam, makeParam).ToListAsync();
        }

        public async Task<List<string>> GetTrims(string year, string make, string model)
        {
            var yearParam = new SqlParameter("@year", year);
            var makeParam = new SqlParameter("@make", make);
            var modelParam = new SqlParameter("@model", model);
            return await this.Database.SqlQuery<string>("GetTrims @year, @make, @model", yearParam, makeParam, modelParam).ToListAsync();
        }

        public async Task<List<Car>> GetCars(string year, string make, string model, string trim, string filter, bool paging, int page, int perPage)
        {
            var yearParam = new SqlParameter("@year", year);
            var makeParam = new SqlParameter("@make", make);
            var modelParam = new SqlParameter("@model", model);
            var trimParam = new SqlParameter("@trim", trim);
            var filterParam = new SqlParameter("@filter", filter);
            var pagingParam = new SqlParameter("@paging", paging);
            var pageParam = new SqlParameter("@page", page);
            var perpageParam = new SqlParameter("@perPage", perPage);

            return await this.Database.SqlQuery<Car>("GetCars @year, @make, @model, @trim, @filter, @paging, @page, @perPage", yearParam, makeParam, modelParam, trimParam, filterParam, pagingParam, pageParam, perpageParam).ToListAsync();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public async Task<int> GetCarsCount(string year, string make, string model, string trim, string filter)
        {
            var yearParam = new SqlParameter("@year", year);
            var makeParam = new SqlParameter("@make", make);
            var modelParam = new SqlParameter("@model", model);
            var trimParam = new SqlParameter("@trim", trim);
            var filterParam = new SqlParameter("@filter", filter);

            return await this.Database.SqlQuery<int>("GetCarsCount @year, @make, @model, @trim, @filter", yearParam, makeParam, modelParam, trimParam, filterParam).FirstAsync();
        
        }
    }
}