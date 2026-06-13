using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mycontact.Repository;
using mycontact.Services;
using System.Text.RegularExpressions;

namespace mycontact
{
    public partial class frmaddoredit : Form
    {
        IContactRepository repository;
        public int contactid = 0;
        public frmaddoredit()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmaddoredit_Load(object sender, EventArgs e)
        {
            if (contactid == 0)
            {
            this.Text = "add new contact";
            }
            else
            {
                this.Text = "edit person information";
                DataTable dt = repository.GetById(contactid);
                txtname.Text = dt.Rows[0][1].ToString();
                txtfamily.Text = dt.Rows[0][2].ToString();
                txtmobile.Text = dt.Rows[0][3].ToString();
                txtemail.Text = dt.Rows[0][4].ToString();
                txtage.Text = dt.Rows[0][5].ToString();
                txtAddress.Text = dt.Rows[0][6].ToString();
                btnsubmit.Text = "edit";
            }
        }
        private bool validate()
        {
            string phoneNumber = txtmobile.Text;
            string pattern = @"^09\d{9}$";
            string email = txtemail.Text;
            string pattern2= @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (txtname.Text == "")
            {
                MessageBox.Show("please enter the name", "warning",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
           else if (txtfamily.Text == "")
            {
                MessageBox.Show("please enter the family", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtmobile.Text == "")
            {
                MessageBox.Show("please enter the phone number", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(!Regex.IsMatch(phoneNumber, pattern))
            {
                MessageBox.Show("Please enter a valid phone number.\nexample:09121234567", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtage.Value ==0)
            {
                MessageBox.Show("please enter the age", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtemail.Text == "")
            {
                MessageBox.Show("please enter the email", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(!Regex.IsMatch(email, pattern2))
            {
                MessageBox.Show("Please enter a valid email.\nexample:example@gmail.com", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
            return true;
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                bool success;
                if (contactid == 0)
                {
                    success = repository.Insert(txtname.Text, txtfamily.Text, txtmobile.Text, txtemail.Text, (int)txtage.Value, txtAddress.Text);
                }
                else
                {
                    success = repository.Update(contactid,txtname.Text, txtfamily.Text, txtmobile.Text, txtemail.Text, (int)txtage.Value, txtAddress.Text);
                }
                if (success == true)
                {
                    MessageBox.Show("The operation was successful.", "successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("The operation failed.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtmobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
