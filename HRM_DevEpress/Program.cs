using HRM.Web.Entities;
using HRM_DevEpress.Infrastructor.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using HRM_DevEpress.Common;
using HRM_DevEpress.Infrastructor.Service;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Thêm thuộc tính này khi trả về json sẽ giữ nguyên field
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// AutoMapper

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);


// DI
builder.Services.AddScoped<IPhongBanRepository, PhongBanRepository>();
builder.Services.AddScoped<IUserService, PhongBanService>();

builder.Services.AddScoped<IChucVuRepository, ChucVuRepository>();
builder.Services.AddScoped<IChucVuService, ChucVuService>();

builder.Services.AddScoped<INhanVienRepository, NhanVienRepository>();
builder.Services.AddScoped<INhanVienService, NhanVienService>();




// Add services to the container.
builder.Services.AddControllersWithViews();

//Add ConnetionString
builder.Services.AddDbContext<HrmTestContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));

//Add Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();



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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
