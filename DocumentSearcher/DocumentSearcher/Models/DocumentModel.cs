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
            return TextExtractorFactory.SupportedFormats.Contains(DocumentExtension);
        }

        public string DocumentExtension
        {
            get
            {
                return Path.GetExtension(File.FileName);
            }
        }
    }
}