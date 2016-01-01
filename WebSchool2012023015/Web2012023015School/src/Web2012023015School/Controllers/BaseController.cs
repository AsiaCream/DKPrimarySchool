using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2012023015School.Models;

namespace Web2012023015School.Controllers
{
    public class BaseController : BaseController<ArticleContext, User, string>
    {
    }
}
