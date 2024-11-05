using FileStorage.Data;
using FileStorage.Infrastructure.Middlewares;
using FileStorage.Infrastructure.Swagger;
using FileStorage.Services;
using FileStorage.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);


// add swagger
#region SWAGGER

builder.Services.AddApiVersioning(options =>
{
    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
    options.ReportApiVersions = true;
}).AddApiExplorer(options =>
{
    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
    // note: the specified format code will format the version as "'v'major[.minor][-status]"
    options.GroupNameFormat = "'v'VVV";

    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
    // can also be used to control the format of the API version in route templates
    options.SubstituteApiVersionInUrl = true;
});


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    // add a custom operation filter which sets default values
    options.OperationFilter<SwaggerDefaultValues>();
});



#endregion


// Логирование Serilog

IHostBuilder host = builder.Host
    .ConfigureDefaults(args).UseSerilog((hostingContext, loggerConfiguration) =>
                    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
                        .Enrich.FromLogContext());




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

#region SWAGGER


app.UseSwagger(options => { options.RouteTemplate = "api-docs/{documentName}/docs.json"; });
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = "api-docs";
        var descriptions = app.DescribeApiVersions();
        foreach (var description in descriptions)
        {
            var url = $"/api-docs/{description.GroupName}/docs.json"; //$"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });


// в инструкции микрософт
if (builder.Environment.IsDevelopment())
{

}
#endregion




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}






//обработка исключений
//builder.Services.Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
//if (env.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();

//}

//public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
//{
//    if (env.IsDevelopment())
//    {
//        app.UseDeveloperExceptionPage();
//        ...
//    }

app.UseApiExceptionHandling(); // для обработки исключений

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
