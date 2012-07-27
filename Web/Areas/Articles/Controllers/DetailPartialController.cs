using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Articles.Controllers
{
    public class DetailPartialController : Controller
    { 
        [HttpGet]
        public ActionResult Get(string name)
        {
            var d = new DetailPartialModel
            {
                Name = "asdfasdf",
                Title = "the best part of the web",
                Url = "the-best-part-of-the-web",
                Lock = false,
                LockedBy = "Justin",
                Status = "Edit",
                AssignedTo = "Justin"
            };

            //render the new customer's listitem and return the result
            return PartialView("DetailPartial", d);
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult Post (string name )
        {
            var d = new DetailPartialModel {
                Name = name, 
                Title = "the best part of the web", 
                Url = "the-best-part-of-the-web" , 
                Lock = false, 
                LockedBy = "Justin", 
                Status = "Edit", 
                AssignedTo = "Justin"
            };

            //render the new customer's listitem and return the result
            return PartialView("DetailPartial", d);
        }



    }

     public class DetailPartialModel
     {
         public string Name { get; set; }
         public string Title { get; set; }
         public string Url { get; set; }
         public bool Lock { get; set; }
         public string LockedBy { get; set; }
         public string Status { get; set; }
         public string AssignedTo { get; set; }
     }
}
