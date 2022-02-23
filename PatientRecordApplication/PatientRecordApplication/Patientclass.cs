using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ConsoleChap17FileIOApp
{
    /// <summary>
    /// Class to solve for part A. Main patient class to allow doctor staff to enter data about patients.
    /// </summary>
    internal class Patientclass
    {
        public string IDNumber { get; set; }
        public string patientName { get; set; }
        public double balanceOwed { get; set; }
        Functions functions = new Functions();


        public Patientclass(string ID, string name, double balance)
        {
            IDNumber = ID;
            patientName = name;
            balanceOwed = balance;

        }

        /// <summary>
        /// Write patient data to file "Patients.txt"
        /// </summary>
        /// <param name="input"></param>
        /// <param name="file"></param>
        /// <param name="writer"></param>
        public void writePatientData(string ID, string name, double balance)
        {

            string patientFile = @"Patients.txt";
            //Open file if it exists. If not create a file
            if (File.Exists(patientFile))
            {
                Console.WriteLine($"File {patientFile} exists.");
                Console.WriteLine("Opening file....");
                StreamWriter writer = File.AppendText(patientFile);
                Console.Write("Writing input data to file....\n");
                writer.WriteLine($"{ID} {name} {balance}");
                writer.Close();
            }
            else
            {
                Console.WriteLine($"File {patientFile} does not exist already.");
                Console.WriteLine("Creating file....");
                FileStream fs = new FileStream(patientFile, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);
                Console.Write("Writing input data to file....\n");
                writer.WriteLine($"{ID} {name} {balance}");
                writer.Close();
                fs.Close();
            }
            functions.inputWait();
        }
    }
}