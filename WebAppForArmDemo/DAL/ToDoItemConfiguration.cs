using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace WebAppForArmDemo.DAL
{
    public class ToDoItemConfiguration : DbConfiguration
    {
        public ToDoItemConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}