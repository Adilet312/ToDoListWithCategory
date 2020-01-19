using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoListWithType.Models;

namespace ToDoListWithType.Controllers
{
  public class CategoriesController : Controller
  {

    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.getAllCategories();
      return View(allCategories);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
        return View();
    }

    [HttpPost("/categories")]
    public ActionResult Create(string categoryName)
    {
      Category newCategory = new Category(categoryName);
      return RedirectToAction("Index");
    }
    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();

        Category selectedCategory = Category.findCategoryById(id);
        List<Item> categoryItems = selectedCategory.getItems();
        model.Add("category", selectedCategory);
        model.Add("items", categoryItems);
        return View(model);
    }
    [HttpPost("/categories/{categoryId}/items")]
    public ActionResult Create(int categoryId, string description)
    {
     Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.findCategoryById(categoryId);
      Item newItem = new Item(description);
      foundCategory.addItem(newItem);
      List<Item> categoryItems = foundCategory.getItems();
      model.Add("items", categoryItems);
      model.Add("category", foundCategory);
      return View("Show", model);
    }

    [HttpPost("/categories/delete")]
     public ActionResult DeleteAll()
      {
       Category.deleteAllCategories();
        return View();
      }
      [HttpGet("/categories/search")]
      public ActionResult Search(int givenID)
      {
        Dictionary<string,object> model = new Dictionary<string, object>();
        Category foundCategory = Category.findCategoryById(givenID);
        List<Item> categoryItems = foundCategory.getItems();
        model.Add("item_key",categoryItems);
        model.Add("category_key",foundCategory);
        
        return View(model);
      }
      

  

  }
}