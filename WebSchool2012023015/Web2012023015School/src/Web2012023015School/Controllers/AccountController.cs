using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Web2012023015School.Models;
using Microsoft.AspNet.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web2012023015School.Controllers
{
    public class AccountController : BaseController
    {
        //管理员登录...等
        [FromServices]
        public SignInManager<User> signInManager { get; set; }

        //登录
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Login(string username, string password)
        {
            var result = await signInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded)
                return RedirectToAction("Manage", "Home",username);
            else
                return RedirectToAction("Login", "Account");
        }

        //登出
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        //修改密码
        [HttpGet]
        public IActionResult Modify()
        {
            return View(User.Current);
        }

        [HttpPost]
        public async Task<IActionResult> Modify(string currentpwd, string newpwd, string confirmpwd)
        {
            if (confirmpwd != newpwd)
                return Content("两次输入密码不一致，请检查重新输入。");
            var result = await UserManager.ChangePasswordAsync(await UserManager.FindByIdAsync(User.Current.Id), currentpwd, newpwd);
            if (!result.Succeeded)
                return Content(result.Errors.First().Description);
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        //注册
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        //现在还没写用户所以注册中只有用户名，密码
        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            var user = new User
            {
                UserName = username,

            };
            //创建用户
            var result = await UserManager.CreateAsync(user, password);
            //如果没有成功，返回错误信息
            if (!result.Succeeded)
                return Content(result.Errors.First().Description);

            return RedirectToAction("Login", "Account");
        }
    }
}
