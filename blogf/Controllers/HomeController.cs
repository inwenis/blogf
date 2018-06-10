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
            var posts = fileInfos.Select(x => System.IO.File.ReadAllText(x.FullName));
            ViewData["posts"] = posts;
            return View();
        }
    }
}
