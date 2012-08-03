using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Core.Model;
using Core.Persistence;
using System.Transactions;

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

        private int? _articleId = null;
        private int? articleId
        {
            get
            {
                if (_articleId != null)
                {
                    return _articleId;
                }
                _articleId = _context.Articles.FirstOrDefault().Id;
                return _articleId;
            }
        }


        public JsonResult GetTags()
        {
            Thread.Sleep(1000); 
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

            /*
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
            */
            //var at = _context.ArticleTags.Where(x =>   x.Article.Id == articleId).ToList();
            var l = (from t in _context.Tags
                     group t by new { t.Id, t.Name } into grp
                         select new TagViewModel
                         {
                             tagId = grp.Key.Id,
                             name = grp.Key.Name,
                             //articleId = articleId ?? 0,
                             //ArticleName = _context.Articles.Where(x => x.Id == articleId).SingleOrDefault().Name,
                             //isInArticle = grp.Sum(t => at.Where(x => x.Tag.Id == t.Id).Count()) > 0
                             isInArticle = grp.Sum(t => _context.ArticleTags.Where(x => x.Article.Id == articleId).Where(x => x.Tag.Id == t.Id).Count()) > 0
                         });

            //return Json(new { title = "aaa", list = l }, JsonRequestBehavior.AllowGet);
            return Json(l, JsonRequestBehavior.AllowGet);
        }



         
        public ActionResult SaveTag(TagViewModel tag)
        { 
            var article = _context.Articles.Find(articleId);
            var r = string.Format("article was tagged with {0}", tag.name);
            var dbTag = _context.Tags.Where(x => x.Name == tag.name).FirstOrDefault();
            if (dbTag == null)
            {
                dbTag = _context.Tags.Add(new Tag { Name = tag.name });
                r = string.Format("'{0}' was added to the db and article was tagged with '{0}'", tag.name);
            }
            _context.ArticleTags.Add(new ArticleTag {Article = article, Tag = dbTag});
            _context.SaveChanges();
            return Content(r);
        }
        public ActionResult RemoveTag(TagViewModel tag)
        {
            foreach (var at in _context.ArticleTags.Where(x => x.Article.Id == articleId && x.Tag.Name == tag.name))
            {
                _context.ArticleTags.Remove(at);
            }
            string r = string.Format("removed '{0}' from article", tag.name);
            if (!_context.ArticleTags.Any(x => x.Tag.Name == tag.name))
            {
                foreach (var t in _context.Tags.Where(x => x.Name == tag.name))
                {
                    _context.Tags.Remove(t);
                    r = string.Format("removed tag '{0}' from article and tag", tag.name);
                }
            } 
            return Content(r);
        } 

        /*
        public ActionResult SaveTags(TagList list)
        {
            using (var ctx = new Context())
            {
                using (var scope = new TransactionScope())
                { 
                    var article = ctx.Articles.Find(articleId);
                    //ctx.ArticleTags.Where(x => x.Article.Id == articleId).ToList().ForEach(x => ctx.ArticleTags.DeleteObject(x));
                    ctx.Database.ExecuteSqlCommand("Delete from ArticleTags where Article_Id = {0}", articleId);

                    var tags = ctx.Tags;
                    foreach (TagViewModel t in list.tags)
                    {
                        var tag = tags.Where(x => x.Name == t.name).FirstOrDefault();
                        if (tag == null)
                        {
                            tag = ctx.Tags.Add(new Tag {Name = t.name});
                        }
                        ctx.ArticleTags.Add(new ArticleTag {Article = article, Tag = tag});
                    }
                    ctx.SaveChanges();
                    scope.Complete();
                }
            }

            return Content(string.Format("the server got the tags "));
        } */
    }
    public class TagList
    {
        public TagViewModel[] tags { get; set; }
    }
    public class TagViewModel
    {
        public int tagId { get; set; } 
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
