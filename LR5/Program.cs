using System;
using System.IO;

namespace LR5
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var app = builder.Build();

			app.Run(async (context) =>
			{
				context.Response.ContentType = "text/html; charset=utf-8";

				try
				{
					if (context.Request.Path == "/check-cookies")
					{
						var form = context.Request.Form;
						var name = form["name"];
						var cookiesLifespan = form["cookies-lifespan"];

						if (context.Request.Cookies.ContainsKey("name"))
						{
							await context.Response.WriteAsync($"Hello {context.Request.Cookies["name"]}!");
						}
						else
						{
							context.Response.Cookies.Append("name", name, new CookieOptions
							{
								Expires = Convert.ToDateTime(cookiesLifespan)
							});

							await context.Response.WriteAsync("Hello World!");
						}
					}
					else
					{
						await context.Response.SendFileAsync("html/index.html");
					}
				}
				catch (InvalidOperationException ex)
				{
					var path = context.Request.Path;
					app.Logger.LogError($"LogError {path} | {ex.Message} | {ex.Data} | {ex.Source}");
				}
			});

			app.Run();
		}
	}
}
