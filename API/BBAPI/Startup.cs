
using Serilog;
using BBData.DB;
using BBAPI.Extensions;
using Microsoft.EntityFrameworkCore;
namespace BBAPI
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void RegisterServices(IServiceCollection services)
        {
            var databaseConnectionString = configRoot["DatabaseConnectionString"];
            services.AddDbContext<BookBorrowingDBContext>(options =>

               options.UseSqlServer(
                   databaseConnectionString
               ), ServiceLifetime.Scoped
           );
            services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
            });
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddControllers().AddNewtonsoftJson();

            services.ConfigureSwaggerAPI();
            services.ConfigureWrapper();
            
        }
        public void SetupMiddleware(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CORSPolicy");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseSerilogRequestLogging();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));
            app.Run();
        }
    }
}



