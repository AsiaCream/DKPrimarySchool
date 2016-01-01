using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Web2012023015School.Models;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web2012023015School.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        [FromServices]
        public ArticleContext DB { get; set; }
        //文章，新闻，....管理模块

        //通知公告(增删改查)----------------------------
        [HttpGet]
        public IActionResult DetailsInform()
        {
            return PagedView(DB.Inform, 10);
        }

        //渲染添加通知公告页面
        [HttpGet]
        public IActionResult CreateInform()
        {
            return View();
        }

        //处理添加通知公告请求
        [HttpPost]
        public IActionResult CreateInform(Inform inform)
        {
            DB.Inform.Add(inform);
            DB.SaveChanges();
            return RedirectToAction("DetailsInform", "Admin");

        }

        //渲染编辑页面
        [HttpGet]
        public IActionResult EditInform(int id)
        {
            var inform = DB.Inform
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (inform == null)
                return Content("没有此记录！");
            else
                return View(inform);
        }

        //处理编辑通知公告请求
        [HttpPost]
        public IActionResult EditInform(int id, Inform inform)
        {
            var n = DB.Inform
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (n == null)
                return Content("没有该记录！");
            n.Title =inform.Title;
            n.Content = inform.Content;
            n.Datatime = inform.Datatime;
            DB.SaveChanges();
            return RedirectToAction("DetailsInform", "Admin");

        }

        // 删除通知公告
        public IActionResult DeleteInform(int id)
        {
            var inform = DB.Inform
                .Where(x => x.Id == id)
                .SingleOrDefault();
            DB.Inform.Remove(inform);
            DB.SaveChanges();
            System.Diagnostics.Debug.Write("id=" + id);
            return RedirectToAction("DetailsInform", "Admin");
        }

        //新闻版（增删改查）----------------------------

        //分页
        [HttpGet]
        public IActionResult DetailsNews(int id)
        {
            return PagedView(DB.News, 10);
        }
        //渲染添加新闻页面
        [HttpGet]
        public IActionResult CreateNews()
        {
            return View();
        }

        //处理添加新闻请求
        [HttpPost]
        public IActionResult CreateNews(News news)
        {
            DB.News.Add(news);
            DB.SaveChanges();
            return RedirectToAction("DetailsNews", "Admin");

        }

        //渲染编辑页面
        [HttpGet]
        public IActionResult EditNews(int id)
        {
            var news = DB.News
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (news == null)
                return Content("没有此记录！");
            else
                return View(news);
        }

        //处理编辑新闻请求
        [HttpPost]
        public IActionResult EditNews(int id, News news)
        {
            var n = DB.News
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (n == null)
                return Content("没有该记录！");
            n.Title = news.Title;
            n.Content = news.Content;
            n.Datatime = news.Datatime;
            n.Source = news.Source;
            DB.SaveChanges();
            return RedirectToAction("DetailsNews", "Admin");
         
        }

        // 删除新闻
        public IActionResult DeleteNews(int id)
        {
            var news = DB.News
                .Where(x => x.Id == id)
                .SingleOrDefault();
            DB.News.Remove(news);
            DB.SaveChanges();
            System.Diagnostics.Debug.Write("id=" + id);
            return RedirectToAction("DetailsNews", "Admin");
        }

        //文章--------------------------------------------
       
        //分页
        [HttpGet]
        public IActionResult DetailsArticle()
        {           
            return PagedView(DB.Article, 10);
        }
        //渲染添加w文章页面
        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }

        //处理添加文章请求
        [HttpPost]
        public IActionResult CreateArticle(Article article)
        {
            DB.Article.Add(article);
            DB.SaveChanges();
            return RedirectToAction("DetailsArticle", "Admin");

        }

        //渲染编辑文章页面
        [HttpGet]
        public IActionResult EditArticle(int id)
        {
            var article = DB.Article
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (article == null)
                return Content("没有此记录！");
            else
                return View(article);
        }

        //处理编辑文章请求
        [HttpPost]
        public IActionResult EditArticle(int id, Article article)
        {
            var n = DB.Article
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (n == null)
                return Content("没有该记录！");
            n.Title = article.Title;
            n.Content = article.Content;
            n.Datatime = article.Datatime;
            DB.SaveChanges();
            return RedirectToAction("DetailsArticle", "Admin");

        }

        // 删除文章
        public IActionResult DeleteArticle(int id)
        {
            var article = DB.Article
                .Where(x => x.Id == id)
                .SingleOrDefault();
            DB.Article.Remove(article);
            DB.SaveChanges();
            System.Diagnostics.Debug.Write("id=" + id);
            return RedirectToAction("DetailsArticle", "Admin");
        }

        //校园风光（照片）------------------------------------------------------
        //分页
        [HttpGet]
        public IActionResult DetailsPhotos()
        {
            return PagedView(DB.Photos, 10);
        }
        //渲染添加照片页面
        [HttpGet]
        public IActionResult CreatePhotos()
        {
            return View();
        }

        //处理添加照片请求
        [HttpPost]
        public IActionResult CreatePhotos(Photos photos)
        {
            DB.Photos.Add(photos);
            DB.SaveChanges();
            return RedirectToAction("DetailsPhotos", "Admin");

        }

        //渲染编辑照片页面
        [HttpGet]
        public IActionResult EditPhotos(int id)
        {
            var photos = DB.Photos
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (photos == null)
                return Content("没有此记录！");
            else
                return View(photos);
        }

        //处理编辑照片请求
        [HttpPost]
        public IActionResult EditPhotos(int id, Photos photos)
        {
            var n = DB.Photos
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (n == null)
                return Content("没有该记录！");
            n.Title = photos.Title;
            n.Path = photos.Path;
            n.Discription = photos.Discription;
            n.Datetime = photos.Datetime;
            DB.SaveChanges();
            return RedirectToAction("DetailsPhotos", "Admin");

        }

        // 删除文章
        public IActionResult DeletePhotos(int id)
        {
            var photos = DB.Photos
                .Where(x => x.Id == id)
                .SingleOrDefault();
            DB.Photos.Remove(photos);
            DB.SaveChanges();
            System.Diagnostics.Debug.Write("id=" + id);
            return RedirectToAction("DetailsPhotos", "Admin");
        }


        //学校信息-----------------------------------------------------
        //分页
        [HttpGet]
        public IActionResult DetailsSchoolInfo()
        {
            return PagedView(DB.SchoolInfo, 10);
        }
        //渲染添加学校页面
        [HttpGet]
        public IActionResult CreateSchoolInfo()
        {
            return View();
        }

        //处理添加学校信息请求
        [HttpPost]
        public IActionResult CreateSchoolInfo(SchoolInfo schoolInfo)
        {
            DB.SchoolInfo.Add(schoolInfo);
            DB.SaveChanges();
            return RedirectToAction("DetailsSchoolInfo", "Admin");

        }

        //渲染学校信息页面
        [HttpGet]
        public IActionResult EditSchoolInfo(int id)
        {
            var schoolInfo = DB.SchoolInfo
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (schoolInfo == null)
                return Content("没有此记录！");
            else
                return View(schoolInfo);
        }

        //处理学校信息请求
        [HttpPost]
        public IActionResult EditSchoolInfo(int id, SchoolInfo schoolInfo)
        {
            var n = DB.SchoolInfo
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (n == null)
                return Content("没有该记录！");
            n.Title = schoolInfo.Title;
            n.Content = schoolInfo.Content;
            n.Datetime = schoolInfo.Datetime;
            DB.SaveChanges();
            return RedirectToAction("DetailsSchoolInfo", "Admin");

        }

        // 删除学校信息
        public IActionResult DeleteSchoolInfo(int id)
        {
            var schoolInfo = DB.SchoolInfo
                .Where(x => x.Id == id)
                .SingleOrDefault();
            DB.SchoolInfo.Remove(schoolInfo);
            DB.SaveChanges();
            System.Diagnostics.Debug.Write("id=" + id);
            return RedirectToAction("SchoolInfo", "Admin");
        }

        //招生信息 ------------------------------------------
        //分页
        [HttpGet]
        public IActionResult DetailsRecruitStudents()
        {
            return PagedView(DB.RecruitStudents, 10);
        }
        //渲染添加招生信息页面
        [HttpGet]
        public IActionResult CreateRecruitStudents()
        {
            return View();
        }

        //处理添加招生信息请求
        [HttpPost]
        public IActionResult CreateRecruitStudents(RecruitStudents recruitStudents)
        {
            DB.RecruitStudents.Add(recruitStudents);
            DB.SaveChanges();
            return RedirectToAction("DetailsRecruitStudents", "Admin");

        }

        //渲染编辑招生信息页面
        [HttpGet]
        public IActionResult EditRecruitStudents(int id)
        {
            var recruitStudents = DB.RecruitStudents
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (recruitStudents == null)
                return Content("没有此记录！");
            else
                return View(recruitStudents);
        }

        //处理编辑招生信息请求
        [HttpPost]
        public IActionResult EditRecruitStudents(int id, RecruitStudents recruitStudents)
        {
            var n = DB.RecruitStudents
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (n == null)
                return Content("没有该记录！");
            n.Title = recruitStudents.Title;
            n.Content = recruitStudents.Content;
            n.Datatime = recruitStudents.Datatime;
            DB.SaveChanges();
            return RedirectToAction("DetailsRecruitStudents", "Admin");

        }

        // 删除招生信息
        public IActionResult DeleteRecruitStudents(int id)
        {
            var recruitStudents = DB.RecruitStudents
                .Where(x => x.Id == id)
                .SingleOrDefault();
            DB.RecruitStudents.Remove(recruitStudents);
            DB.SaveChanges();
            System.Diagnostics.Debug.Write("id=" + id);
            return RedirectToAction("DetailsRecruitStudents", "Admin");
        }
    }
}
