using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Class of functions I created to reuse within this project
/// </summary>

namespace ConsoleChap17FileIOApp
{
    internal class Functions
    {
        ///Function to wait for user input to continue
        public void inputWait()
        {
            Console.WriteLine("Press any key to continue.");
            System.Console.ReadKey();
        }
    }
}