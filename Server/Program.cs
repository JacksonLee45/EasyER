using Duende.IdentityServer.Models;
using EasyER.Server.Data;
using EasyER.Server.Models;
using EasyER.Server.Repositories;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//This is from the Dy lol - get the git version working asap

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// -- Added Patient Context
builder.Services.AddDbContext<PatientContext>(options =>
    options.UseSqlServer(connectionString));

//-- Added Scopped Patient Stuff
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientContext, PatientContext>();

//--Added Nurse Context
builder.Services.AddDbContext<NurseContext>(options =>
    options.UseSqlServer(connectionString));

//-- Added Scopped Nurse Stuff
builder.Services.AddScoped<INurseRepository, NurseRepository>();
builder.Services.AddScoped<INurseContext, NurseContext>();


//--Added Doctor Context
builder.Services.AddDbContext<DoctorContext>(options =>
    options.UseSqlServer(connectionString));

//--Added Scoped Doctor Stuff
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorContext, DoctorContext>();



builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
  options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() //Added this -- needed for UserController RoleManager and UserManager
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
    {
        options.IdentityResources.Add(new IdentityResource("roles", "Roles", new[] { JwtClaimTypes.Role, JwtClaimTypes.Role }));
        foreach (var c in options.Clients)
        {
            c.AllowedScopes.Add("roles");
        }
        foreach (var a in options.ApiResources)
        {
            a.UserClaims.Add(JwtClaimTypes.Role);
        }
    });

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

//-- Added this too
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
        policy.RequireClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
