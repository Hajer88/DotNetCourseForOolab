using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProjectMVCForOolab.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProjectMVCForOolab.Controllers
{
    public class MovieController : Controller
    {
        // GET: /<controller>/
        //Déclarer des champs Movie (statique) et les passer à la vue

        private readonly AppDbContext _db;
        public MovieController(AppDbContext _db)
        {
            this._db = _db;
        }


        public IActionResult Index()
        {
           
            //Lister tous les films
            return View(_db.movies.ToList());
        }
        //Créer un nouveau film
        //Get 
        public IActionResult Create()
        {
            return View();
        }
        //Create POST
        [ValidateAntiForgeryToken]
        [HttpPost]
         public IActionResult Create(Movie movie)
        {

            //if(ModelState.isValid)
            _db.movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

