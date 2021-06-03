using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using EmployeeInformation;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace EmployeeInformationTests
{
    // OM NÅGOT TEST SKULLE MISSLYCKAS ÄR DET BARA ATT KÖRA DET IGEN SÅ KOMMER DET GÅ IGENOM. (Vet inte varför detta händer... Har försökt
    //Söka på varför det blir såhär men kan inte hitta något, Men det är i min regular expression som felet uppstår men vet inte varför)
    [TestClass]
    public class MethodsTests
    {
        private const string GOODEMPNUM = "1265";
        private const string EMPNUMSEARCH = "1234";
        private const string BADEMPNAME = "9486";
        private const string BADEMPNAME2 = "76857";
        private const string EMPNAMEFAIL = "156g";
        private const string GOODNAME = "Olof Strandberg";
        private const string NAMENOTFOUND = "Tobias Eriksson";
        private const string GOODADRESS = "Pilgatan 5";
        private const City GOODCITY = City.Nagpur;
        private const State GOODSTATE = State.Punjab;
        private const int GOODAGE = 21;
        private static DateTime GOODDOB = new DateTime(1999,04,14);
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
        public void CreateNewEmployeeTest_Succeed()
        {
            bool succeed = BackEndMethods.CreateEmployee(GOODEMPNUM, GOODNAME, GOODADRESS, GOODCITY, GOODSTATE, GOODAGE, GOODDOB, GOODHOBBIES, TRUEBOOL, details);
            Assert.IsTrue(succeed);
        }

        [TestMethod]
        public void CreateNewEmployeeTest_Fail()
        {
            bool fail = BackEndMethods.CreateEmployee(EMPNAMEFAIL, GOODNAME, GOODADRESS, GOODCITY, GOODSTATE, GOODAGE, GOODDOB, GOODHOBBIES, TRUEBOOL, details);
            Assert.IsFalse(fail);
        }

        [TestMethod]
        public void CreateNewEmployeeTest_Fail_EmpNum_Already_Exists()
        {
            BackEndMethods.InitiateEmpList();
            bool succeed = BackEndMethods.CreateEmployee(EMPNUMSEARCH, GOODNAME, GOODADRESS, GOODCITY, GOODSTATE, GOODAGE, GOODDOB, GOODHOBBIES, TRUEBOOL, details);
            Assert.IsFalse(succeed);
        }

        [TestMethod]
        public void SearchEmployeeTest_Succeed()
        {
            BackEndMethods.InitiateEmpList();
            bool succeed = BackEndMethods.SearchMethod(EMPNUMSEARCH ,details, GOODNAME, listBox);
            Assert.IsTrue(succeed);
        }

        [TestMethod]
        public void SearchEmployeeTest_Fail_EMPNAME_NOT_FOUND()
        {
            BackEndMethods.InitiateEmpList();
            bool fail = BackEndMethods.SearchMethod(BADEMPNAME, details, GOODNAME, listBox);
            Assert.IsFalse(fail);
        }

        [TestMethod]
        public void SearchEmployeeTest_Fail_NAME_NOT_FOUND()
        {
            BackEndMethods.InitiateEmpList();
            bool fail = BackEndMethods.SearchMethod(GOODNAME, details);
            Assert.IsFalse(fail);
        }

        [TestMethod]
        public void UpdateEmployeeTest_Succeed()
        {
            BackEndMethods.InitiateEmpList();
            bool succeed = BackEndMethods.UpdateMethod(EMPNUMSEARCH, UPDATENAME, UPDATEADRESS, UPDATECITY, UPDATESTATE, UPDATEDOB, UPDATEAGE, UPDATEHOBBIES, UPDATEGENDER);
            Assert.IsTrue(succeed);
        }

        [TestMethod]
        public void UpdateEmployeeTest_Fail_EMPNUM_Not_Found()
        {
            BackEndMethods.InitiateEmpList();
            bool fail = BackEndMethods.UpdateMethod(BADEMPNAME, UPDATENAME, UPDATEADRESS, UPDATECITY, UPDATESTATE, UPDATEDOB, UPDATEAGE, UPDATEHOBBIES, UPDATEGENDER);
            Assert.IsFalse(fail);
        }



    }
}
