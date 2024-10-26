using FileStorage.Data;
using FileStorage.Infrastructure.Middlewares;
using FileStorage.Services;
using FileStorage.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



// регистрация БД
builder.Services.AddDbContext<Context>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"));


}

);

// сопоставление интерфейсов и реализаций
builder.Services.AddScoped<IFileExtentionService, FileExtentionService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFolderService, FolderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//обработка исключений
////builder.Services.Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
//    if (env.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();

//    }

//public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
//{
//    if (env.IsDevelopment())
//    {
//        app.UseDeveloperExceptionPage();
//        ...
//    }

app.UseApiExceptionHandling(); // обработка исключений

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
