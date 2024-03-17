using Microsoft.EntityFrameworkCore;
using Semana1_DPWA.Data;
using Semana1_DPWA.Models;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Semana1_DPWAContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<Semana1_DPWAContext>>()))
        {
            if (context == null || context.Pelicula == null)
            {
                throw new ArgumentNullException("Null Semana1_DPWAContext");
            }

            // Look for any movies.
            if (context.Pelicula.Any())
            {
                return;   // DB has been seeded
            }

            context.Pelicula.AddRange(
                new Pelicula
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "R"
                },

                new Pelicula
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "R"

                },

                new Pelicula
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "R"

                },

                new Pelicula
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "R"


                }
            );
            context.SaveChanges();
        }
    }
}