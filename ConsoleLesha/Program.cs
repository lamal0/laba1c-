using System;
using System.Collections.Generic;


namespace ConsoleLesha
{

    
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductAddingDelegate a = new(OutterMethod);

            WebShop.Start(OutterMethod);
        }
        static void OutterMethod(IProduct product)
        {
            Console.Clear();
            Console.WriteLine($"New product added to your cart! it will be ready: {product.Finished}");
        }
    }
}
