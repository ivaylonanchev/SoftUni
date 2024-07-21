using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string textUsers = File.ReadAllText("../../../Datasets/products.json");
            string textProducts = File.ReadAllText("../../../Datasets/products.json");
            string textCategoryProducts = File.ReadAllText("../../../Datasets/products.json");
            string textCategories = File.ReadAllText("../../../Datasets/products.json");

            Console.WriteLine(ImportUsers(context, textUsers));
            Console.WriteLine(ImportProducts(context, textProducts));
            Console.WriteLine(ImportCategories(context, textCategories));
            Console.WriteLine(ImportCategoryProducts(context, textCategoryProducts));

            Console.WriteLine(GetProductsInRange(context));
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

            var jsonText = JsonConvert.SerializeObject(products);

            return null;
        }
        public static string GetProductsInRange(ProductShopContext context)
    }
}