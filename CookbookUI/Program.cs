using Microsoft.EntityFrameworkCore;
using CookbookDataAccess.DataAccess;
using CookbookLogic;
using CookbookLogic.Services;
using CookbookDataAccess.Persistence;
using CookbookLogic.Dto;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RecipeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddTransient<RecipesService>();
builder.Services.AddTransient<IngredientTabsService>();
builder.Services.AddScoped<RecipesRepository>();
builder.Services.AddScoped<IngredientTabsRepository>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
