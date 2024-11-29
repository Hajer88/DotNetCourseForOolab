using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProjectMVCForOolab.Models;
using FirstProjectMVCForOolab.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProjectMVCForOolab.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _db;
        public CustomerController(AppDbContext _db)
        {
            this._db = _db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            CustomersMoviesVM cs = new CustomersMoviesVM()
            {
                customers = _db.customers.ToList(),
                movies = _db.movies.ToList(),
            };
            return View(cs);
        }
        //seed data Customers
        private List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer(){Id=1, Name="Customer 1"},
                new Customer(){Id=2, Name="Customer 2"}
            };
            return customers;
        }
        //seed Data Movies
        private List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie(){Id=1, Name="Movie 1"},
                new Movie(){Id=2, Name="Movie 2"}
            };
            return movies;
        }
        //Get customer Details by Id
        //Source de données dynamique
        public IActionResult Details(int? id)
        {
            if(id==null)
            {
                return Content("Id not found");

            }            var customer = _db.customers
                .FirstOrDefault(c => c.Id == id);
            return View(customer);
        }
        //Récupérer les noms des clients et les memberships
        public IActionResult ListCustomers()
        {
            var c = _db.customers.Include(mem=>mem.membershiptype)
                .ToList();
            return View(c);
        }

        public IActionResult Create()
        {

            var members = _db.membershipTypes.ToList();

            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = "Memberships " + members.Id.ToString(),
                Value = members.Id.ToString()
            });




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Customer c)
        {

            if (!ModelState.IsValid)
            {
                var members = _db.membershipTypes.ToList();
                ViewBag.member = members.Select(members => new SelectListItem()
                {
                    Text = "Memberships " + members.Id.ToString(),

                    Value = members.Id.ToString()

                });
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View();
            }

            _db.customers.Add(c);
             _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


    }
}

