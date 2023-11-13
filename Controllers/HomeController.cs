using GraduaitionProjectITI.Models;
using GraduaitionProjectITI.Models.Entity;
using GraduaitionProjectITI.Reprository.BrandRepository;
using GraduaitionProjectITI.Reprository.CategoryReprositry;
using GraduaitionProjectITI.Reprository.ProductReprository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GraduaitionProjectITI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductReprository reprositryProd;
        private readonly ICategoryReprositry reprositryCaty;
        private readonly IBrandRepository reprositryBrand;
        public HomeController(ILogger<HomeController> logger,IProductReprository reprositryProd, ICategoryReprositry reprositryCaty, IBrandRepository reprositryBrand)
        {
            _logger = logger;
            this.reprositryProd = reprositryProd;
            this.reprositryCaty = reprositryCaty;
            this.reprositryBrand = reprositryBrand;

        }

  

        public IActionResult Index()
        {
            return View(reprositryProd.GetAll());
        }
        public IActionResult productOfCat(int catId)
        {
            if (catId != 0)
            {
                IEnumerable<Product> listnew = reprositryProd.GetAll().Where(p=> p.CategoryId==catId);
                return PartialView("Product", listnew);
            }


            return PartialView("Product", reprositryProd.GetAll());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}