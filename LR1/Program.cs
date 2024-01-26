using LR1.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Company company = new Company();
Random random = new Random();

app.Run(async (context) =>
{
	company.BranchesNumber += 2;
	await context.Response.WriteAsync(company.ToString());

	await context.Response.WriteAsync($"Random value: {random.Next(0, 101)}");
});

app.Run();
