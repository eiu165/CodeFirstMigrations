using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Core.Model;
using Core.Persistence;

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
            //var l = new List<TaskViewModel>();
            //l.Add(new TaskViewModel { title = "Wire the money to Panama", isDone = false });
            //l.Add(new TaskViewModel { title = "Arrange for someone to look after the cat", isDone = true });
            //l.Add(new TaskViewModel { title = "Get hair dye, beard trimmer, dark glasses", isDone = false });
            //l.Add(new TaskViewModel { title = "Book taxi to airport", isDone = false });

            var l = _context.Tasks.Select(x=> new TaskViewModel
                                                  {
                                                      title = x.Title,
                                                      isDone =   x.IsDone
                                                  });

            //return Json(new { title = "aaa", list = l }, JsonRequestBehavior.AllowGet);
            return Json(  l  , JsonRequestBehavior.AllowGet);
        }


        private readonly Context _context = new Context();
        public ActionResult SaveTasks(Tasks list)
        {
            var numberTasks = 0;
            var numberDone = 0;
            foreach (var t in _context.Tasks)
            {
                _context.Tasks.Remove(t);
            }

            foreach (var l in list.tasks)
            {
                _context.Tasks.Add(new Task { IsDone = l.isDone, Title = l.title });
                numberTasks++;
                if (l.isDone)
                {
                    numberDone++;
                }
            }

            _context.SaveChanges();

            return Content(string.Format("the server got {0} tasks, {1} of which are done ", numberTasks, numberDone ));
        }

    }
    public class Tasks
    {
        public TaskViewModel[] tasks { get; set; } 
    }
    public class TaskViewModel
    {
        public string title { get; set; }
        public bool isDone { get; set; }
    }
}
