using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChap17FileIOApp
{
    /// <summary>
    /// Class to solve for part B. 
    /// Read patient data file and list patient data on screen.
    /// </summary>
    class ListPatientData
    {
        Functions functions = new Functions();
        public void print()
        {
            Console.WriteLine("Patient data:");

            string[] lines = System.IO.File.ReadAllLines(@"Patients.txt");
            bool labels = false;
            int i = 0;
            foreach (string line in lines)
            {
                string[] words = lines[i].Split(' ');//parse each word of the current line

                if (labels == false)
                {
                    Console.WriteLine("{0,-10}{1,-20}{2,-15}",
                    "ID",
                    "Name",
                    "Balance due");
                    labels = true;
                }

                Console.WriteLine("{0,-10}{1,-20}{2,-10}",
                    words[0],
                    words[1],
                    $"{ words[2]:C}");
                i++;
            }
            functions.inputWait();
        }
    }
}