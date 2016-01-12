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
        public IActionResult Inform(int id)
        {
            var inform = DB.Inform.Where(x => x.Id == id).SingleOrDefault();
            var others = DB.Inform.Where(x => x.Id != id).OrderByDescending(x => x.Datatime).ToList();
            ViewBag.others = others;
            return View(inform);
        }
        public IActionResult News(int id)
        {
            var news = DB.News.Where(x => x.Id == id).SingleOrDefault();
            var latestnews = DB.News.OrderByDescending(x => x.Datatime).Take(6).ToList();
            var hotnews = DB.News.OrderBy(x => x.Id).Take(6).ToList();
            var recommendednews = DB.News.OrderBy(x => x.Priority).ThenByDescending(x=>x.Datatime).Take(6).ToList();
            ViewBag.latestnews = latestnews;
            ViewBag.hotnews = hotnews;
            ViewBag.recommendednews = recommendednews;
            return View(news);
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
