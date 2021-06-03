using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInformation
{
    public class Employee
    {
        public string EmpNum { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
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
