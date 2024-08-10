using Microsoft.EntityFrameworkCore;
using MyEShop.Models;

namespace MyEShop.Data
{
    public class MyEshopContext : DbContext
    {
        public MyEshopContext(DbContextOptions<MyEshopContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
        public DbSet<CategoryToProduct>  categoryToProducts{ get; set; }
        public DbSet<Product>  products { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> ordersDetail { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>().HasKey(c=> new {c.CategoryId,c.ProductId});
            modelBuilder.Entity<Category>().HasData(
                new Category
                ()
                {
                    CategoryId = 1,
                    CtegoryName = "برنامه نویسی  ",
                    Description = "یرنامه نویسی وب برای همه "

                },
                    new Category
                ()
                    {
                        CategoryId = 2,
                        CtegoryName = "لوازم ورزشی ",

                        Description = "لوازم ورزشی برای همه "

                    },
                        new Category
                ()
                        {
                            CategoryId = 3,
                            CtegoryName = " ساعت مچی ",
                            Description = " ساعت مچی برای همه"

                        }

            );
            modelBuilder.Entity<Item>().HasData
                (new Item()
            {
                 ItemId = 1,
                Price = 9823.4M,
                QuantityInStock = 6
            },
          new Item()
          {
              ItemId = 2,
              Price = 933.3M,
              QuantityInStock = 5
          },
          new Item()
          {
              ItemId = 3,
              Price = 332.32M,
              QuantityInStock = 7
          }

          );
            modelBuilder.Entity<Product>().HasData
                (
                new Product()
            {
                 ProductId = 1,
                ItemId = 1,
                 ProductName = "asp.net core",
                Description = "asp.netcore is do good for everyone"
            },
           new Product()
           {
               ProductId = 2,
               ItemId = 2,
               ProductName = "C# for beginners",
               Description = "C# for beginners is start for runners"
           },
           new Product()
           {
               ProductId = 3,
               ItemId = 3,
               ProductName = "C# for advanced",
               Description = "C# for advanced isn't end of story"
           }
           );
            modelBuilder.Entity<CategoryToProduct>().HasData(
              new CategoryToProduct()
              {
                  CategoryId = 1,
                  ProductId = 1,
              },
               new CategoryToProduct()
               {
                   CategoryId = 2,
                   ProductId = 1,
               },
               new CategoryToProduct()
               {
                   CategoryId = 3,
                   ProductId = 1,
               },
               new CategoryToProduct()
               {
                   CategoryId = 1,
                   ProductId = 2,
               },
               new CategoryToProduct()
               {
                   CategoryId = 2,
                   ProductId = 2,
               },
               new CategoryToProduct()
               {
                   CategoryId = 3,
                   ProductId = 2,
               },
               new CategoryToProduct()
               {
                   CategoryId = 1,
                   ProductId = 3,
               },
               new CategoryToProduct()
               {
                   CategoryId = 2,
                   ProductId = 3,
               },
               new CategoryToProduct()
               {
                   CategoryId = 3,
                   ProductId = 3,
               }
              );



            base.OnModelCreating(modelBuilder);
        }




    }
}
