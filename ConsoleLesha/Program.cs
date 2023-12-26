using ConsoleLesha;
using System;
using System.Collections.Generic;
/*using (WSContext db = new WSContext())
{
    User tom = new User("lesha", "lamal", "lamal0@kpi.ua");
    User alice = new User("lesha", "lamal", "lamal0@kpi.ua");


    // добавляем их в бд
    db.Users.Add(tom);
    db.Users.Add(alice);
    db.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");

    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Список объектов:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.FullName}");
    }
}*/


namespace ConsoleLesha
{

    
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductAddingDelegate a = new(OutterMethod);
            WebShop.Start(OutterMethod);
        }
        static void OutterMethod(Product product)
        {
            Console.Clear();
            Console.WriteLine($"New product added to your cart! it will be ready: {product.Finished}");
        }
    }
}
