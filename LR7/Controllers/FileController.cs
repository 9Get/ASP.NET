using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace LR7.Controllers
{
    public class FileController : Controller
    {
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        [Route("DownloadFile")]
        public IActionResult DownloadFile(string name, string surname, string fileName, string? fileContent)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(name).Append("\n").Append(surname).Append("\n");
                
                if (fileContent != null)
                    stringBuilder.Append(fileContent);

                FileUtils.GenerateFile(ms, stringBuilder.ToString());

                ms.Position = 0;

                string contentType = "text/plain";

                return File(ms.ToArray(), contentType, FileUtils.RemoveInvalidFileNameChars(fileName + ".txt"));
            }
        }
    }
}
