using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("MoviesConnection") { }
        public DbSet<Movie> Movies { get; set; }
    }
}