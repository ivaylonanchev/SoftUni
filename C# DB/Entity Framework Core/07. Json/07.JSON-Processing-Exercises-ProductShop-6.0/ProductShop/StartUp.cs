using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //string textUsers = File.ReadAllText("../../../Datasets/products.json");
            //string textProducts = File.ReadAllText("../../../Datasets/products.json");
            //string textCategoryProducts = File.ReadAllText("../../../Datasets/products.json");
            //string textCategories = File.ReadAllText("../../../Datasets/products.json");

            //Console.WriteLine(ImportUsers(context, textUsers));
            //Console.WriteLine(ImportProducts(context, textProducts));
            //Console.WriteLine(ImportCategories(context, textCategories));
            //Console.WriteLine(ImportCategoryProducts(context, textCategoryProducts));

            //Console.WriteLine(GetProductsInRange(context));
            Console.WriteLine(GetUsersWithProducts(context));
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            categories.RemoveAll(c => c.Name == null);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoriesProducts.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .OrderBy(p => p.price)
                .ToList();

            var jsonText = JsonConvert.SerializeObject(products, Formatting.Indented);

            return jsonText;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName

                    })
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToList();

            var jsonText = JsonConvert.SerializeObject(users, Formatting.Indented);
            return jsonText;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = c.CategoriesProducts
                    .Average(a => a.Product.Price)
                    .ToString("f2"),
                    totalRevenue = c.CategoriesProducts
                    .Sum(a => a.Product.Price)
                    .ToString("f2")
                })
                .OrderByDescending(c => c.productsCount)
                .ToList();

            var jsonText = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return jsonText;
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null && p.Price != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null && p.Price != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                        .ToArray()
                })
                .OrderByDescending(u => u.SoldProducts.Length)
                .ToArray();

            var output = new
            {
                UsersCount = users.Length,
                Users = users.Select(u => new
                {
                    u.LastName,
                    u.Age,
                    SoldProducts = u.SoldProducts.Select(s => new
                    {
                        Count = u.SoldProducts.Length,
                        Products = new
                        {
                            s.Name,
                            s.Price
                        }
                    })

                })
            };

            var jsonText = JsonConvert.SerializeObject(output, Formatting.Indented);
            return jsonText;
        }

    }
}