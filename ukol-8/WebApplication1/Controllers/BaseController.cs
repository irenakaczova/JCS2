using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    { 
        protected UniversityContext Ctx { get; set; }
        public BaseController()
        {
            Ctx = new UniversityContext();
        }
    }
}