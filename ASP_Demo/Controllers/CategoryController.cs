using ASP_Demo.Data;
using ASP_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Demo.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        //Index page for Categories
        public IActionResult Index()
        {
            IEnumerable<Categories> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //Page for adding new Category
        public IActionResult AddNew()
        {
            return View();
        }

        //Post- This action will post new Category to DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew(Categories obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["added"] = obj.Name + " added successfully";
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }

        }

        //Get: This action/page will return the selected Category == id from DB
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var CategoryFromDb = _db.Categories.Find(id);
                if (CategoryFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(CategoryFromDb);
                }
            }
        }

        //Post: will Update the Edited Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categories obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["updated"] = obj.Name + " updated successfully";
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }

        }

        //Get: This action/page will return the selected Category == id from DB
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var CategoryFromDb = _db.Categories.Find(id);
                if (CategoryFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(CategoryFromDb);
                }
            }
        }

        //Post: will remove the Category from DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["deleted"] = obj.Name + " deleted successfully";
                return RedirectToAction("Index");
            }
            


        }

    }
}
