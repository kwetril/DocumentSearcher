using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace DocumentSearcher.Models
{
    public class IndexedDocument
    {
        public IndexedDocument()
        {
        }

        public IndexedDocument(DocumentModel uploadedDocument, User user)
        {
            var uploadedFile = uploadedDocument.File;
            FileName = uploadedFile.FileName;
            FileContent = new byte[uploadedFile.InputStream.Length];
            uploadedFile.InputStream.Read(FileContent, 0, FileContent.Length);
            CreatedDate = DateTime.Now;
            UserId = user.Id;
        }

        public ObjectId Id { get; set; }

        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public ObjectId UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}