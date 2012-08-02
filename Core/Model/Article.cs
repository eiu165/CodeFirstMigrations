using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Article : Entity
    {
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)] 
        public string Url { get; set; }
        public string Content { get; set; }
        [StringLength(150)]
        public string AssignedTo { get; set; }
        [StringLength(150)]
        public string Status { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
