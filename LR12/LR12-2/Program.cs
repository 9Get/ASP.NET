using Microsoft.EntityFrameworkCore;

namespace LR12_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

            var app = builder.Build();

            app.MapGet("/", (ApplicationContext db) => db.Companies.ToList());

            app.Run();
        }
    }
}
