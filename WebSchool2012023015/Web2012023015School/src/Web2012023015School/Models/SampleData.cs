using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2012023015School.Models
{
    public class SampleData
    {
        public async static Task InitDB(IServiceProvider service)
        {
            //获取数据库的上下文
            var db = service.GetRequiredService<ArticleContext>();

            //获取UserManager服务
            var userManager = service.GetRequiredService<UserManager<User>>();

            if(db.Database != null && db.Database.EnsureCreated())
            {
                //初始化管理员
                await userManager.CreateAsync(new User { UserName="admin",Email="627148026@qq.com"}, "Cream2015!@#");


            }
        }
    }
}
