using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLesha
{
    //public delegate void ProductAddingDelegate(IProduct product);
    public interface IUser
    {
        int id { get; }
        string FullName { get; }
        string Username { get; }
        string Email { get; }
        List<IProduct> Cart { get; }
        //event ProductAddingDelegate OnCartUpdate;
        void AddProduct(IProduct product);
    }
}
