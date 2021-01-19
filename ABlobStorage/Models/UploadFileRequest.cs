using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABlobStorage.Models
{
    public class UploadFileRequest
    {
        public string FilePath { get; set; } //full path in local hard drive
        public string FileName { get; set; } // file name in the Azure Blob Storage
    }
}
