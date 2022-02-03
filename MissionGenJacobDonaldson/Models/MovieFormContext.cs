using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MissionGenJacobDonaldson.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base (options)
        {

        }
        public DbSet<FormResponse> Responses { get; set; }
        //connection new category model
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action" },
                new Category { CategoryId = 2, CategoryName = "SciFi" },
                new Category { CategoryId = 3, CategoryName = "Drama/History" }
                );
            mb.Entity<FormResponse>().HasData(

                new FormResponse
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "The Dark Night",
                    Year = 2008,
                    DirectorFirstName = "Christopher",
                    DirectorLastName = "Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Ches this is the best!",
                },
                new FormResponse
                {
                    MovieId = 2,
                    CategoryId = 2,
                    Title = "Star Wars Episode III: Revenge of the Sith",
                    Year = 2005,
                    DirectorFirstName = "George",
                    DirectorLastName = "Lucas",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "#r/prequelmemes for life",
                },
                new FormResponse
                {
                    MovieId = 3,
                    CategoryId = 3,
                    Title = "Valkyrie",
                    Year = 2008,
                    DirectorFirstName = "Bryan",
                    DirectorLastName = "Singer",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "WWII Conspiracy Plot",
                }
                );
                
        }
            
    }
}
