

using BBBusiness.Service;
using BBCommon.Repository;
using BBCommon.Service;
using BBData.Repository;
using Microsoft.OpenApi.Models;
using System.Text;


namespace BBAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureWrapper(this IServiceCollection services)
        {

            services.AddScoped<IBookBorrowingRepository, BookBorrowingRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IBookBorrowingService, BookBorrowingService>();
            
        }

        public static void ConfigureSwaggerAPI(this IServiceCollection services)
        {
            // Register the Swagger generator, defining one or more Swagger documents  
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Book Borrowing API",
                    Version = "v2",
                    Description = "Book Borrowing API",
                });
              
            });

        }
      
    }
}
