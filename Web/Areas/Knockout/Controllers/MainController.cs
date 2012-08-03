using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Core.Model;
using Core.Persistence;

namespace Web.Areas.Knockout.Controllers
{
    public class MainController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tasks()
        {
            return View();
        }

        public ActionResult Tags()
        {
            return View();
        }


        public ActionResult Categories()
        {
            return View();
        }
        public ActionResult Both()
        {
            return View();
        }


        private readonly Context _context = new Context();

        public JsonResult GetTasks()
        {
            //var l = new List<TaskViewModel>();
            //l.Add(new TaskViewModel { title = "Wire the money to Panama", isDone = false });
            //l.Add(new TaskViewModel { title = "Arrange for someone to look after the cat", isDone = true });
            //l.Add(new TaskViewModel { title = "Get hair dye, beard trimmer, dark glasses", isDone = false });
            //l.Add(new TaskViewModel { title = "Book taxi to airport", isDone = false });

            Thread.Sleep(1000);
            
            var l = _context.Tasks.Select(x=> new TaskViewModel
                                                  {
                                                      title = x.Title,
                                                      isDone =   x.IsDone
                                                  });

            //return Json(new { title = "aaa", list = l }, JsonRequestBehavior.AllowGet);
            return Json(  l  , JsonRequestBehavior.AllowGet);
        }


        public ActionResult SaveTasks(TaskList list)
        {
            Thread.Sleep(1000); 
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



        public JsonResult GetCategories()
        { 
            Thread.Sleep(1000); 
            var l = _context.Categories.Select(x => new CategoryViewModel 
            {
                name = x.Name 
            }); 
            //return Json(new { title = "aaa", list = l }, JsonRequestBehavior.AllowGet);
            return Json(l, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SaveCategories(CategoryList list)
        { 
            foreach (var t in _context.Categories)
            {
                _context.Categories.Remove(t);
            } 
            foreach (var l in list.categories)
            {
                _context.Categories.Add(new Category { Name = l.name }); 
            } 
            _context.SaveChanges(); 
            return Content(string.Format("the server got the categories "));
        }



        public JsonResult GetTags()
        {
            Thread.Sleep(1000);
            var articleId = 21;
            //var allTags = _context.Tags.Select(x=> x.Name).Distinct();
            //var article = _context.Articles.Where(z => z.Id == articleId).SingleOrDefault();
            //var l = allTags.Select(x => new TagViewModel
            //                                {
            //                                    name = x,
            //                                    isInArticle = article.Tags.Any(y => y.Name == x)
            //                                }); 
            //var l = _context.Tags.Where(x => x.Articles.Any(y => y.Id == articleId));

            //var l = _context.Tags.Select(x => new TagViewModel
            //{
            //    articleId = x.Id,
            //    name = x.Name,
            //    isInArticle = _context.Tags.Any(z => z.Articles.Any(y => y.Id == articleId))
            //});

            /*
            var l = from at in _context.ArticleTags
                    join a in _context.Articles on at.Article.Id equals a.Id
                    join t in _context.Tags on at.Article.Id equals t.Id
                    select new { at.Id, ArticleName = a.Name, TagName = t.Name };
            */

            var l = (from t in _context.Tags
                     group t by new { t.Id, t.Name }
                         into grp
                         select new
                         {
                             grp.Key.Id,
                             //articleId = 
                             name = grp.Key.Name,
                             //AllArt = grp.Sum(t => ArticleTags.Where(x=> x.Tag_Id == t.Id).Count() ),
                             isInArticle = grp.Sum(t => _context.ArticleTags.Where(x => x.Tag.Id == t.Id && x.Article.Id == 21).Count()) > 0
                         });


            //return Json(new { title = "aaa", list = l }, JsonRequestBehavior.AllowGet);
            return Json(l, JsonRequestBehavior.AllowGet);
        } 

        public ActionResult SaveTags(TagList list)
        {
            foreach (var t in _context.Tags)
            {
                _context.Tags.Remove(t);
            }
            foreach (var l in list.tags)
            {
                _context.Tags.Add(new Tag  { Name = l.name });
            }
            _context.SaveChanges();
            return Content(string.Format("the server got the categories "));
        } 
    }
    public class TagList
    {
        public TagViewModel[] tags { get; set; }
    }
    public class TagViewModel
    {
        public int articleId { get; set; }
        public string name { get; set; }
        public bool isInArticle { get; set; }
    }
    public class TaskList
    {
        public TaskViewModel[] tasks { get; set; }
    }
    public class TaskViewModel
    {
        public string title { get; set; }
        public bool isDone { get; set; }
    }
    public class CategoryList 
    {
        public CategoryViewModel[] categories { get; set; }
    }
    public class CategoryViewModel
    {
        public string name { get; set; } 
    }
}
