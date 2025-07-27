using MudBlazor.Services;
using Kairos.BlazorApp.Components;
using Serilog;
using Serilog.Events;
using Microsoft.EntityFrameworkCore;
using Kairos.BlazorApp;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();

builder.Services.AddRazorComponents() .AddInteractiveServerComponents();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Host.ConfigureHostOptions(option =>
{
    option.ShutdownTimeout = TimeSpan.FromSeconds(1);
});

builder.Services.AddDbContext<KairosDbContext>(options => options.UseSqlite("Data Source=kairos.db"));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddDefaultUI()
.AddEntityFrameworkStores<KairosDbContext>();

builder.Services.AddScoped<IAuthHelper, AuthHelper>();
builder.Services.AddScoped<IReminderRepository, ReminderRepositoryMock>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<KairosDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorPages();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

Log.Logger.Information("Starting host");

app.Run();
