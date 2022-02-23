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
                                string ID = Console.ReadLine();
                                specificPatient.print(ID);
                                break;
                            case 4:
                                MinBalanceDue minBalanceDue = new MinBalanceDue();
                                Console.Clear();
                                Console.Write("Minimum balance due?\n");
                                double balance = double.Parse(Console.ReadLine());
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
    }
}
