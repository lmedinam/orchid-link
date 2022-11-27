using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using OrchidLink.Areas.Identity;
using OrchidLink.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connectionString)
);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<OrchidLink.Models.User>(
    options => options.SignIn.RequireConfirmedAccount = false
).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();

    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

        if (context == null)
        {
            throw new NullReferenceException("Cannot get ApplicationDbContext");
        }

        context.Database.EnsureCreated();

        var user = context.Users.FirstOrDefault();
        if (user == null)
        {
            var newUser = new OrchidLink.Models.User
            {
                Id = Guid.NewGuid().ToString(),
                Name = "John Doe",
                UserName = "demo@user.com",
                NormalizedUserName = "DEMO@USER.COM"
            };

            var hasher = new PasswordHasher<OrchidLink.Models.User>();
            newUser.PasswordHash = hasher.HashPassword(newUser, "secret");

            context.Users.Add(newUser);
            context.SaveChanges();
        }
    }
}
else
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

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
