using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformation;
using System.Windows.Forms;

namespace EmployeeInformationTests
{
    [TestClass]
    public class PropertyTests
    {
        private const string GOODEMPNUM = "1265";
        private const string EMPNUMSEARCH = "1234";
        private const string BADEMPNAME = "9486";
        private const string EMPNAMEFAIL = "156g";
        private const string GOODNAME = "Olof Strandberg";
        private const string NAMENOTFOUND = "Tobias Eriksson";
        private const string GOODADRESS = "Pilgatan 5";
        private const City GOODCITY = City.Nagpur;
        private const State GOODSTATE = State.Punjab;
        private const int GOODAGE = 21;
        private static DateTime GOODDOB = new DateTime(1999, 04, 14);
        private static List<Hobbies> GOODHOBBIES = new List<Hobbies>() { Hobbies.Singing, Hobbies.Sleeping, Hobbies.Dancing };
        private const bool TRUEBOOL = true;
        private const string GOODGENDER = "Male";
        private TextBox details = new TextBox();
        private ListBox listBox = new ListBox();
        private const string UPDATENAME = "Olof Strandberg";
        private const string UPDATEADRESS = "Danskavägen 4";
        private const City UPDATECITY = City.Mumbai;
        private const State UPDATESTATE = State.MP;
        private const int UPDATEAGE = 35;
        private DateTime UPDATEDOB = new DateTime(1985, 09, 21);
        private List<Hobbies> UPDATEHOBBIES = new List<Hobbies>() { Hobbies.Gardening, Hobbies.Swimming, Hobbies.Painting };
        private const bool UPDATEGENDER = false;

        [TestMethod]
        public void PropertyAge_IsCorrect_LowerBoundaryOver()
        {
            Employee emp = new Employee();
            emp.Age = 19;
            Assert.AreEqual(19, emp.Age);
        }

        [TestMethod]
        public void PropertyAge_IsCorrect_LowerBoundary()
        {
            Employee emp = new Employee();
            emp.Age = 18;
            Assert.AreEqual(18, emp.Age);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PropertyAge_Incorrect_LowerBoundary()
        {
            Employee emp = new Employee();
            emp.Age = 17;
            Assert.Fail();
        }

        [TestMethod]
        public void PropertyAge_IsCorrect_UpperBoundaryUnder()
        {
            Employee emp = new Employee();
            emp.Age = 59;
            Assert.AreEqual(59, emp.Age);
        }

        [TestMethod]
        public void PropertyAge_IsCorrect_UpperBoundary()
        {
            Employee emp = new Employee();
            emp.Age = 60;
            Assert.AreEqual(60, emp.Age);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PropertyAge_Incorrect_UpperBoundary()
        {
            Employee emp = new Employee();
            emp.Age = 61;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PropertyEmpNum_IncorrectUpper()
        {
            Employee emp = new Employee();
            emp.EmpNum = "12345";
            Assert.Fail();
        }

        [TestMethod]
        public void PropertyEmpNum_IsCorrect()
        {
            Employee emp = new Employee();
            emp.EmpNum = "5555";
            Assert.AreEqual("5555", emp.EmpNum);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PropertyEmpNum_IncorrectLower()
        {
            Employee emp = new Employee();
            emp.EmpNum = "";
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PropertyEmpNum_Incorrect_ContainsLetters()
        {
            Employee emp = new Employee();
            emp.EmpNum = "12h3";
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PropertyEmpNum_Incorrect_ContainSpecialCharacters()
        {
            Employee emp = new Employee();
            emp.EmpNum = "12*3";
            Assert.Fail();
        }
    }
}
