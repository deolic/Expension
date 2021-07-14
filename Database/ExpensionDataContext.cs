using Expension.Database.Models;
using Microsoft.EntityFrameworkCore;


namespace Expension.Database
{
    public class ExpensionDataContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<BoughtItem> BoughtItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=(localdb)\MSSQLLocalDB; initial catalog=ExpensionDb;persist security info=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IndividualExpense>().ToTable("IndividualExpenses");
            builder.Entity<Shopping>().ToTable("Shoppings");
        }
    }
}
