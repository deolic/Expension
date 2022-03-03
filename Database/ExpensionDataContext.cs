using Expension.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Expension.Database
{
    public class ExpensionDataContext : DbContext
    {
        public ExpensionDataContext(DbContextOptions<ExpensionDataContext> options) : base(options)
        {

        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<BoughtItem> BoughtItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
