using LR8.Models;

namespace LR8
{
    public class ProductRepository
    {
        static List<Product> Products = new List<Product>();

        public static IList<Product> GetProductList() => Products;

        public static void init()
        {
            Products = new List<Product> {
            new Product("test1", 123.123, DateTime.Today.AddDays(-2)),
            new Product("test2", 312125125215.89, DateTime.Today.AddDays(-5)),
            new Product("test3", 1.1, DateTime.Today.AddDays(-3)),
            new Product("test4", 322.228, DateTime.Today),
            };
        }

        public static bool AddProduct(Product? product)
        {
            if (product == null)
            {
                return false;
            }

            Products.Add(product);

            return true;
        }
    }
}
