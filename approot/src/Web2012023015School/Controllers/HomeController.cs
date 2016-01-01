using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Web2012023015School.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web2012023015School.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Manage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DetailsMessage()
        {
            return PagedView(DB.Message.ToList(),15);
        }
        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            message.State = State.未通过;
            message.Datatime = DateTime.Now;
            DB.Message.Add(message);
            DB.SaveChanges();
            return RedirectToAction("Message", "Page");
        }
        public IActionResult DeleteMessage(int id)
        {
            var message = DB.Message.Where(x => x.Id == id).SingleOrDefault();
            DB.Message.Remove(message);
            DB.SaveChanges();
            System.Diagnostics.Debug.Write("id=" + id);
            return RedirectToAction("DetailsMessage", "Home");
        }
        public IActionResult AgreeMessage(int id)
        {
            var message = DB.Message.Where(x => x.Id == id).SingleOrDefault();
            message.State = State.通过;
            DB.SaveChanges();
            return RedirectToAction("DetailsMessage", "Home");
        }
    }
}
