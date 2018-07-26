using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorDemo.Models;

namespace RazorDemo.Pages.MoviePage
{
    public class IndexModel : PageModel
    {
        private readonly RazorDemo.Models.MovieContext _context;

        public IndexModel(RazorDemo.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        public SelectList Genres { get; set; }
        public string MovieGenere { get; set; }

        public async Task OnGetAsync(string movieGenre,string searchString)
        {
            IQueryable<string> genreQeury = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if(!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            Genres = new SelectList(await genreQeury.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();

        }
    }
}
