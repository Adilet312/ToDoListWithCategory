using Microsoft.AspNetCore.Mvc;
using ToDoListWithType.Models;
using System.Collections.Generic;

namespace ToDoListWithType.Controllers
{
    public class ItemsController : Controller
    {
        //ListItem list = new ListItem();

        // [HttpGet("/items")]
        // public ActionResult Index()
        // {
        //     List<Item> itemList = Item.getAllItems();
        //     return View(itemList);
            
        //     //return View(list.toStirng());
        // }
        [HttpGet("/categories/{categoryId}/items/new")]
        public ActionResult New(int categoryId)
        {
           Category category = Category.findCategoryById(categoryId);

            return View(category);
        }

        // [HttpPost("/items")]
        // public ActionResult Index(string description)
        // {
        //     Item myitem = new Item(description);
        //     //list.addItem(item);

        //     return RedirectToAction("Index");

        // }

        [HttpPost("/items/delete")]
        public ActionResult DeleteAll()
        {
        Item.clearAllItems();
        return View();
        }

         [HttpGet("/categories/{categoryId}/items/{itemId}")]
        public ActionResult Show(int categoryId, int itemId)
        {
            Item item = Item.Find(itemId);
            Category category = Category.findCategoryById(categoryId);
            //Category category = categoryref.findCategoryById(categoryId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("item", item);
            model.Add("category", category);
            return View(model);
        }
        // [HttpGet("/items/find")]
        // public ActionResult Show(int findId)
        // {
        //      Item findItem = Item.Find(findId);
        //     return View(findItem);
        // }

       
    }
}