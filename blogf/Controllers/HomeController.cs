using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace blogf.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var message = DateTimeOffset.UtcNow.ToString("O") + " : someone just requested the blog\n";
            var headers = HttpContext.Request.Headers;
            var headersAsString = headers.Select(x => x.Key + " " + x.Value);

            var logFilePath = @"c:\stuff\the_only_log_file.txt";
            if (!System.IO.File.Exists(logFilePath))
            {
                var fileStream = System.IO.File.Create(logFilePath);
                fileStream.Dispose();
            }

            System.IO.File.AppendAllText(logFilePath, message);
            System.IO.File.AppendAllLines(logFilePath, headersAsString);

            var rootDir = new DirectoryInfo(@"c:\stuff\content");
            var fileInfos = rootDir.GetFiles("*.txt");
            var posts = fileInfos.Select(x => System.IO.File.ReadAllText(x.FullName));
            ViewData["posts"] = posts;
            return View();
        }
    }
}
