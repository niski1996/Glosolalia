using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Glosolalia.API.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FileController : Controller
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FileController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
                _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider??
                throw new ArgumentNullException(nameof(fileExtensionContentTypeProvider));
        }
        [HttpGet("{fileId}")]
        public IActionResult GetFile(string fileId)
        {
            var pathToFile = @"C:\Users\Karol\Desktop\programowanie\Glosolalia\Glosolalia.API\Files\SheetTranslations.txt"; //TODO zrób to dynamicznie
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }
            if (!_fileExtensionContentTypeProvider.TryGetContentType(
                pathToFile,out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes,contentType, Path.GetFileName(pathToFile));
        }
    }
}
