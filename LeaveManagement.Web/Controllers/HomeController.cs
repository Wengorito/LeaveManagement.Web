using LeaveManagement.Common.Models;
using LeaveManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LeaveManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, ApplicationDbContext context)
        {
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        public IActionResult Index()
        {
            var anythingFromDb = _context.LeaveTypes.Select(x => x.Name).ToList();
            var name = anythingFromDb.First();

            return View("Index", name);
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> ErrorAsync()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature != null)
            {
                var exception = exceptionHandlerPathFeature.Error;
                _logger.LogError(exception, $"Error encountered by user: {User?.Identity?.Name} | Request Id: {requestId}");

                await _emailSender.SendEmailAsync("hvitr.ulfr@gmail.com", $"Exception : {exception.ToString}", $"Details\n: " +
                $"{exception.Message}");
            }

            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}