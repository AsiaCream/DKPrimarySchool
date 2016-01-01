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
            return PagedView(DB.News, 7);
        }
        
        [HttpGet]
        public IActionResult Article()
        {
            return PagedView(DB.Article, 7);
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
            return PagedView(DB.RecruitStudents, 7);
        }
        [HttpGet]
        public IActionResult Message()
        {
            var message = DB.Message.OrderByDescending(x => x.Datatime)
                .ToList();
            return PagedView(message,15);
        }
       
    }
}
