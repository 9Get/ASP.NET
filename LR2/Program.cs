using LR2.Entities;
using Microsoft.Extensions.Options;
using System;

namespace LR2
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Configuration
				.AddJsonFile("user.json")
				.AddJsonFile("config.json")
				.AddXmlFile("config.xml")
				.AddIniFile("config.ini");

			builder.Services.Configure<User>(builder.Configuration);

			var app = builder.Build();

			app.MapGet("/user/", (IConfiguration appConfig) => {
				var user = appConfig.Get<User>();

				return user?.ToString();
			});

			app.MapGet("/company/", (IConfiguration appConfig) => {
				int microsoftEmployees = appConfig.GetValue<int>("Microsoft:Employees");
				int appleEmployees = appConfig.GetValue<int>("Apple:Employees");
				int googleEmployees = appConfig.GetValue<int>("Google:Employees");

				if (microsoftEmployees > appleEmployees && microsoftEmployees > googleEmployees)
				{
					return $"Microsoft: {microsoftEmployees}";
				}
				if (appleEmployees > googleEmployees)
				{
					return $"Apple: {appleEmployees}";
				}
				return $"Google: {googleEmployees}";
			});

			app.Run();
		}
	}
}
