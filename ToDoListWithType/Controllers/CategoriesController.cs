using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListWithType.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoListWithType.Controllers
{
  public class CategoriesController : Controller
  {

   private readonly ToDoListWithTypeContext _dataBase;
   public CategoriesController(ToDoListWithTypeContext dataBase)
   {
     _dataBase = dataBase;
   }
    [HttpGet]
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Category new_category)
    {
        _dataBase.Categories.Add(new_category);
        _dataBase.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Index()
    {
      List<Category> lsitOfCategories = _dataBase.Categories.ToList();
      return View(lsitOfCategories);
    }
    [HttpGet]
    public ActionResult Details(int id)
    {
      Category CategoryInDetail = _dataBase.Categories.FirstOrDefault(categories => categories.CategoryId==id);
      CategoryInDetail.Items = _dataBase.Items.Where(rowItems => rowItems.CategoryId==id).ToList();
      return View(CategoryInDetail);
    }
    [HttpGet]
    public ActionResult Update(int CategoryID)
    {
      Category foundCatgeory = _dataBase.Categories.FirstOrDefault(categories => categories.CategoryId==CategoryID);

      return View(foundCatgeory);
    }
    [HttpPost]
    public ActionResult Update(Category new_category)
    {
      _dataBase.Entry(new_category).State = EntityState.Modified;
      _dataBase.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Remove(int idForDeleting)
    {
      Category categoryForDeleting = _dataBase.Categories.FirstOrDefault(rows => rows.CategoryId==idForDeleting);
      return View(categoryForDeleting);
    }
    [HttpPost,ActionName("Remove")]
    public ActionResult RemoveConfirmed(int idForDeleting)
    {
      Category removingCategory = _dataBase.Categories.FirstOrDefault(RelationalReferenceOwnershipBuilderExtensions => RelationalReferenceOwnershipBuilderExtensions.CategoryId==idForDeleting);
      _dataBase.Remove(removingCategory);
      _dataBase.SaveChanges();
      return RedirectToAction("Index");
    }
    
    

    


  


  

  }
}