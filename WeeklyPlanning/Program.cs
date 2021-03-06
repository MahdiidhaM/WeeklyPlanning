using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeeklyPlanning.Areas.Identity.Data;
using WeeklyPlanning.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WeeklyPlanningContextConnection");builder.Services.AddDbContext<WeeklyPlanningContext>(options =>
    options.UseSqlServer(connectionString));builder.Services.AddDefaultIdentity<WeeklyPlanningUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WeeklyPlanningContext>();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
