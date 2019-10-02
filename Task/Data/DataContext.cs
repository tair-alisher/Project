using System.Data.Entity;
using Task.Data.Models;

namespace Task.Data
{
    public class DataContext : DbContext
    {
        public DataContext(string connectionString) : base(connectionString) { }

        public DbSet<Client> Clients { get; set; }
    }
}
