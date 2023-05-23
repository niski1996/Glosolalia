using Glosolalia.Data;
using Glosolalia.Data.Contracts.Repository_Interface;
using Glosolalia.Data.Data_MockRepositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITranslationRepository, MockTranslationRepository>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{

    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();
app.UseSession();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
