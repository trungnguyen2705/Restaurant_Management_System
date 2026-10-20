using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.Models.Entities;

namespace Restaurant_Management_System.Dal
{
    public class DatabaseContext: DbContext
    {
        //DbSet
        public DbSet<Dish> Dish { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<DishIngredient> DishIngredient { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<TableStatus> TableStatus { get; set; }

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
