using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Study.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Study.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ProductService _productService;

        public FirstController(ILogger<FirstController> logger, IWebHostEnvironment env, ProductService productService)
        {
            _logger = logger;
            _env = env;
            _productService = productService;
        }

        // GET: /<controller>/
        public string Index()
        {
            //this.HttpContext
            //this.Request
            //this.Response
            //this.RouteData

            //this.User
            //this.ModelState
            //this.ViewBag
            //this.ViewData
            //this.Url
            //this.TempData
            _logger.LogInformation("hello world");
            return "abc12 dasdas";
        }

        public string hiFirst() => "abc";
        // GET: /<controller>/

        public void noThing()
        {
            _logger.LogInformation("Nothing action");
            Response.Headers.Add("abc", "hello anh em");
        }

        public IActionResult Avatar()
        {
            string contentRootPath = _env.ContentRootPath;
            string filePath = Path.Combine(contentRootPath, "Files", "avatar.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/jpg");
        }

        public LocalRedirectResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("redicect local ");
            return LocalRedirect(url!);
        }

        public RedirectResult Google()
        {
            var url = "https://www.facebook.com/profile.php?id=100009235474057";
            _logger.LogInformation("redicect facebook ");
            return Redirect(url!);
        }

        public IActionResult helloView(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = "bear";
            }
            return View("index", username);
        }

        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Find(p => p.Id == id);
           
            if(product == null)
            {
                TempData["thongbao"] = "San pham ko co";
                return Redirect(Url.Action("Index", "Home")!);
            }
            _logger.LogInformation(product.ToString());

            this.ViewData["text"] = "anh bao dep trai";
            this.ViewData["Title"] = product.Name;

            ViewBag.year = "2023";

            return View(product);
        }

    }
}

