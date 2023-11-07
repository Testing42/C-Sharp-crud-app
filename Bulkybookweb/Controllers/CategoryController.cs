using Bulkybookweb.Data;
using Bulkybookweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulkybookweb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
                _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //get get the sql info
        public IActionResult Create()
        {
            return View();
        }

        //post from the form
        //check what validateAntiforgerytoken
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        //get get the sql info to update category line
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            //the below gets checks if a primary key matches the id below.
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //post from the form update category line
        //check what validateAntiforgerytoken
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        //get get the sql info to delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //the below gets checks if a primary key matches the id below.
            var categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //post from the form to delete
        //check what validateAntiforgerytoken
        //If you want to change the deletepost name to something else you need to add actionName
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
            _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
            
        }
    }
}


