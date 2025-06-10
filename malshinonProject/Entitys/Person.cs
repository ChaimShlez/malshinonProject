using System;
using malshinonProject.Enum;

namespace malshinonProject.Entitys
{
    internal class Person
    {
        private int id;
        private string fullName;
        private string codeName;
        private string phoneNumber;
        private EnumReporterType type;

        public Person()
        {
        }

        public Person(string fullName, string codeName, string phoneNumber, EnumReporterType type)
        {
            FullName = fullName;
            CodeName = codeName;
            PhoneNumber = phoneNumber;
            Type = type;

            
        }
        public EnumReporterType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string CodeName
        {
            get { return codeName; }
            set { codeName = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public int Id
        {
            get { return id; }
            set { id= value; }
        }
    }
}
