using Glosolalia.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<TranslationRepository>
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
