using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Web2012023015School.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Dnx.Runtime;
using Microsoft.Data.Entity;

namespace Web2012023015School
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //获取应用程序环境服务
            var appEnv = services.BuildServiceProvider().GetRequiredService<IApplicationEnvironment>();

            //添加EntityFramework 服务
            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<ArticleContext>(x => x.UseSqlite("Data source=" + appEnv.ApplicationBasePath + "/Database/school.db"));//数据库连接符

            //添加Identity服务
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ArticleContext>()
                .AddDefaultTokenProviders();

            //添加MVC服务
            services.AddMvc();

            services.AddSmartUser<User, string>();
        }

        public async void Configure(IApplicationBuilder app)
        {
            //使用StaticFiles就会为wwroot下的文件添加到路由规则中
            app.UseStaticFiles();

            //使用Identity 中间件可以使标记有[Authorize]之类的Action在未登陆时跳转到登录页面
            app.UseIdentity();

            //使用MVC中间件，并配置默认路由规则
            app.UseMvc(x => x.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"));

            //初始化数据库并添加初始数据
            await SampleData.InitDB(app.ApplicationServices);
        }
    }
}
