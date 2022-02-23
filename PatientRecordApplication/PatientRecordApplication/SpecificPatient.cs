using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChap17FileIOApp
{
    /// <summary>
    /// Class to solve for part C. 
    /// Prompt for patient ID number, read the patient file, then display the specified record.
    /// </summary>
    internal class SpecificPatient
    {
        Functions functions = new Functions();
        public void print(string id)
        {
            Console.WriteLine($"Patient {id}:");

            string[] lines = System.IO.File.ReadAllLines(@"Patients.txt");
            int i = 0;
            bool labels = false;
            foreach (string line in lines)
            {
                string[] words = lines[i].Split(' ');//parse each word of the current line
                if (words.Contains(id))//check if id is in this line. If so print it to the screen.
                {
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
                        String.Format("{0:C}", words[2]));
                }
                i++;
            }

            functions.inputWait();
        }
    }
}