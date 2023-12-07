using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLesha
{
    internal class User : IUser
    {
        string _fullName;
        string _username;
        string _email;
        List<IProduct> _cart;
        public string FullName { get { return _fullName; } }
        public string Username { get { return _username; } }
        public string Email { get { return _email; } }
        public List<IProduct> Cart { get { return _cart; } }
        public event ProductAddingDelegate OnCartUpdate;
        public User(string fullName, string username, string email)
        {
            _fullName = fullName;
            _username = username;
            _email = email;
            _cart = new List<IProduct>();
        }


        public void AddProduct(IProduct product)
        {
            _cart.Add(product);
            OnCartUpdate?.Invoke(product);
        }

    }
}
