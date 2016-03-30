using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using Web2012023015School.Models;
using Microsoft.AspNet.Authorization;
using CodeComb.Media;
using System.IO;
using System.Text;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web2012023015School.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        
        //文章，新闻，....管理模块

        #region 后台通知公告详细
        [HttpGet]
        public IActionResult DetailsInform()
        {
            return PagedView(DB.Inform, 10);
        }
        #endregion

        #region 添加通知公告
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
        #endregion

        #region 编辑公告页面
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
            n.Title = inform.Title;
            n.Content = inform.Content;
            n.Datatime = inform.Datatime;
            DB.SaveChanges();
            return RedirectToAction("DetailsInform", "Admin");

        }
        #endregion

        #region 删除通知公告
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
        #endregion

        #region 新闻详细
        [HttpGet]
        public IActionResult DetailsNews()
        {
            var news = DB.News.OrderByDescending(x => x.Datatime).ToList();
            return PagedView(news, 10);
        }
        #endregion
       
        #region 添加新闻页面
        [HttpGet]
        public IActionResult CreateNews()
        {
            return View();
        }

        //处理添加新闻请求
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateNews(News news)
        {
            DB.News.Add(news);
            DB.SaveChanges();
            return RedirectToAction("DetailsNews", "Admin");

        }
        #endregion

        #region 新闻编辑页面
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
        #endregion

        #region 删除新闻页面
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
        #endregion

        #region 后台文章详细
        [HttpGet]
        public IActionResult DetailsArticle()
        {
            return PagedView(DB.Article, 10);
        }
        #endregion

        #region 添加文章
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
        #endregion

        #region 后台编辑文章
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
        #endregion

        #region 删除文章
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
        #endregion

        //校园风光（照片）------------------------------------------------------
        //分页
        [HttpGet]
        public IActionResult DetailsPhotos()
        {
            return PagedView(DB.Photos.ToList(), 10);
        }
        //渲染添加照片页面
        [HttpGet]
        public IActionResult CreatePhotos()
        {
            return View();
        }

        //处理添加照片请求
        [HttpPost]
        public IActionResult CreatePhotos(IFormFile file, Photos photos)
        {
            //先将我们前台传过来的文件获取,file.ReadAllBytes()，然后再获取文件名 file.GetFileName()
            var img = new Image(file.ReadAllBytes(), file.GetFileName());
            //将文件另存为到Upload文件夹并且以提交时间保存文件名，
            //为了避免文件名保存重复出错，所以用时间，保存为png结尾
            img.SaveAs(".\\Upload\\" + DateTime.Now.ToString("yyMMddhhmmss") + ".png");
            DB.Photos.Add(photos);
            //将前台传过来的Photes对象接收，也就是photos
            //然后从对应的CreatePhotos视图中可以看出，只有3个字段是传过来的
            //分别是title,description，priority,而我们Photos对应五个字段，如果直接保存，就提示字段不能为空的错误
            //另外两个字段分别是DATATIME以及Path
            //所以，我们得把DATATIME和Path保存了
            //下边是将文件保存的路径，具体到文件的结尾
            photos.Path= (".\\Upload\\" + DateTime.Now.ToString("yyMMddhhmmss") + ".png");
            //再保存时间
            photos.Datatime = DateTime.Now;
            //最后保存数据库，大功告成
            DB.SaveChanges();
            //photos.File = img.AllBytes; 这是将图片以二进制保存到到file中
            //return File(img.AllBytes, file.ContentType); 返回文件类型，就是直接返回刚刚保存的图片
            return Content("success");

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
            n.Discription = photos.Discription;
            n.Datatime = photos.Datatime;
            DB.SaveChanges();
            return RedirectToAction("DetailsPhotos", "Admin");

        }

        // 删除照片
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
        [HttpGet]
        public IActionResult Photos(int id)
        {
            var p = DB.Photos.Where(x => x.Id == id).SingleOrDefault();
            return View(p); 
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

        #region 后台招生信息详细
        [HttpGet]
        public IActionResult DetailsRecruitStudents()
        {
            return PagedView(DB.RecruitStudents, 10);
        } 
        #endregion

        #region 渲染添加招生信息页面
        [HttpGet]
        public IActionResult CreateRecruitStudents()
        {
            return View();
        } 
        #endregion

        #region 处理添加招生信息请求
        [HttpPost]
        public IActionResult CreateRecruitStudents(RecruitStudents recruitStudents)
        {
            DB.RecruitStudents.Add(recruitStudents);
            DB.SaveChanges();
            return RedirectToAction("DetailsRecruitStudents", "Admin");

        } 
        #endregion

        #region 渲染编辑招生信息页面
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
        #endregion

        #region 处理编辑招生信息请求
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
        #endregion

        #region 删除招生信息
        public IActionResult DeleteRecruitStudents(int id)
        {
            var recruitStudents = DB.RecruitStudents
                .Where(x => x.Id == id)
                .SingleOrDefault();
            DB.RecruitStudents.Remove(recruitStudents);
            DB.SaveChanges();
            return RedirectToAction("DetailsRecruitStudents", "Admin");
        }
        #endregion

        #region 创建活动
        [HttpGet]
        public IActionResult CreateActivities()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateActivities(Activities activities)
        {
            DB.Activities.Add(activities);
            DB.SaveChanges();
            return RedirectToAction("DetailsActivities", "Admin");
        }
        #endregion

        #region 编辑活动
        [HttpGet]
        public IActionResult EditActivities(int id)
        {
            var activities = DB.Activities
                .Where(x => x.Id == id)
                .SingleOrDefault();
            if (activities == null)
                return Content("没有此记录！");
            else
                return View(activities);
        }
        [HttpPost]
        public IActionResult EditActivities(int id, Activities activities)
        {
            var n = DB.Activities
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (n == null)
                return Content("没有该记录！");
            n.Title = activities.Title;
            n.Content = activities.Content;
            n.Datatime = activities.Datatime;
            n.Address = activities.Address;
            DB.SaveChanges();
            return RedirectToAction("DetailsActivities", "Admin");
        }
        #endregion

        #region 删除活动
        public IActionResult DeleteActivities(int id)
        {
            var a = DB.Activities
                .Where(x => x.Id == id)
                .SingleOrDefault();
            DB.Activities.Remove(a);
            DB.SaveChanges();
            System.Diagnostics.Debug.Write("id=" + id);
            return RedirectToAction("DetailsActivities", "Admin");
        }
        #endregion

        #region 后台活动详细信息
        public IActionResult DetailsActivities()
        {
            var activities = DB.Activities.ToList();

            return PagedView(activities, 10);
        } 
        #endregion
    }
}
