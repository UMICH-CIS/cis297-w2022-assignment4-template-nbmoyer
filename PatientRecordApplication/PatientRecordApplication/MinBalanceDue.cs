using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChap17FileIOApp
{
    /// <summary>
    /// Class to solve for part D. 
    /// Prompt for a minimum balance due, read the patient file, and display all records with a balance
    /// due greater than or equal to the value entered.
    /// </summary>
    internal class MinBalanceDue
    {
        Functions functions = new Functions();
        public void print(double balance)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Patients.txt");

            string printBalance = balance.ToString("C0");
            Console.WriteLine($"Patients with balance due greater than or equal to {printBalance}");
            int i = 0;
            bool labels = false;
            foreach (string line in lines)
            {
                string[] words = lines[i].Split(' ');//parse each word of the current line
                if (Convert.ToDouble(words[2]) >= balance)//check if id is in this line. If so print it to the screen.
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