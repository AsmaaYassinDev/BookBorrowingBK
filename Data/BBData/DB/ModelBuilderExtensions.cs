
using BBData.Model;
using Microsoft.EntityFrameworkCore;



namespace BBData.DB
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id=1,
                    Title = "Techno Book1 ",
                    IsAvailable = true,
                    ISBN = "123435"

                },
                  new Book
                  {
                      Id = 2,
                      Title = "Techno Book2 ",
                      IsAvailable = true,
                      ISBN = "123345"

                  },
                    new Book
                    {
                        Id = 3,
                        Title = "Techno Book3 ",
                        IsAvailable = true,
                        ISBN = "123245"

                    }
            );
            modelBuilder.Entity<Country>().HasData(

                new Country { Id = 1, Name = "UEA", StartDay =DayOfWeek.Saturday, EndDay = DayOfWeek.Sunday},
                 new Country { Id = 2, Name = "Egypt", StartDay = DayOfWeek.Friday, EndDay = DayOfWeek.Saturday },
                new Country { Id = 3, Name = "India", StartDay = DayOfWeek.Saturday, EndDay = DayOfWeek.Sunday },
                new Country { Id = 4, Name = "UK", StartDay = DayOfWeek.Saturday, EndDay = DayOfWeek.Sunday }
                
            );
        }
    }
}