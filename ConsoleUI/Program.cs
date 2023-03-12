using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    //Abstract => soyut
    //Concrete => somut
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}