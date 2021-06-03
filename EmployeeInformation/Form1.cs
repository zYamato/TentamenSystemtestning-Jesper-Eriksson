using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeInformation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            BackEndMethods.InitiateEmpList();
        }
        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            multiListBox.Visible = false;
            List<Hobbies> hobbies = new List<Hobbies>();
            foreach(Hobbies item in chkLstHobbies.CheckedItems)
            {
                hobbies.Add(item);
            }
            if(cmbCity.SelectedItem != null && lstState.SelectedItem != null)
            {
                bool success = BackEndMethods.CreateEmployee(mskTxtEmpNo.Text, txtName.Text, txtAdress.Text, (City)cmbCity.SelectedItem, (State)lstState.SelectedItem,
                (int)numAge.Value, dtpDOB.Value, hobbies, radMale.Checked, txtDetails);

                if(success == false)
                {
                    MessageBox.Show("Something is not right in the form, check so all parameters is correct. Age and DOB must be in sync!");
                }
            }
            else
            {
                MessageBox.Show("All form boxes needs to be filled in");
            }

           

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            multiListBox.Visible = false;
            mskTxtEmpNo.Text = "";
            txtName.Text = "";
            txtAdress.Text = "";
            cmbCity.SelectedIndex = -1;
            lstState.SelectedIndex = -1;
            dtpDOB.Value = DateTime.Now;
            numAge.Value = numAge.Minimum;
            radMale.Checked = false;
            radFemale.Checked = false;
            for (int i = 0; i < chkLstHobbies.Items.Count; i++)
            {
                chkLstHobbies.SetItemChecked(i, false);
            }
            chkLstHobbies.ClearSelected();
            txtDetails.Text = "";
            mskTxtEmpNo.Focus();

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to Exit?????", "Closing Application", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            this.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            multiListBox.Visible = false;
            bool success = BackEndMethods.SearchMethod(mskTxtEmpNo.Text, txtDetails, txtName.Text, multiListBox);
            if(success == false)
            {
                MessageBox.Show("Search failed, EmpNum or Name could not be found");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<Hobbies> hobbies = new List<Hobbies>();
            foreach (Hobbies item in chkLstHobbies.CheckedItems)
            {
                hobbies.Add(item);
            }
            bool success = BackEndMethods.UpdateMethod(mskTxtEmpNo.Text, txtName.Text, txtAdress.Text, (City)cmbCity.SelectedItem, (State)lstState.SelectedItem,
                dtpDOB.Value, (int)numAge.Value, hobbies, radMale.Checked);
            if(success == false)
            {
                MessageBox.Show("Update Failed");
            }
            else
            {
                MessageBox.Show($"Updated the employee with employee number {mskTxtEmpNo}");
            }
        }
        private void multiListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee tempEmp = (Employee)multiListBox.SelectedItem;
            txtDetails.Text = tempEmp.ToLongString();
        }

        
        }
    }
