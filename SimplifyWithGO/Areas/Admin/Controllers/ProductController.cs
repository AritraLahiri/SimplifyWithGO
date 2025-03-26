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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository, IWebHostEnvironment webHostEnvironment)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            List<Product> ProductList = _productRepository.GetAll(includeTable: "Category").ToList();
            return View(ProductList);
        }
        [HttpGet]
        public IActionResult Upsert(int? Id)
        {
            ProductViewModel ProductVM = new()
            {
                CategoryList = _categoryRepository.GetAll().Select(
                cat => new SelectListItem
                {
                    Value = cat.Id.ToString(),
                    Text = cat.Name.ToString()
                }),
                Product = new() { Name = "" }
            };
            if (Id == null || Id == 0)
            {
                return View(ProductVM);
            }
            ProductVM.Product = _productRepository.Get(product => product.Id == Id);
            return View(ProductVM);
        }

        [HttpPost]
        public IActionResult Upsert(Product product, IFormFile? ProductImage)
        {
            if (ModelState.IsValid)
            {
                String uploadPath = _webHostEnvironment.WebRootPath + @"\images\Product";
                if (ProductImage != null)
                {
                    if (product.ImageUrl != null)
                    {
                        String imagePath = _webHostEnvironment.WebRootPath + product.ImageUrl;
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }

                    String fileName = Guid.NewGuid().ToString() + "_" + ProductImage.FileName;
                    String filePath = Path.Combine(uploadPath, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        ProductImage.CopyTo(fileStream);
                    }
                    product.ImageUrl = @"\images\Product\" + fileName;
                }
                if (product.Id == 0)
                {
                    _productRepository.Add(product);
                    _productRepository.SaveChanges();
                    TempData["Success"] = "Product  Created Successfully";
                }
                else
                {
                    _productRepository.Update(product);
                    _productRepository.SaveChanges();
                    TempData["Success"] = "Product  Updated Successfully";
                }
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Product not valid";
            return RedirectToAction("Upsert");
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
