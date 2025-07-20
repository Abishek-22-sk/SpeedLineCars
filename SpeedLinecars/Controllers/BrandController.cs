using Microsoft.AspNetCore.Mvc;

using SpeedLinecars.Data;
using SpeedLinecars.Models;
using SpeedLinecars.Service.BrandService;


namespace SpeedLinecars.Controllers
{
    public class BrandController : Controller
    {
        private readonly BrandService _brandService;
        private readonly SpeedLineDbContext _dbcontext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BrandController(SpeedLineDbContext dbContext, IWebHostEnvironment webHostEnvironment, BrandService brandService)
        {
            _brandService = brandService;
            _webHostEnvironment = webHostEnvironment;
            _dbcontext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Brand> brand = _dbcontext.Brands.ToList();
            return View(brand);
        }

        [HttpGet]
        public IActionResult BrandCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BrandCreate(Brand brand)
        {
            string webhost = _webHostEnvironment.WebRootPath;
            var file = Request.Form.Files;
            if (file.Count > 0)
            {
                string newfileName = Guid.NewGuid().ToString();
                var upload = Path.Combine(webhost, @"images\brand");
                var extension = Path.GetExtension(file[0].FileName);
                using (var filestream = new FileStream(Path.Combine(upload, newfileName + extension), FileMode.Create))
                {
                    file[0].CopyTo(filestream);
                }
                brand.BrandLogo = @"image\brand\" + newfileName + extension;
            }
            if (ModelState.IsValid)
            {
                _brandService.AddBrandAsync(brand);
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        [HttpGet]
        public async Task<IActionResult> BrandDetails(Guid id)
        {
           var brand= await _brandService.BrandDetailsAsync(id);
            return View(brand);
        }

        [HttpPost]
        public IActionResult BrandDelete(int id)
        {
            if (ModelState.IsValid)
            {
                _brandService.BrandDelete(id);
            }
                return RedirectToAction(nameof(Index));
        }
    }
    }

