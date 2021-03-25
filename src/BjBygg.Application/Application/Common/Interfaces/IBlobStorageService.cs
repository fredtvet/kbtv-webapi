using BjBygg.SharedKernel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BjBygg.Application.Application.Common.Interfaces
{
    public interface IBlobStorageService
    {
        Task<IEnumerable<Uri>> ListAsync(string folder);
        Task GetAsync(string fileName, string folder, Stream target);
        Task<IEnumerable<Uri>> UploadFilesAsync(DisposableList<BasicFileStream> streams, string folder);
        Task<Uri> UploadFileAsync(BasicFileStream stream, string folder);
        Task DeleteAsync(string fileUri, string folder);
    }
}
