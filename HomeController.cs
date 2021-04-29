using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishBooster
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Table> r;
            using (var s= new Studententities())
            {
                r = s.dataSiswa.ToList();
            }
            return View(r);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var model = new Table();
            TryUpdateModelAsync(model);
            using (var s = new Studententities())
            {
                s.Table.Add(model);
                s.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
