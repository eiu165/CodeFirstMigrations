using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;

namespace Web.App.Models
{ 
    public class Articles : DynamicModel
    {
        public Articles()
            : base("context", "Articles", "Id")
        {
            //Test check-ins
        }
    }
    
    public class Tags : DynamicModel
    {
        public Tags()
            : base("context", "Tags", "Id")
        {
            //Test check-ins
        }
    } 

}