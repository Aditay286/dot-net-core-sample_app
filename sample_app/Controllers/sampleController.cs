


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sample_app.Controllers
{
    public class sampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name,int numbers)
        {
            //    if (numbers == 0)
            //      numbers = 1;

          //  return HtmlEncoder.Default.Encode($"name={name} numbers={numbers}");

            ViewData["name"] = "Hello " + name;
            ViewData["numbers"] = numbers;
            return View();
        }
    }
}