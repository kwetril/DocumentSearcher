using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace DocumentSearcher.Models
{
    public class DocumentModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}