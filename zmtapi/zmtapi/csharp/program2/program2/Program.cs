using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer c1= new Customer( "leno" , "lenovo");

            c1.printfullname();
            Console.ReadLine();
        }
        
    }

    class Customer
    {
        string _fname;
        string _lname;


        public Customer(string fname, string lname)
        {

            this._fname = fname; 
            this._lname = lname;
        }

        public void printfullname()
        {
            Console.WriteLine("fullname={0}" , this._fname +" "+ this._lname);
        }

        ~Customer() 
        { }
    }
}
