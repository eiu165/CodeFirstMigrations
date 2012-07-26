using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Articles.Controllers
{
    public class TagCloudPartialController : Controller
    {
        //
        // GET: /Articles/TagCloudPartial/

        public ActionResult Index()
        {
            return View();
        }

    }
    public class TagCloudPartialModel
    {
        public string Name { get; set; }
        public bool IsInTag { get; set; } 
    }

}
