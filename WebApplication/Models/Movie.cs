using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace WebApplication.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public string Href { get; set; }
    }
}