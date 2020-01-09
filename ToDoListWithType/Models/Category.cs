using System.Collections.Generic; 
namespace ToDoListWithType.Models
{
    public class Category
    {
        private static List<Category> categoryList = new List<Category>{};
        private List<Item> itemList;    
        private string name;

        private int id;
        public Category()
        {

        }

        public Category(string name)
        {
            this.name = name;
            this.itemList = new List<Item>{};
            categoryList.Add(this);
            this.id = categoryList.Count;
        }

        public string getName()
        {
            return this.name;
        }
        public void setName(string new_name)
        {
            this.name = new_name;
        }

        public int getId()
        {
            return this.id;
        }
        public List<Item> getItems()
        {
            return this.itemList;
        }

        public void setItems(Item new_item)
        {
            this.itemList.Add(new_item);
        }

        public static List<Category> getAllCategories()
        {
            return categoryList;
        }
        public static void deleteAllCategories()
        {
            categoryList.Clear();
        }

        public Category findCategoryById(int given_id)
        {
            return categoryList[given_id-1];
        }

        public string toString()
        {
            string result = "Category name: " + this.name;
            return result;
        }
    }
}