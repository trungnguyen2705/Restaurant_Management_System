using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.Models.Entities;

namespace Restaurant_Management_System.Dal
{
    public class DatabaseContext: DbContext
    {
        //DbSet
        DbSet<Dish> Dish { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Ingredient> Ingredient { get; set; }
        DbSet<Supplier> Supplier { get; set; }
        DbSet<DishIngredient> DishIngredient { get; set; }
        DbSet<Area> Area { get; set; }
        DbSet<Table> Table { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<Account> Account { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Staff> Staff { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<OrderDetail> OrderDetail { get; set; }
        DbSet<Promotion> Promotion { get; set; }

        //Connection String
        private const string ConnectionString = "Data Source=localhost,1433;Initial Catalog=Restaurant_Management_System;User Id=sa;Password=123;TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the many-to-many relationship between Dish and Ingredient
            modelBuilder.Entity<DishIngredient>()
                .HasKey(di => new { di.DishId, di.IngredientId });

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany()
                .HasForeignKey(di => di.DishId);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany()
                .HasForeignKey(di => di.IngredientId);
        }
    }
}
