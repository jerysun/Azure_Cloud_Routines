using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABlobStorage.Models
{
    public class UploadContentRequest
    {
        public string Content { get; set; } // the string of json format in memory
        public string FileName { get; set; } // file name in the Azure Blob Storage
    }
}
