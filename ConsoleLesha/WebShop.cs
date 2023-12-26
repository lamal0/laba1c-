using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace ConsoleLesha
{
    internal class WebShop
    {
        public static void Start(ProductAddingDelegate method)
        {
            using (WSContext db = new WSContext())
            {
                User user;
                string temp;
                do
                {
                    Console.Write("Enter your username(or 0 for new user):");
                    temp = Console.ReadLine();
                    Console.Clear();
                } while (temp != "0" && !db.Users.Any(u => u.Username == temp));
                if (temp == "0")
                {
                    user = new User();
                    user.InitializeUser(db);
                    db.Users.Add(user);
                }
                else
                {
                    user = db.Users.Include(u => u.Cart).Single(u => u.Username == temp);
                }
                while (true)
                {
                    MainMenu();
                    switch (Choose())
                    {
                        case 0:
                            do
                            {
                                Console.Clear();
                                Cart(user);
                            } while (CartManagement(user) != 0);
                            break;
                        case 1:
                            do
                            {
                                CreationList();
                            } while (ProdCreator(user) != 0);
                            break;
                        case 2:
                            db.SaveChanges();
                            return;
                    }
                }
            }
            /*User user = new User("lesha", "lamal", "lamal0@kpi.ua");
            while (true)
            {
                MainMenu();
                switch (Choose())
                {
                    case 0:
                        do
                        {
                            Console.Clear();
                            Cart(user);
                        } while (CartManagement(user) != 0);
                        break;
                    case 1:
                        do
                        {
                            CreationList();
                        } while (ProdCreator(user) != 0);
                        break;
                    case 2:
                        return;
                        
                }*/

        }
        static void CreationList()
        {
            Console.Clear();
            Console.WriteLine("0.Return.\n" +
                              "1.Add new helmet to cart.\n" +
                              "2.Add new ski pole to cart.\n" +
                              "3.Add new ski to cart.\n" +
                              "4.Add new ski boot to cart.\n");
        }
        static int ProdCreator(User user)
        {
            if (uint.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out uint choose) && choose <= 6)
            {
                if (choose == 0)
                {
                    return 0;
                }
                AddProduct(user, choose);
            }
            return 1;
        }
        static void AddProduct(User user, uint choose)
        {
            Console.Clear();
            Console.Write("Enter product color:");
            string color = Console.ReadLine();
            Console.Clear();
            Console.Write("Enter product description:");
            string description = Console.ReadLine();

            DateTime started = DateTime.Now;
            DateTime finished = started.AddHours(48);

            switch (choose)
            {
                case 1:
                    Console.Clear();
                    int helmetChoose = 0;
                    while (helmetChoose > 3 || helmetChoose < 1)
                    {
                        Console.Write("Choose size:\n1)m;\n2)s;\n3)l;\n");
                        helmetChoose = int.Parse(Console.ReadLine());
                    }
                    Size helmetSize = Size.s;
                    switch (helmetChoose)
                    {
                        case 1:
                            helmetSize = Size.s;
                            break;
                        case 2:
                            helmetSize = Size.m;
                            break;
                        case 3:
                            helmetSize = Size.l;
                            break;
                    }

                    user.AddProduct(new HelmetProduct(color, description, started, finished, helmetSize));
                    Console.WriteLine("Product added to cart!");
                    Console.ReadKey();
                    return;
                case 2:
                    Console.Clear();
                    Console.Write("Enter pole length:");
                    string poleLength = Console.ReadLine();
                    Console.Clear();
                    Console.Write("Enter pole weight:");
                    string weight = Console.ReadLine();
                    Console.Clear();
                    user.AddProduct(new SkiPoleProduct(color, description, started, finished, poleLength, weight));
                    Console.WriteLine("Product added to cart!");
                    Console.ReadKey();
                    return;
                case 3:
                    Console.Clear();
                    Console.Write("Enter ski length:");
                    string skiLength = Console.ReadLine();
                    Console.Clear();
                    Console.Write("Enter ski width:");
                    string width = Console.ReadLine();
                    Console.Clear();
                    user.AddProduct(new SkiProduct(color, description, started, finished, skiLength, width));
                    Console.WriteLine("Product added to cart!");
                    Console.ReadKey();
                    return;
                case 4:
                    Console.Clear();
                    Console.Write("Enter size in us system:");
                    string size = Console.ReadLine();
                    Console.Clear();
                    int bootsChoose = 0;
                    while (bootsChoose > 3 || bootsChoose < 1)
                    {
                        Console.Write("Enter type:\n1)Junior;\n2)Middle;\n3)Senior;");
                        bootsChoose = int.Parse(Console.ReadLine());
                    }
                    Type type = Type.Junior;
                    switch (bootsChoose)
                    {
                        case 1:
                            type = Type.Junior;
                            break;
                        case 2:
                            type = Type.Middle;
                            break; 
                        case 3:
                            type = Type.Senior;
                            break;
                    }
                    Console.Clear();
                    user.AddProduct(new SkiBootsProduct(color, description, started, finished, size, type));
                    Console.WriteLine("Product added to cart!");
                    Console.ReadKey();
                    return;
            }
        }
        static int CartManagement(User user)
        {
            if (uint.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out uint choose) && choose <= user.Cart.Count)
            {
                if (choose == 0)
                {
                    return 0;
                }
                CartProductManagement(user, user.Cart[(int)choose - 1]);
            }
            return 1;
        }
        static void CartProductManagement(User user, Product product)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(product);
                Console.WriteLine("0.Return.\n" +
                                  "1.Remove this product.");
                switch (Choose())
                {
                    case 0:
                        return;
                    case 1:
                        user.Cart.Remove(product);
                        Console.Clear();
                        Console.WriteLine("Removed from cart successfuly!");
                        Console.ReadKey();
                        return;
                }
            }
        }
        static void Cart(User user)
        {
            Console.WriteLine($"Developing: {user.Cart.Where(p => p.Status == Status.Developing).Count()} " +
                $"/ NotStarted: {user.Cart.Where(p => p.Status == Status.NotStarted).Count()} " +
                $"/ ReadyToShip: {user.Cart.Where(p => p.Status == Status.ReadyToShip).Count()}");
            Console.WriteLine("My cart:");
            Console.WriteLine("0.Return.");
            foreach (Product product in user.Cart)
            {
                Console.WriteLine($"{user.Cart.IndexOf(product) + 1}.{product}");
            }
        }
        static int Choose()
        {
            while (true)
            {
                if (uint.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out uint choose))
                {
                    return (int)choose;
                }
            }
        }
        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Select option:\n" +
                              "0.See my cart.\n" +
                              "1.Add new product to cart.\n" +
                              "2.Exit.\n");
        }
    }
}

