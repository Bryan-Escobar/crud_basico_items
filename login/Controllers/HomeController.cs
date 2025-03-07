using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using login.Models;

using System;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
namespace login.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult MyPage()
    {
        return View();
    }
    public IActionResult Index()
    {
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
    public IActionResult SendEmail()
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Bryan", "steven.escobarpreza@gmail.com"));

        // Add multiple recipients
        var recipients = new List<MailboxAddress>
        {
            new MailboxAddress("yo tambien", "steven.escobarpreza@gmail.com"),
            new MailboxAddress("kebin", "kevrodriguezblog@gmail.com")
        };
        message.To.AddRange(recipients);

        message.Subject = "Perdio acceso a su netxlif";

        message.Body = new TextPart("plain")
        {
            Text = @"Hey kevin,

   Pasame sus credenciales de tu netflix

    -- Joey"
        };

        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 587, false);

            // Note: only needed if the SMTP server requires authentication
            client.Authenticate("steven.escobarpreza@gmail.com", "miqp kkue pity nyny");

            client.Send(message);
            client.Disconnect(true);
        }
        return RedirectToAction("Index", "Home");
    }
}
