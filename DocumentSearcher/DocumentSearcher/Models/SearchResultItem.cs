﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentSearcher.Models
{
    public class SearchResultItem
    {
        public IndexedDocument Document { get; set; }
        public double Relevancy {get; set; }
    }
}