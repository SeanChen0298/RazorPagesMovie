using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();  //Redirects HTTP request to HTTPS.
app.UseStaticFiles();       //Enable static files to be served. (HTML, CSS, Javascript)

app.UseRouting();           //Add route matching to the middleware pipeline.

app.UseAuthorization();     //Authorizes a user to access secure resources.

app.MapRazorPages();        //Configures endpoint routing for Razor Pages.

app.Run();
