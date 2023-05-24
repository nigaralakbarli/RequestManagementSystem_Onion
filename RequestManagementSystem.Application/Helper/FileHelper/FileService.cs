using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace RequestManagementSystem.Application.Helper.FileHelper;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _hostEnvironment;
    public FileService(IWebHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    public string Upload(IFormFile file, string location)
    {
        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
        string fileExtension = Path.GetExtension(file.FileName);
        string uniqueFileName = fileName + "_" + Guid.NewGuid().ToString() + fileExtension;

        string filePath = Path.Combine(_hostEnvironment.WebRootPath, $"assets/{location}", uniqueFileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }
        return filePath;
    }

    public bool Delete(string fileName, string location)
    {
        if (fileName.IsNullOrEmpty())
        {
            return false;
        }
        var path = Path.Combine(_hostEnvironment.WebRootPath, $"assets/{location}", fileName);

        if (File.Exists(path))
        {
            File.Delete(path);
            return true;
        }
        return false;
    }

    public bool IsImage(IFormFile file)
    {
        if (file.ContentType.Contains("image"))
        {
            return true;
        }
        return false;
    }

}
