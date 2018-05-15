using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace blogf.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var rootDir = new DirectoryInfo(@"c:\stuff\content");
            var fileInfos = rootDir.GetFiles("*.txt");
            var post = System.IO.File.ReadAllText(fileInfos.First().FullName);
            ViewData["post"] = post;
            return View();
        }
    }
}
