using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Semana1_DPWA.Data;
using Semana1_DPWA.Models;

namespace Semana1_DPWA.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly Semana1_DPWA.Data.Semana1_DPWAContext _context;

        public CreateModel(Semana1_DPWA.Data.Semana1_DPWAContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pelicula Pelicula { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Pelicula == null || Pelicula == null)
            {
                return Page();
            }

            _context.Pelicula.Add(Pelicula);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
