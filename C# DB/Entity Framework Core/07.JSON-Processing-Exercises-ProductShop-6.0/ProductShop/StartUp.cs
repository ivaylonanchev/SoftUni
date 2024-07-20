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
            string text = File.ReadAllText("../../../Datasets/users.json");

            Console.WriteLine(ImportUsers(context, text));
            Console.WriteLine(ImportProducts(context, text));
            Console.WriteLine(ImportCategories(context, text));
            Console.WriteLine(ImportCategoryProducts(context, text));
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";    
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<Category>>(inputJson);
            var newUsers = users.Where(x => x.Name != null).ToList();

            context.AddRange(newUsers);
            context.SaveChanges();

            return null;
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.AddRange(users);
            context.SaveChanges();
            return null;
        }
    }
}