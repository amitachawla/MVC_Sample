using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleData;

namespace MVC_Sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BookViewModel vm = new BookViewModel();
            vm.HandleRequest();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(BookViewModel vm)
        {
            vm.IsValid = ModelState.IsValid;
            vm.HandleRequest();

            if(vm.IsValid)
            {
                ModelState.Clear();
            }
            else
            {
                foreach(KeyValuePair<string, string> item in vm.ValidationErrors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
            }
            
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}