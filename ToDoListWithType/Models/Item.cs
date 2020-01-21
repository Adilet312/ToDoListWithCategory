using System.Collections.Generic; 
namespace ToDoListWithType.Models
{
    public class Item
    {
        public string description {get;set;}
        public int CategoryId {get;set;}
        public int ItemId {get;set;}
        public virtual Category Category {get;set;}

       

    }
}