using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace APL_Technical_Test.helper
{
    public static class ImageUploadHelper
    {
        
        public static string filePath { get; set; }
        public static string imageName { get; set; }
        public static bool CheckIfJpgOrPngFile(IFormFile file)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            return (extension == ".jpg" || extension == ".png");
        }

        public static string GetFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName);
                  
        }

        public static async Task<bool> WriteFile(IFormFile file, IWebHostEnvironment hostEnvironment)
        {
            bool isSaveSuccess = false;
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                //fileName = DateTime.Now.Ticks + extension;
                fileName = file.FileName;
                var pathBuilt = Path.Combine(hostEnvironment.WebRootPath, "uploads");
               // var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "upload\\files");
                //var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "upload");
                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }

                //var path = Path.Combine(Directory.GetCurrentDirectory(), "upload\\files", fileName);
                var fullPath = Path.Combine(pathBuilt, fileName);
                filePath = fullPath;
                imageName = Path.GetFileName(filePath);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                isSaveSuccess = true;
            }
            catch (Exception e)
            {
                //log error
            }

            return isSaveSuccess;
        }
        public static void deleteTempFile()
        {

            try
            {

                if (File.Exists(filePath))
                {

                    File.Delete(filePath);

                }

            }
            catch (IOException ioExp)
            {

            }
        }
    }
}
