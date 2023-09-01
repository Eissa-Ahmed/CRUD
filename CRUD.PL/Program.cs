using CRUD.BL.Interfaces;
using CRUD.BL.Mapper;
using CRUD.BL.Repository;
using CRUD.DAL.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Dependices Injection
//AddScoped 
builder.Services.AddScoped<IDepartment, DepartmentRepo>();
builder.Services.AddScoped<IEmployee, EmployeeRepo>();

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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

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
