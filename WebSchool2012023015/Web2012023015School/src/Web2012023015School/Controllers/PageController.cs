using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Web2012023015School.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web2012023015School.Controllers
{
    public class PageController : BaseController
    {
        // GET: /<controller>/
        [FromServices]
        public ArticleContext DB { get; set; }
        [HttpGet]
        public IActionResult News()
        {
            var latestnews = DB.News.OrderByDescending(x => x.Datatime).ToList();
            var recommendednews = DB.News.OrderBy(x => x.Priority).ThenByDescending(x => x.Datatime).Take(6).ToList();
            ViewBag.recommendednews = recommendednews;
            return PagedView(latestnews, 7);
        }
     
        [HttpGet]
        public IActionResult Article()
        {
            var article = DB.Article.OrderByDescending(x => x.Datatime).ToList();
            var recommendedarticle = DB.Article.OrderBy(x => x.Priority).ThenByDescending(x => x.Datatime).Take(6).ToList();
            ViewBag.recommendedarticle = recommendedarticle;
            return PagedView(article, 7);
        }
        
        [HttpGet]
        public IActionResult Inform()
        {
            return PagedView(DB.Inform, 7);
        }

        [HttpGet]
        public IActionResult Photos()
        {
            return PagedView(DB.Photos, 7);
        }

        [HttpGet]    
        public IActionResult RecruitStudents()
        {
            var recruit = DB.RecruitStudents.OrderByDescending(x=>x.Datatime).ToList();
            return PagedView(recruit, 10);
        }
        [HttpGet]
        public IActionResult Message()
        {
            var message = DB.Message.OrderByDescending(x => x.Datatime)
                .ToList();
            return PagedView(message,5);
        }
       
    }
}
