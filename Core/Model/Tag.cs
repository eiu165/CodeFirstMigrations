﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model
{
    public class Tag : Entity
    {
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
