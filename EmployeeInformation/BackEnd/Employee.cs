using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace EmployeeInformation
{
    public class Employee
    {
        private Regex empNumRegEx = new Regex("^[0-9]{4}$");
        private Regex nameRegEx = new Regex("^([a-zA-Z]{2,}\\s[a-zA-z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)");

        private string empNum;
        private string name;
        private int age;


        public string EmpNum 
        {
            get
            {
                return empNum;
            }
            set
            {
                if (empNumRegEx.IsMatch(value))
                    empNum = value;
                else
                    throw new ArgumentException("EmpNum must contain 4 numbers");
                    
            }
        }
        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                if (nameRegEx.IsMatch(value))
                    name = value;
                else
                    throw new ArgumentException("Name can only contain letters");
            }
        }
        public string Adress { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age 
        {
            get
            {
                return age;
            }
            set
            {
                if(value < 18 || value > 60)
                {
                    throw new ArgumentOutOfRangeException("Age must be between 18 and 60");
                }
                else
                {
                    age = value;
                }
            }
        }
        public string Gender { get; set; }
        public List<Hobbies> Hobbies { get; set; }

        public Employee()
        {

        }

        public Employee(string empNum, string name, string adress, City city, State state,
            DateTime dateOfBirth, int age, string gender, List<Hobbies> hobbies)
        {
            EmpNum = empNum;
            Name = name;
            Adress = adress;
            City = city;
            State = state;
            DateOfBirth = dateOfBirth;
            Age = age;
            Gender = gender;
            Hobbies = hobbies;
        }

        public override string ToString()
        {
            return $"{EmpNum} : {Name}";
        }

        public string ToLongString()
        {
            string details;
            details = "EmpNo: " + EmpNum;
            details += "\r\nName: " + Name;
            details += "\r\nAdress: " + Adress;
            details += "\r\nCity: " + City;
            details += "\r\nState: " + State;
            details += "\r\nDOB: " + DateOfBirth.ToShortDateString();
            details += "\r\nAge: " + Age;
            details += "\r\nGender: " + Gender;

            string hobbies = "";
            foreach (Hobbies h in Hobbies)
            {
                hobbies += h + "\r\n\t";
            }
            details += "\r\nHobbies: " + hobbies;
            return details;


        }
    }
}
