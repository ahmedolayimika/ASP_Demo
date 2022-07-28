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

        public IActionResult Index()
        {
            IEnumerable<Categories> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //Get
        public IActionResult AddNew()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew(Categories obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }

        }

        //Get
        public IActionResult Edit(int? id)
        {

            if(id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var CategoryFromDb = _db.Categories.Find(id);
                if(CategoryFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(CategoryFromDb);
                }
            }
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categories obj)
        {
           
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }

        }

    }
}
