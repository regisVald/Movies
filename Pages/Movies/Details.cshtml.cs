using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Semana1_DPWA.Data;
using Semana1_DPWA.Models;

namespace Semana1_DPWA.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly Semana1_DPWA.Data.Semana1_DPWAContext _context;

        public DetailsModel(Semana1_DPWA.Data.Semana1_DPWAContext context)
        {
            _context = context;
        }

      public Pelicula Pelicula { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pelicula == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Pelicula.FirstOrDefaultAsync(m => m.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }
            else 
            {
                Pelicula = pelicula;
            }
            return Page();
        }
    }
}
