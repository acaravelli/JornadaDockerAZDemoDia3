using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Reflection;
using System.Runtime.Versioning;

using InfoEnvWebApp.Models;
using Microsoft.Extensions.Configuration;

namespace InfoEnvWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        public IActionResult Index()
        {

            return View(new Info() {

                OSVersion = System.Environment.OSVersion.ToString(),
                FrameworkVersion = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName,
                Data = DateTime.Now,
                VariavelDeAmbienteManual = System.Environment.GetEnvironmentVariable("INFO_VAR"),
                VariavelDeAmbienteConfiguration = configuration.GetSection("Teste").GetValue<string>("Complex")

            });
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

    public class Info
    {
        public string OSVersion { get; internal set; }
        public string FrameworkVersion { get; internal set; }
        public DateTime Data { get; internal set; }
        public string VariavelDeAmbienteManual { get; internal set; }
        public string VariavelDeAmbienteConfiguration { get; internal set; }
    }

}
