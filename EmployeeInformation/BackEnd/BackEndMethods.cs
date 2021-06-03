using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeInformation
{
    public class BackEndMethods
    {
        public static List<Employee> employees = new List<Employee>();
        private static string fileName = "..\\..\\..\\EmployeeInformation\\bin\\Debug\\Values.txt";


        public static void InitiateEmpList()
        {
           // if (!File.Exists(fileName))
           // {
           //     throw new FileNotFoundException("The log file cannot be found.");
           // }
            StreamReader sr = new StreamReader(fileName);
            string line = sr.ReadToEnd();
            List<string> lineList = line.Split(',').ToList();

            employees.Add(new Employee
            {
                EmpNum = lineList[0],
                Name = lineList[1],
                Adress = lineList[2],
                City = (City)int.Parse(lineList[3]),
                State = (State)int.Parse(lineList[4]),
                DateOfBirth = new DateTime(int.Parse(lineList[5]), int.Parse(lineList[6]), int.Parse(lineList[7])),
                Age = int.Parse(lineList[8]),
                Gender = lineList[9],
                Hobbies = new List<Hobbies> { (Hobbies)int.Parse(lineList[10]), (Hobbies)int.Parse(lineList[11]), (Hobbies)int.Parse(lineList[12]) }
            }) ;
            employees.Add(new Employee
            {
                EmpNum = lineList[13],
                Name = lineList[14],
                Adress = lineList[15],
                City = (City)int.Parse(lineList[16]),
                State = (State)int.Parse(lineList[17]),
                DateOfBirth = new DateTime(int.Parse(lineList[18]), int.Parse(lineList[19]), int.Parse(lineList[20])),
                Age = int.Parse(lineList[21]),
                Gender = lineList[22],
                Hobbies = new List<Hobbies> { (Hobbies)int.Parse(lineList[23]), (Hobbies)int.Parse(lineList[24]), (Hobbies)int.Parse(lineList[25]) }
            });
            employees.Add(new Employee
            {
                EmpNum = lineList[26],
                Name = lineList[27],
                Adress = lineList[28],
                City = (City)int.Parse(lineList[29]),
                State = (State)int.Parse(lineList[30]),
                DateOfBirth = new DateTime(int.Parse(lineList[31]), int.Parse(lineList[32]), int.Parse(lineList[33])),
                Age = int.Parse(lineList[34]),
                Gender = lineList[35],
                Hobbies = new List<Hobbies> { (Hobbies)int.Parse(lineList[36]), (Hobbies)int.Parse(lineList[37]), (Hobbies)int.Parse(lineList[38]) }
            });
        }


        public static bool CreateEmployee(string empNum, string name, string adress, City city,
            State state, int age, DateTime dateOfBirth, List<Hobbies> hobby,  bool gender, TextBox details)
        {
            try
            {
                foreach (var em in employees)
                {
                    if (em.EmpNum == empNum)
                    {
                        return false;
                    }
                }
                DateTime zeroTime = new DateTime(1, 1, 1);
                TimeSpan realAge = DateTime.Now - dateOfBirth;
                int years = (zeroTime + realAge).Year - 1;
                if (years != age)
                {
                    age = years;
                }

                Employee emp = new Employee()
                {
                    EmpNum = empNum,
                    Name = name,
                    Adress = adress,
                    City = city,
                    State = state,
                    DateOfBirth = dateOfBirth,
                    Age = age,
                    Gender = gender ? "Male" : "Female",
                    Hobbies = hobby
                };

                employees.Add(emp);
                details.Text = emp.ToLongString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SearchMethod(string empNum, TextBox details, string name, ListBox multiListBox )
        {
            if (empNum != "")
            {
                foreach (Employee emp in employees)
                {
                    if (emp.EmpNum == empNum)
                    {
                        details.Text = emp.ToLongString();
                        return true;
                    }
                }
                return false;
            }
            else if (name != "")
            {
                var tempList = (from emp in employees
                                where emp.Name.Contains(name)
                                orderby emp.EmpNum
                                select emp).ToList();
                if (tempList.Count > 1)
                {
                    multiListBox.Items.Clear();
                    foreach (var em in tempList)
                    {
                        multiListBox.Items.Add(em);
                    }
                    multiListBox.SelectedIndex = 0;
                    multiListBox.Visible = true;
                    return true;
                }
                else if (tempList.Count == 1)
                {
                    details.Text = tempList[0].ToLongString();
                    return true;
                }
                return false;
            }
            return false;
        }
        public static bool SearchMethod(string empNum, TextBox details)
        {
            foreach (Employee emp in employees)
            {
                if (emp.EmpNum == empNum)
                {
                    details.Text = emp.ToLongString();
                    return true;
                }
            }
            return false;
        }
        public static bool SearchMethod(string name, TextBox details, ListBox multiListBox)
        {
            var tempList = (from emp in employees
                            where emp.Name.Contains(name)
                            orderby emp.EmpNum
                            select emp).ToList();
            if (tempList.Count > 1)
            {
                multiListBox.Items.Clear();
                foreach (var em in tempList)
                {
                    multiListBox.Items.Add(em);
                }
                multiListBox.SelectedIndex = 0;
                multiListBox.Visible = true;
                return true;
            }
            else if (tempList.Count == 1)
            {
                details.Text = tempList[0].ToLongString();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool UpdateMethod(string empNum, string name, string adress, City city, State state, DateTime dateOfBirth, int age, List<Hobbies> hobby, bool gender)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].EmpNum == empNum)
                {
                    employees[i].Name = name;
                    employees[i].Adress = adress;
                    employees[i].City = city;
                    employees[i].State = state;
                    employees[i].DateOfBirth = dateOfBirth;
                    employees[i].Age = age;
                    employees[i].Hobbies = hobby; 
                    employees[i].Gender = gender ? "Male" : "Female";
                    return true;
                }
            }
            return false;
           
        }
    }
}
