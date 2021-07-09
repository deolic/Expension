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
            builder.Entity<Expense>()
                .ToTable("Expenses")
                .HasDiscriminator<string>("ExpenseType")
                .HasValue<IndividualExpense>("Individual")
                .HasValue<Shopping>("Shopping");

            builder.Entity<BoughtItem>()
                .HasOne<Shopping>(bi => bi.Shopping)
                .WithMany(s => s.BoughtItems)
                .HasForeignKey(bi => bi.ShoppingId);

            builder.Entity<BoughtItem>()
                .HasOne<IndividualExpense>(bi => bi.IndividualExpense)
                .WithOne(ie => ie.BoughtItem)
                .HasForeignKey<BoughtItem>(bi => bi.IndividualExpenseId);
        }
    }
}
