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
    internal class ReportUI
    {

        private ControllerLogin _login;
        private Register _register;
        private ControllerReport _report;

        public ReportUI(ControllerLogin login, Register register , ControllerReport report)
        {
            _login = login;
            _register = register;
            _report = report;
        }
        public void MenuReport(Person ReporterPerson)
        {
            int choice = 0;
            bool IsExit = false;

            while (!IsExit)
            {
                Console.WriteLine(" 1.enter report about exsisted target  \n" +
                                  " 2.enter  report about new target  ");
                int.TryParse(Console.ReadLine(), out choice);

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Please enter code name");
                            Person person = _login.Login(Console.ReadLine());
                            if (person.Id>0)
                            {
                                createReport(person, ReporterPerson);
                                IsExit = true;

                            }
                            break;

                        case 2:
                            Console.WriteLine("Enter full name :");
                            string fullName = Console.ReadLine();
                            Console.WriteLine("Enter phone number :");
                            
                            string phoneNumber = Console.ReadLine();
                            if (ReporterPerson.PhoneNumber == phoneNumber)
                            {
                                throw new Exception("You cannot report on yourself!");
                            }

                            person = new Person
                            {
                                FullName = fullName,
                                PhoneNumber = phoneNumber,
                                Type = EnumReporterType.reported
                            };

                            string codeName = _register.RegisterPerson(person);
                            Console.WriteLine($"The code name : {codeName}");
                            
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

        private void createReport(Person person, Person reporterPerson)
        {
            Console.WriteLine("enter report");

            Report report = new Report
            {
                content = Console.ReadLine()

            };
               _report.CreateReport(personReported,report, reporterPerson);
        }
    }
}
