namespace LR11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMvc(options =>
            {
                options.Filters.Add(typeof(LogActionFilterAttribute));
                options.Filters.Add(typeof(UniqueUsersFilterAttribute));
            });
            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "",
                defaults: new { controller = "Home", action = "Index" });

            app.Run();
        }
    }
}
