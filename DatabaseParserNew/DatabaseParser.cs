using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseParser
{
    class DatabaseParser
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Controller flowController = new Controller();
            flowController.StartProgram();
        }
    }
}
