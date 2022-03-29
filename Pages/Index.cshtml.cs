using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using APL_Technical_Test.helper;
using Microsoft.AspNetCore.Hosting;
using APL_Technical_Test.repository;
using APL_Technical_Test.data.entities;

namespace APL_Technical_Test.Pages
{
    public class IndexModel : PageModel
    {
        [ViewData]
        public bool isData { get; set; }
        [ViewData]
        public string imagePath { get; set; }
        [ViewData]
        public string imageName { get; set; }
        [ViewData]
        public string imageOverSizeMessage { get; set; }
        [BindProperty]
        public IFormFile UploadImage { get; set; }
        [ViewData]
        public ImageInformation imageInfor { get; set; }
        private DateTime imageCreatedDate { get; set; }
        public string ImageSaveFailedMessage { get; private set; }

        private readonly ILogger<IndexModel> _logger;
       private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IImageRepository repo;

        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment environment, IImageRepository repository)
        {
            this.isData = false;
            _logger = logger;
            _hostEnvironment = environment;
            repo = repository;
           
        }
        //public IActionResult OnGet(ImageInformation data)
        //{



        //}

        public void OnGet()
        {
            
        
        }
           
           
        //}
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (this.UploadImage != null)
            {
                try
                {
                    if (ImageUploadHelper.CheckIfJpgOrPngFile(this.UploadImage))
                    {
                        if (await ImageUploadHelper.WriteFile(this.UploadImage, _hostEnvironment))
                        {
                            this.imagePath = ImageUploadHelper.filePath;
                            //=================================get image details====================================================
                            System.Drawing.Image img = System.Drawing.Image.FromFile(this.imagePath);
                            int width = img.Width;
                            int height = img.Height;
                            if(width == 1024 && height == 1024)
                            {
                                // get images infor
                                this.imageName = this.UploadImage.FileName;
                               

                                this.imageInfor = new ImageInformation();
                                this.imageInfor.Dimensions = width.ToString() + "x" + height.ToString();
                                this.imageInfor.ImageName = this.imageName;
                                this.imageInfor.UploadDate = DateTime.Now;
                                this.repo.Add(this.imageInfor);
                                if(this.repo.save() > 0)
                                {
                                    return Page();
                                }
                                else
                                {
                                    this.ImageSaveFailedMessage = "Your Upload Failed";
                                    return Page();
                                }
                                var infor = repo.GetById(this.imageCreatedDate);
                                ViewData["infor"] = infor;
                                this.imageName = ImageUploadHelper.imageName;
                                
                                return Page();
                            }
                            else
                            {
                                this.imageName = null;
                                this.imageOverSizeMessage = "Your Image size must be 1024X1024 only";

                                return Page();
                            }
                            
                               
                        }
                        else
                        {
                            return Page();
                        }
                        
                    }
                    else
                    {
                        return Page();
                    }
                    
                }
                catch(Exception e)
                {
                    return Page();
                }

               

            }
            else
            {
                return Page();

            }


            {



            }
        }
    } 
}
