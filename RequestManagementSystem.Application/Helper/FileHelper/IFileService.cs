using Microsoft.AspNetCore.Http;

namespace RequestManagementSystem.Application.Helper.FileHelper;

public interface IFileService
{
    string Upload(IFormFile file, string location);
    bool Delete(string fileName, string location);
    bool IsImage(IFormFile file);
}
