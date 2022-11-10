using HelloMvc.Data;
using HelloMvc.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddSingleton<IEmployeeRepo, EmployeeInMemoryRepo>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();

var connectionString = builder.Configuration.GetConnectionString("EmployeeDbConnection");

builder.Services.AddDbContext<EmployeeContext>((opt) => {
    opt.UseSqlServer(connectionString);
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Home/Index/3

//2006/01/23

app.MapControllerRoute(
    name: "blog",
    pattern: "{year:length(4)}/{month:int}/{day:int}",
    defaults: new { controller = "Blog", action = "Index" });

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
