using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABlobStorage.Services
{
    public interface IBlobService
    {
        Task<BlobInfo> GetBlobAsync(string blobName);

        Task<IEnumerable<string>> ListBlobsAsync();

        Task UploadFileBlobAsync(string filePath, string fileName);

        Task UploadContentBlobAsync(string content, string fileName);

        Task DeleteBlobAsync(string blobName);
    }
}
