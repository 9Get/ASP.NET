using LR3.controllers;
using LR3.interfaces;
using System;

namespace LR3
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddTransient<CalcService>();
			builder.Services.AddTransient<IDayTimeService, DayTimeServise>();

			var app = builder.Build();

			app.MapGet("/daytime", async context =>
			{
				var dayTimeService = app.Services.GetService<DayTimeServise>();

				DateTime dateTime = DateTime.Now;

				await context.Response.WriteAsync($"Current time of the day: {dayTimeService?.GetDayTime(dateTime)}\n");
			});

			app.MapGet("/", async context =>
			{
				var calcService = app.Services.GetService<CalcService>();

				await context.Response.WriteAsync($"Result of addition: {calcService?.Add(1, 2, 3, 4, 5, 6, 7, 8, 9)}\n");
				await context.Response.WriteAsync($"Result of multiplication: {calcService?.Product(1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f)}\n");
				await context.Response.WriteAsync($"Result of subtraction: {calcService?.Substract(1, 2, 3, 4, 5, 6, 7, 8, 9)}\n");
				await context.Response.WriteAsync($"Result of division: {calcService?.Divide(1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0)}\n");
			});

			app.Run();
		}
	}
}
