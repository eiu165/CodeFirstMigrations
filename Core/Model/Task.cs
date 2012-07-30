using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model
{
    public class Task : Entity
    {
        public string Title { get; set; }
        public bool IsDone { get; set; } 
    }
}
