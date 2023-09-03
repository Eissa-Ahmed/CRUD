using CRUD.BL.Interfaces;
using CRUD.BL.Mapper;
using CRUD.BL.Repository;
using CRUD.DAL.Database;
using CRUD.PL.Language;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
}).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
.AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (type, factory) =>
        factory.Create(typeof(UsResource));
});

#region Dependices Injection
//AddScoped 
builder.Services.AddScoped<IDepartment, DepartmentRepo>();
builder.Services.AddScoped<IEmployee, EmployeeRepo>();
builder.Services.AddScoped<ICountry, CountryRepo>();
builder.Services.AddScoped<ICity, CityRepo>();
builder.Services.AddScoped<IDistrict, DistrictRepo>();

#endregion

#region Connection
var ConnectionString = builder.Configuration.GetConnectionString("ApplicationConnection");
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(ConnectionString));
#endregion

//Auto Mapper
builder.Services.AddAutoMapper(m => m.AddProfile(new DomainProfile()));
//Session
builder.Services.AddSession();
builder.Services.AddMemoryCache();




var app = builder.Build();
var supportedCultures = new[] {
                      new CultureInfo("ar-EG"),
                      new CultureInfo("en-US"),
                };

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>
                {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
                }
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Session
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
