using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Web.Areas.Knockout.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Knockout/Main/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tasks()
        {
            return View();
        }


        public JsonResult GetTasks()
        {  
            var l = new List<Task>();
            l.Add(new Task { title = "Wire the money to Panama", isDone = false });
            l.Add(new Task { title = "Arrange for someone to look after the cat", isDone = true });
            l.Add(new Task { title = "Get hair dye, beard trimmer, dark glasses", isDone = false });
            l.Add(new Task { title = "Book taxi to airport", isDone = false });  


            return Json(new { title = "aaa", list = l }, JsonRequestBehavior.AllowGet) ;
        }
    }
    public class Task
    {
        public string title { get; set; }
        public bool isDone { get; set; }  
    }
}
