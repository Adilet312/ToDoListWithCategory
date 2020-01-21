using System.Collections.Generic; 
namespace ToDoListWithType.Models
{
    public class Category
    {
        public string name {get;set;}
        public int CategoryId {get;set;}
        public virtual ICollection<Item> Items {get;set;}
        public Category()
        {
            this.Items = new HashSet<Item>();
        }
        
    }
}