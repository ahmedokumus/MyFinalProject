using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    //Abstract -> soyut
    //Concrete -> somut
    //S(O)LID -> Open Closed Principle
    //DTO -> Data Transformation Objects
    internal class Program
    {
        static void Main()
        {
            EfProductTest();
            CategoryTest();
        }

        private static void CategoryTest()
        {
            var categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void EfProductTest()
        {
            var productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine("{0} --------- {1}", product.ProductName, product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}