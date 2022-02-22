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
            Functions functions = new Functions();

            //use of try, catch, finally block
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
                                Console.Clear();
                                Patientclass test = new Patientclass("0000", "Default", 0);
                                Console.WriteLine("Patient ID?");
                                string IDinput = Console.ReadLine();
                                Console.WriteLine("Patient Name?");
                                string NameInput = Console.ReadLine();
                                Console.WriteLine("Patient balance due?");
                                double balanceInput = int.Parse(Console.ReadLine());
                                test.writePatientData(IDinput, NameInput, balanceInput);
                                break;
                            case 2:
                                ListPatientData listPatientData = new ListPatientData();
                                Console.Clear();
                                listPatientData.print();
                                break;
                            case 3:
                                SpecificPatient specificPatient = new SpecificPatient();
                                Console.Clear();
                                Console.Write("Patient ID?\n");
                                int ID = int.Parse(Console.ReadLine());
                                specificPatient.print(ID);
                                break;
                            case 4:
                                MinBalanceDue minBalanceDue = new MinBalanceDue();
                                Console.Clear();
                                Console.Write("Minimum balance due?\n");
                                double balance = int.Parse(Console.ReadLine());
                                minBalanceDue.print(balance);

                                break;
                            case 5:
                                wait = false;
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                functions.inputWait();

                                break;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        functions.inputWait();
                    }
                    
                }
                while (wait);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                functions.inputWait();
            }
            finally
            {
                Console.WriteLine("***Exiting applicaiton***");
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
                Console.WriteLine("Press any key to continue.");
                System.Console.ReadKey();
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

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                functions.inputWait();
            }
        }

        /// <summary>
        /// Class to solve for part C. 
        /// Prompt for patient ID number, read the patient file, then display the specified record.
        /// </summary>
        class SpecificPatient
        {
            Functions functions = new Functions();
            public void print(int id)
            {
                Console.WriteLine($"Patient {id}:");

                string[] lines = System.IO.File.ReadAllLines(@"Patients.txt");
                foreach(string line in lines)
                {
                    string[] words = lines.Split(' ');

                }

                functions.inputWait();
            }

        }

        /// <summary>
        /// Class to solve for part D. 
        /// Prompt for a minimum balance due, read the patient file, and display all records with a balance
        /// due greater than or equal to the value entered.
        /// </summary>
        class MinBalanceDue
        {
            Functions functions = new Functions();
            public void print(double balance)
            {

                functions.inputWait();
            }
        }

    }
}
