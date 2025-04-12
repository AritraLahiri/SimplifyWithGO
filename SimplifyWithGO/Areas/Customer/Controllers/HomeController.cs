using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using SimplifyWithGO.Models;
using System.Diagnostics;

namespace SimplifyWithGO.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _productRepository.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Details(int ProdId)
        {
            Product? product = _productRepository.Get(p => p.Id == ProdId, includeTable: "Category");
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
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
