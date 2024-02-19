using LR4.entities;
using LR4.interfaces;
using LR4.services;
using System.Text;
using System.Text.Json;

namespace LR4
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddSingleton<IBooksService, BooksService>();
			builder.Services.AddSingleton<IUsersService, UsersService>();

			var app = builder.Build();

			app.Map("/", (IEnumerable<EndpointDataSource> endpointDataSources) =>
				string.Join("\n", endpointDataSources.SelectMany(source => source.Endpoints)));
			app.Map("/Library", () => "Hello reader");
			app.Map("/Library/Books", (IBooksService booksService) => $"Books:\n{booksService.GetBooks()}");
			app.Map("/Library/Profile", (IUsersService usersService) => $"Info:\n{usersService.GetCurrentUser()}");
			app.Map("/Library/Profile/{id}", (int id, IUsersService usersService) => $"{usersService.GetUserByID(id)}");

			app.Run();
		}
	}
}
