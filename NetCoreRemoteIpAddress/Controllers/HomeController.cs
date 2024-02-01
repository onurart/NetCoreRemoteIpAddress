using Microsoft.AspNetCore.Mvc;
using NetCoreRemoteIpAddress.Models;
using System.Diagnostics;

namespace NetCoreRemoteIpAddress.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LogService _logService;

        public HomeController(ILogger<HomeController> logger, LogService logService = null)
        {
            _logger = logger;
            _logService = logService;
        }

        public IActionResult Index()
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            ViewBag.UserIPAddress = ipAddress;

            // Kullanıcı girişi logunu kaydet
            _logService.LogUserEntry(ipAddress);

            return View();
        }
        public IActionResult UserEntries()
        {
            // Tüm kullanıcı giriş kayıtlarını al
            var entries = _logService.GetUserEntries();

            return View(entries);
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
}
