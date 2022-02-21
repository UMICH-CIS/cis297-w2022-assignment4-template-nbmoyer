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
    class PatientRecordSystem
    {
        static void Main(string[] args)
        {
            Patientclass test = new Patientclass("0000", "Default", 0);
            string id = "5555";

            try
            {
                bool wait = true;

                do
                {
                    Console.Clear();
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1: Doctor: save patient data to file.");
                    Console.WriteLine("2: List patient data to screen");
                    Console.WriteLine("3: Display specific patient data");
                    Console.WriteLine("4: List patients with specified minimum balance due");
                    Console.WriteLine("5: Exit");

                    try
                    {
                        int userInput = int.Parse(Console.ReadLine());
                        switch (userInput)
                        {
                            case 1:
                                test.writePatientData(id, test.patientName, test.balanceOwed);
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                //int input = int.Parse(Console.ReadLine());


                                wait = false;

                                //System.Environment.Exit(1);
                                break;
                            default:
                                Console.WriteLine("Invalid input");

                                break;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
                while (wait);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            




        }

        /// <summary>
        /// Class of functions I created to reuse within this project
        /// </summary>
        public class Functions
        {
            ///Function to wait for user input to continue

            public void inputWait()
            {
                try
                {
                    bool wait = true;
                    do
                    {
                        Console.WriteLine("\nPress 1 to continue.");

                        int input = int.Parse(Console.ReadLine());

                        if (input == 1)
                        {
                            wait = false;
                        }

                    }
                    while (wait);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Class to solve for part A. Main patient class to allow doctor staff to enter data about patients.
        /// </summary>
        class Patientclass
        {
            public string IDNumber { get; set; }
            public string patientName { get; set; }
            public double balanceOwed { get; set; }


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

                string patientFile = "Patients.txt";
                //use of try catch example
                try
                {

                    if (File.Exists(patientFile))
                    {
                        Console.WriteLine($"File {patientFile} exists.");
                        Console.WriteLine("Opening file....");
                        FileStream fs = new FileStream(patientFile, FileMode.Open, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(fs);
                        Console.Write("Writing input data to file");
                        writer.WriteLine(ID);
                        writer.WriteLine(name);
                        writer.WriteLine(balance);

                        

                        fs.Close();
                    }
                    else
                    {
                        Console.WriteLine($"File {patientFile} does not exist already.");
                        Console.WriteLine("Creating file....");
                        FileStream fs = new FileStream(patientFile, FileMode.Create, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(fs);
                        //writer.WriteLine(test);







                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                
                Functions functions = new Functions();
                functions.inputWait();

            }
        }

        /// <summary>
        /// Class to solve for part B. 
        /// Read patient data file and list patient data on screen.
        /// </summary>
        class ListPatientData
        {

        }

        /// <summary>
        /// Class to solve for part C. 
        /// Prompt for patient ID number, read the patient file, then display the specified record.
        /// </summary>
        class SpecificPatient
        {

        }

        /// <summary>
        /// Class to solve for part D. 
        /// Prompt for a minimum balance due, read the patient file, and display all records with a balance
        /// due greater than or equal to the value entered.
        /// </summary>
        class MinBalanceDue
        {

        }

    }
}
