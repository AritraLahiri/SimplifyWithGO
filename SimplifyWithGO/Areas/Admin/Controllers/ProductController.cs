using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModels;

namespace SimplifyWithGO.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }


        public IActionResult Index()
        {
            List<Product> ProductList = _productRepository.GetAll().ToList();
            return View(ProductList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ProductViewModel ProductVM = new()
            {
                CategoryList = _categoryRepository.GetAll().Select(
                cat => new SelectListItem
                {
                    Value = cat.Id.ToString(),
                    Text = cat.Name.ToString()
                }),
                Product = new() { Name = "Product Name" }
            };

            return View(ProductVM);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                _productRepository.SaveChanges();
                TempData["Success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Product not valid";
            return RedirectToAction("Create");
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Product? product = _productRepository.Get(product => product.Id == Id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(product);
                _productRepository.SaveChanges();
                TempData["Success"] = "Product Updated Successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Product not valid";
            return RedirectToAction("Edit");
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Product? product = _productRepository.Get(product => product.Id == Id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Remove(product);
                _productRepository.SaveChanges();
                TempData["Success"] = "Product Deleted Successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Product not valid";
            return View("Delete");
        }
    }
}
