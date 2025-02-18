using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog (Logging setup)
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()                           // Logs to the console
    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)  // Logs to a file with daily rolling
    .CreateLogger();

// Set up Serilog as the logging provider
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

// Ensure all logs are flushed before the app exits
Log.CloseAndFlush();