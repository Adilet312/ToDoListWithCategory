using Microsoft.AspNetCore.Mvc;
using ToDoListWithType.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoListWithType.Controllers
{
    public class ItemsController : Controller
    {
     private readonly ToDoListWithTypeContext _dataBase;
     public ItemsController(ToDoListWithTypeContext dataBase)
     {
         _dataBase = dataBase;
     }
     public ActionResult Index()
     {
         List<Item> items = _dataBase.Items.Include(itemRows => itemRows.Category).ToList();
         return View(items);
     }
     [HttpGet]
     public ActionResult Create()
     {
         ViewBag.CategoryId = new SelectList(_dataBase.Categories,"CategoryId","name");
         
         return View();
     }
     [HttpPost]
     public ActionResult Create(Item new_item)
     {
         _dataBase.Add(new_item);
         _dataBase.SaveChanges();
         return RedirectToAction("Index");
     }
     [HttpGet]
     public ActionResult Details(int idForItems)
     {
            Item itemDetail = _dataBase.Items.FirstOrDefault(itemRows => itemRows.ItemId==idForItems);
            return View(itemDetail);

     }
     [HttpGet]
     public ActionResult Update(int updateID)
     {
         Item foundItem = _dataBase.Items.FirstOrDefault(rowItems => rowItems.ItemId==updateID);
         ViewBag.CategoryId = new SelectList(_dataBase.Categories,"CategoryId","name");
         return View(foundItem);
     }
     [HttpPost]
     public ActionResult Update(Item items)
     {
         _dataBase.Entry(items).State = EntityState.Modified;
         _dataBase.SaveChanges();
         return RedirectToAction("Index");
     }
     [HttpGet]
     public ActionResult Delete(int deleteID)
     {
         Item foundItem = _dataBase.Items.FirstOrDefault(rowItems => rowItems.ItemId==deleteID);
         return View(foundItem);
     }
     [HttpPost,ActionName("Delete")]
     public ActionResult DeleteItem(int deleteID)
     {
         Item deletingItem = _dataBase.Items.FirstOrDefault(rowItems=>rowItems.ItemId==deleteID);
         _dataBase.Remove(deletingItem);
         _dataBase.SaveChanges();
         return RedirectToAction("Index");

     }
    
        

       
    }
}