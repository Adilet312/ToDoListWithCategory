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

    [HttpPost("/categories/delete")]
     public ActionResult DeleteAll()
      {
       Category.deleteAllCategories();
        return View();
      }

    [HttpGet("/categories/find")]
    public ActionResult Show(int findId)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category category = new Category();

        Category selectedCategory = category.findCategoryById(findId);
        List<Item> categoryItems = selectedCategory.getItems();
        model.Add("category", selectedCategory);
        model.Add("items", categoryItems);
        return View(model);
    }

  }
}