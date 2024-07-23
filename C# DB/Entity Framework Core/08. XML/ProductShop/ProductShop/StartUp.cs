using Microsoft.EntityFrameworkCore;
using System.Xml;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //string xmlUser = File.ReadAllText("../../../Datasets/users.xml");
            //Console.WriteLine(ImportUsers(context, xmlUser));

            //string xmlProduct = File.ReadAllText("../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(context, xmlProduct));

            //string xmlCategory = File.ReadAllText("../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(context, xmlCategory));

            //string xmlcategoryProduct = File.ReadAllText("../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, xmlcategoryProduct));

            Console.WriteLine(GetProductsInRange(context));
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(UserImportDTO[]), new XmlRootAttribute("Users"));

            UserImportDTO[] import;
            using (var reader = new StringReader(inputXml))
            {
                import = (UserImportDTO[])xmlSerializer.Deserialize(reader);
            }
            //reader

            User[] users = import
                .Select(u => new User
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,

                })
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ProductImportDTO[]), new XmlRootAttribute("Products"));

            ProductImportDTO[] import;
            using (var reader = new StringReader(inputXml))
            {
                import = (ProductImportDTO[])xmlSerializer.Deserialize(reader);
            }

            Product[] users = import
                .Select(u => new Product
                {
                    Name = u.Name,
                    Price = u.Price,
                    BuyerId = u.BuyerId,
                    SellerId = u.SellerId,

                })
                .ToArray();

            context.Products.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryImportDTO[]), new XmlRootAttribute("Categories"));

            CategoryImportDTO[] import;
            using (var reader = new StringReader(inputXml))
            {
                import = (CategoryImportDTO[])xmlSerializer.Deserialize(reader);
            }

            var users = import
                //.Where(x => x.Name != null)
                .Select(x => new Category
                {
                    Name = x.Name
                })
                .ToList();

            context.Categories.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            using var reader = new StringReader(inputXml);

            var serializer = new XmlSerializer(typeof(CategoryProductImportDTO[]),
                new XmlRootAttribute("CategoryProducts"));

            var categoryProductDTOs = (CategoryProductImportDTO[])serializer.Deserialize(reader);

            var categoryProducts = categoryProductDTOs
                .Select(d => new CategoryProduct
                {
                    CategoryId = d.CategoryId,
                    ProductId = d.ProductId
                })
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ProductInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .Take(10)
                .ToArray();

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var serializer = new XmlSerializer(
                typeof(ProductInRangeDto[]),
                new XmlRootAttribute("Products"));
            serializer.Serialize(writer, products, ns);

            var productsXml = writer.GetStringBuilder();

            return productsXml.ToString().TrimEnd();
        }
        
    }
}