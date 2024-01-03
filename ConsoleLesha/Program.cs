using ConsoleLesha;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
            /*            using (WSContext db = new WSContext())
                        {
                            User user1 = new User("lesha", "lamal", "lesha@gmail.com");
                            User user2 = new User("lesha2", "lamal2", "lesha2@gmail.com");
                            db.Users.Add(user1);
                            db.Users.Add(user2);
                            Product product = new Product("asasasa", "ssss", DateTime.Now, DateTime.Now.AddHours(3));
                            SkiProduct skiProduct = new SkiProduct("sdsds", "aaaa", DateTime.Now, DateTime.Now.AddHours(2), "qwewr", "rwqwq");
                            SkiProduct skiProduct2 = new SkiProduct("xxxx", "cccccc", DateTime.Now.AddDays(-3), DateTime.Now, "qweqe", "qweqew");
                            SkiBootsProduct skiBootsProduct = new SkiBootsProduct("1wer", "qwerty", DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1), "Qwwwww", Type.Middle);
                            user1.AddProduct(product);
                            user1.AddProduct(skiProduct);
                            user1.AddProduct(skiProduct2);
                            user2.AddProduct(product);
                            user2.AddProduct(skiProduct);
                            user2.AddProduct(skiBootsProduct);
                            db.SaveChanges();
                        }*/

            using (WSContext db = new WSContext())
            {
                var union = db.Users.Include(u => u.Cart).First().Cart.Union(db.Users.Include(u => u.Cart).First(u => u.Id == 2).Cart);
                foreach (var item in union)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("---------");

                var except = db.Users.Include(u => u.Cart).First().Cart.Except(db.Users.Include(u => u.Cart).First(u => u.Id == 2).Cart);
                foreach (var item in except)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("---------");

                var intersect = db.Users.Include(u => u.Cart).First().Cart.Intersect(db.Users.Include(u => u.Cart).First(u => u.Id == 2).Cart);
                foreach (var item in intersect)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("---------");

                var join = from u1 in db.Users.Include(u => u.Cart).First().Cart
                           join u2 in db.Users.Include(u => u.Cart).First(u => u.Id == 2).Cart on u1.Started equals u2.Started
                           select new { u1.Description, u2.Status };
                foreach (var item in join)
                {
                    Console.WriteLine(item.Description + item.Status);
                }
                Console.WriteLine("---------");

                var distinct = db.Products.Select(t => t.Description).Distinct();
                foreach (var item in intersect)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("---------");

                var groupby = from item in db.Products
                              group item by item.User into grouped
                              select new { User = grouped.Key, Count = grouped.Count() };
                foreach (var item in groupby)
                {
                    Console.WriteLine(item.User.Username + " - " + item.Count);
                }
                Console.WriteLine("---------");

                Console.WriteLine("Total tasks count" + db.Products.Count());
                Console.WriteLine("---------22");

/*                var parameter = new SqlParameter("@Type", "SkiProduct");
                var result = db.Products.FromSqlRaw("EXEC getProductsColors").ToList();


                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("---------1111");*/

                var notrack = db.Products.AsNoTracking().First();
                Console.WriteLine(notrack);
                notrack.Description = "Changed";
                Console.WriteLine(notrack);
                db.SaveChanges();
                foreach (var item in db.Products)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("---------");
            }
            using (WSContext db = new WSContext())
            {
                //eager
                var prod = db.Products.Include(s => s.User).First(s => s.Color == "sdsds");
                Console.WriteLine("Username of a task owner: " + prod.User.Username);

                //explicit
                var user = db.Users.First(u => u.Id == 1);
                db.Products.Where(t => t.UserId == 1).Load();
                Console.WriteLine("Task of user" + user.Cart.First());
            }
            //lazy
            using (WSContext db = new WSContext())
            {
                var ft = db.Users.First();
                Console.WriteLine("First:" + ft.Email);
            }


            //WebShop.Start(OutterMethod);
        }
        static void OutterMethod(Product product)
        {
            Console.Clear();
            Console.WriteLine($"New product added to your cart! it will be ready: {product.Finished}");
        }
    }
}
