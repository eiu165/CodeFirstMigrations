using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model
{
    public class Article : Entity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        public string AssignedTo { get; set; }
        public string Status { get; set; } 
    }
}
