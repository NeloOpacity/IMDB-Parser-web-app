using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Additional_classes;
using System.Data.Entity;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        static Parser parser;
        static MovieContext db = new MovieContext();
        
        public ActionResult Index()
        {
            var ip = Request.UserHostAddress;
            ViewBag.Ip = ip;
            if (parser == null)
            {
                db.Movies.SqlQuery("DELETE FROM Movies WHERE Id>0");
                parser = new Parser();
                db.Movies.AddRange(parser.GetMovies(1));
                db.SaveChanges();
            }
            IEnumerable<Movie> movies = db.Movies;
            return View(movies);
        }
        public ActionResult Randomize()
        {
            return View();
        }
    }
}