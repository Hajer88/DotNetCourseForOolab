using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProjectMVCForOolab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

            //Lister tous les films avec les genres associés
            return View(_db.movies
                .Include(c=>c.genre).ToList()); ;
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
        public async Task<IActionResult> Index2()
        {
            var c=  await _db.movies.ToListAsync();

            return View(c);
        }
        public async Task<IActionResult> details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var movie = _db.movies.FirstOrDefaultAsync(
                f => f.Id == id);
            if(movie==null)
            {
                return NotFound();

            }
            return View(movie);
        }
        //GET
        public async Task<IActionResult> Edit(int? id)
        {
            var movie = await _db.movies
                .FindAsync(id);
            ViewData["GenreId"] = new SelectList(_db.genres, "GenreId", "GenreId", movie.GenreId);
            return View(movie);
        }
        //POST => instructions pour Edit POST
        //if(ModelState.IsValid)
        //{_db.Update(movie);
        //await _db.SaveChangesAsync();}

        //Ecrire un service qui permet de
        //lister tous les films associés à un genre
        public IActionResult GetMoviesByGenre(string name)
        {
            var movies = _db.movies
                .Where(c => c.genre.genre == name)
                .OrderByDescending(c=>c.Name)
                .ToList();
               
            return View(movies);

        }
    }
}

