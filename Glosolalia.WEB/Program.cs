var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<>
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
