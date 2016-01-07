using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Web2012023015School.Models;

namespace Web2012023015School.Controllers
{
    public class ShowController : BaseController
    {
        [FromServices]
        public ArticleContext DB { get; set; }
        // GET: /<controller>/
        public IActionResult Article(int id)
        {
            var article = DB.Article.Where(x=>x.Id==id).SingleOrDefault();          
            return View(article);
        }
        public IActionResult Inform()
        {
            return View();
        }
        public IActionResult News()
        {
            return View();
        }
        public IActionResult Photes()
        {
            return View();
        }
        public IActionResult RecruitStudents()
        {
            return View();
        }
    }
}
