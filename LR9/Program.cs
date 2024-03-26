namespace LR9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "",
                defaults: new { controller = "Main", action = "AddProduct" }
            );

            ProductRepository.init();

            app.Run();
        }
    }
}
