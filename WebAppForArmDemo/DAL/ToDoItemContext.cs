using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebAppForArmDemo.Models;

namespace WebAppForArmDemo.DAL
{
    public class ToDoItemContext : DbContext
    {
        public ToDoItemContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}