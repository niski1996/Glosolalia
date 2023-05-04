using Glosolalia.Data;
using Glosolalia.Data.Contracts.Repository_Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEnWordRepository, EnWordRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())

{
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
