using Microsoft.EntityFrameworkCore;

namespace ToDoListWithType.Models
{
    public class ToDoListWithTypeContext:DbContext
    {
        public virtual DbSet<Category> Categories {get;set;}
        public DbSet<Item> Items {get;set;}
        public ToDoListWithTypeContext(DbContextOptions options):base(options){}

    } 
}