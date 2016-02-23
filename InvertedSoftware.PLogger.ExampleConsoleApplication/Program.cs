using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvertedSoftware.PLogger.ExampleConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to start logging 1000 items.");
            Console.ReadLine();
            for (int i = 0; i < 1000; i++)
                Plogger.Log(string.Empty, true, 2, null, i.ToString());
            Console.WriteLine("Finished. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
