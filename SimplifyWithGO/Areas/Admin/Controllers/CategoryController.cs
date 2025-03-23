using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using SimplifyWithGO.Models;

namespace SimplifyWithGO.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            List<Category> CategoryList = _categoryRepository.GetAll().ToList();
            return View(CategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Name == category.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("name", "Category Name cannot be same as Display Order.");
                    return View();
                }
                _categoryRepository.Add(category);
                _categoryRepository.Save();
                TempData["success"] = "Category created successfully.";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id.Equals(0))
            {
                return NotFound();
            }
            Category? category = _categoryRepository.Get(category => category.Id == Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                _categoryRepository.Save();
                TempData["success"] = "Category updated successfully.";
                return RedirectToAction("Index");

            }
            return View();
        }



        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id.Equals(0))
            {
                return NotFound();
            }
            Category? category = _categoryRepository.Get(category => category.Id == Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Remove(category);
                _categoryRepository.Save();
                TempData["success"] = "Category deleted successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
