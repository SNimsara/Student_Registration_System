using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentDetailsManagementAndRegistrationSystem_sn
{
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Nipuna\source\repos\StudentDetailsManagementAndRegistrationSystem_sn\StudentDetailsManagementAndRegistrationSystem_sn\StudentDB.mdf;Integrated Security = True");

        private void btnSave_Click_1(object sender, EventArgs e)
        {//code starts here
            try
            {
                string NIC = (txtNIC.Text);
                string FirstName = (txtFirstName.Text);
                string LastName = (txtLastName.Text);
                string Email = (txtEmail.Text);
                string Address = (txtAddress.Text);
                string TelephoneNum = (txtTelephoneNum.Text);
                string Gender;
                if (rbMale.Checked)
                {
                    Gender = "Male";
                }
                else
                {
                    Gender = "Female";
                }
                string Subject = comboBox1.Text;
                string insert = "INSERT INTO Teacher VALUES('" + NIC + "', '" + FirstName + "', '" + LastName + "', '" + Email + "', '" + Address + "', '" + TelephoneNum + "', '" + Gender + "', '" + Subject + "')";
                SqlCommand cmd = new SqlCommand(insert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {//code starts here
            try
            {
                string NIC = (txtNIC.Text);
                string FirstName = (txtFirstName.Text);
                string LastName = (txtLastName.Text);
                string Email = (txtEmail.Text);
                string Address = (txtAddress.Text);
                string TelephoneNum = (txtTelephoneNum.Text);
                string Gender;
                if (rbMale.Checked)
                {
                    Gender = "Male";
                }
                else
                {
                    Gender = "Female";
                }
                string Subject = comboBox1.Text;

                string update = "UPDATE Teacher SET FirstName='" + FirstName + "', LastName='" + LastName + "', Email='" + Email + "', Address='" + Address + "', TelephoneNum='" + TelephoneNum + "', Gender='" + Gender + "', Subject='" + Subject + "' WHERE NIC='" + NIC + "'";
                SqlCommand cmd = new SqlCommand(update, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully !");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally 
            { 
                con.Close(); 
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {//code starts here
            try
            {
                string NIC = (txtNIC.Text);

                string Delete = "DELETE FROM Teacher WHERE NIC='" + NIC + "'";
                SqlCommand cmd = new SqlCommand(Delete, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {//code starts here
            try
            {
                string NIC = (txtSearch.Text);
                string Search = "SELECT*FROM Teacher WHERE NIC='" + NIC + "'";
                SqlCommand cmd = new SqlCommand(Search, con);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    txtNIC.Text = r[0].ToString();
                    txtFirstName.Text = r[1].ToString();
                    txtLastName.Text = r[2].ToString();
                    txtEmail.Text = r[3].ToString();
                    txtAddress.Text = r[4].ToString();
                    txtTelephoneNum.Text = r[5].ToString();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string Gender = r[6].ToString();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    if (Gender == "Male")
                    {
                        rbMale.Checked = true;
                    }
                    else
                    {
                        rbFemale.Checked = true;
                    }
                    comboBox1.Text = r[7].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu bk = new MainMenu();
            this.Hide();
            bk.Show();
        }
    }
}
