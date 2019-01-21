using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebApplication.Models;
using AngleSharp;
using AngleSharp.Html.Parser;
using System.Text;

namespace WebApplication.Additional_classes
{
    /// <summary>
    /// Parses IMDB Random Movies pages to the list of movies
    /// </summary>
    public class Parser
    {
        string[] server_input;
        byte[] byte_input = new byte[1024];
        int pages;
        public List<Movie> GetMovies(int _pages)
        {
            Random random = new Random();
            int firstPage = random.Next(1, 6);
            server_input = new string[_pages];
            pages = _pages + firstPage;
            List<Movie> movies = new List<Movie>();
            string URL;
            WebClient web = new WebClient();
            for (int j = firstPage, i = 0; j < pages; j++, i++)
            {
                URL = "https://www.imdb.com/list/ls009796553/?sort=list_order,asc&st_dt=&mode=detail&page=" + j;
                server_input[i] = web.DownloadString(URL);
                byte_input = Encoding.Default.GetBytes(server_input[i]);
                server_input[i] = Encoding.UTF8.GetString(byte_input);
            }

            for (int j = firstPage, i = 0; j < pages; j++, i++)
            {
                HtmlParser html = new HtmlParser();
                var dom = html.ParseDocument(server_input[i]);
                var elements = dom.QuerySelectorAll(".lister-item-content");
                foreach (var item in elements)
                {
                    string name = item.QuerySelector("div.lister-item-content > h3 > a").TextContent;
                    string stringsInBrackets = item.QuerySelector("span.lister-item-year.text-muted.unbold").TextContent;
                    string year;
                    string[] strs = stringsInBrackets.Split(new[] { ") (" }, StringSplitOptions.RemoveEmptyEntries);
                    year = strs[strs.Length - 1].Trim(new[] { '(', ')' });
                    string description = item.QuerySelector("p:nth-child(5)").TextContent;
                    movies.Add(new Movie { Name = name, Year = year, Description = description });
                }
            }
            return movies;
        }

    }
}