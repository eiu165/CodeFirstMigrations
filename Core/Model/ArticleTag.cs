using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model
{
    public class ArticleTag
    { 
        public ICollection<Article> Article { get; set; } 
        public ICollection<Tag> Tags { get; set; }
    }
}
