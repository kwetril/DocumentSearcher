using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using DocumentSearcher.Models.Helpers.TextExtractors;
using MongoDB.Bson;

namespace DocumentSearcher.Models
{
    public class DocumentModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }

        public bool HasValidExtension()
        {
            string extension = Path.GetExtension(File.FileName);
            return TextExtractorFactory.SupportedFormats.Contains(extension);
        }
    }
}