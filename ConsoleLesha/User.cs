using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLesha
{
    public delegate void ProductAddingDelegate(Product product);

    public class User
    {
        int _id;
        string _fullName;
        string _username;
        string _email;
        List<Product> _cart;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get { return _id; } private set { _id = value; } }
        public string FullName { get { return _fullName; } private set { _fullName = value; } }
        [MaxLength(25)]
        [Required]
        public string Username { get { return _username; } private set { _username = value; } }
        [MaxLength(30)]
        [Required]
        public string Email { get { return _email; } private set { _email = value; } }
        public List<Product> Cart { get { return _cart; } private set { _cart = value; } }

        public event ProductAddingDelegate OnCartUpdate;
        public User()
        {
            _cart = new List<Product>();
        }
        public User( string fullName, string username, string email)
        {
            _fullName = fullName;
            _username = username;
            _email = email;
            _cart = new List<Product>();
        }


        public void AddProduct(Product product)
        {
            _cart.Add(product);
            OnCartUpdate?.Invoke(product);
        }

        public void InitializeUser(WSContext db)
        {
            Console.WriteLine("Enter your full name: ");
            string fullName = Console.ReadLine();
            Console.Clear();
            string email = null;
            string username = null;
            while (email == null)
            {
                Console.WriteLine("Enter your email: ");
                email = Console.ReadLine();
                if (email.Length > 30)
                {
                    Console.Clear();
                    Console.WriteLine("Too long email try again!!!");
                    email = null;
                }
                else if (db.Users.Any(u => u.Email == email))
                {
                    Console.Clear();
                    Console.WriteLine("Email already using!!!");
                    email = null;
                }
            }
            while (username == null)
            {
                Console.WriteLine("Enter your username: ");
                username = Console.ReadLine();
                if (username.Length > 25)
                {
                    Console.Clear();
                    Console.WriteLine("Too long username try again!!!");
                    username = null;
                }
                if (db.Users.Any(u => u.Username == username))
                {
                    Console.Clear();
                    Console.WriteLine("Username already using!!!");
                    username = null;
                }
            }
            _username = username;
            _email = email;
            _fullName = fullName;
        }

    }
}
