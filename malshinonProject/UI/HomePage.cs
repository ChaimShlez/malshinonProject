using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using malshinonProject.Controller;
using malshinonProject.Entitys;
using malshinonProject.Enum;

namespace malshinonProject.UI
{
    internal class HomePage
    {
        private AnalysisUI _analysisUI;
        private ReportUI _reportUI;
        private ControllerLogin _login;
        private Register _register;
        
        public HomePage(ControllerLogin login, Register register, ReportUI reportUI AnalysisUI analysisUI)
        {
            _login = login;
            _register = register;
            _reportUI = reportUI;
            _analysisUI = analysisUI;


        }

        public void Menu()
        {
            int choice = 0;
            bool IsExit = false;

            while (!IsExit)
            {
                Console.WriteLine("1. Entry  to the system\n" +
                                  "2. Register to the system" +
                                  "3. Entry to admin ");
                int.TryParse(Console.ReadLine(), out choice);
                
               

                try
                {
                    switch (choice)
                    {
                        case 1:

                            
                            Console.WriteLine("Please enter code name");
                            Person person = _login.Login(Console.ReadLine());

                            if (person!=null)
                            {
                                _reportUI.MenuReport(person);
                                IsExit = true;
                            }
                            break;

                        case 2:
                            Console.WriteLine("Enter full name :");
                            string fullName = Console.ReadLine();
                            Console.WriteLine("Enter phone number :");
                            string phoneNumber = Console.ReadLine();

                            person = new Person
                            {
                                FullName = fullName,
                                PhoneNumber = phoneNumber,
                                Type= EnumReporterType.reporter
                            };

                           string codeName = _register.RegisterPerson(person);
                            Console.WriteLine($"The code name : {codeName}");
                            IsExit = true; 
                            break;
                        case 3:
                            Console.WriteLine("Please enter code name");
                            Person personAdmin = _login.LoginAdmin(Console.ReadLine());

                            if (personAdmin != null)
                            {
                                GetAnalysis();
                                IsExit = true;
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }



    }
}
