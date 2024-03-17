using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Semana1_DPWA.Data;
using Semana1_DPWA.Models;

namespace Semana1_DPWA.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Semana1_DPWA.Data.Semana1_DPWAContext _context;

        public IndexModel(Semana1_DPWA.Data.Semana1_DPWAContext context)
        {
            _context = context;
        }

        public IList<Pelicula> Pelicula { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }
        public async Task OnGetAsync()

            
        {
            IQueryable<string> genreQuery = from m in _context.Pelicula
                                            orderby m.Genre
                                            select m.Genre;
            var peliculas = from m in _context.Pelicula
                            select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                peliculas = peliculas.Where(s => s.Title.Contains(SearchString));

            }
            if(!string.IsNullOrEmpty(MovieGenre))
            {
                peliculas = peliculas.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Pelicula = await peliculas.ToListAsync();
        }
    }
}
