using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLesha
{
    internal delegate void ProductAddingDelegate(IProduct product);
    internal interface IUser
    {
        string FullName { get; }
        string Username { get; }
        string Email { get; }
        List<IProduct> Cart { get; }
        event ProductAddingDelegate OnCartUpdate;
        void AddProduct(IProduct product);
    }
}
