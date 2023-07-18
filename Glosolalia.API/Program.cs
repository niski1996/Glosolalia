using Glosolalia.Data;
using Glosolalia.Data.Data_MockRepositories;
using Glosolalia.Data.Repository_Interface;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsDevelopment())
{
    //builder.Configuration.AddUserSecrets<Program>();
}


// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(o =>
{
    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

builder.Services.AddDbContext<GlosolaliaContext>();
builder.Services.AddScoped<ISheetRepository, SheetRepository>();
builder.Services.AddScoped<ITranslationRepository, TranslationRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
