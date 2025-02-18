using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CWA.Models;
using Serilog;

namespace CWA.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Log different types of messages to test
        Log.Information("This is an informational message.");
        Log.Warning("This is a warning message.");
        Log.Error("This is an error message.");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
