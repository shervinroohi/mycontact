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

namespace mycontact
{
    public partial class Form1 : Form
    {
        IContactRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fgrid();
        }

        private void fgrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = repository.GetAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            fgrid();
        }

        private void btnnewcontact_Click(object sender, EventArgs e)
        {
            frmaddoredit frm = new frmaddoredit();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                fgrid();
            }
        }
        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int contactid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frmaddoredit frm = new frmaddoredit();
                frm.contactid = contactid;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    fgrid();
                }
            }

        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string family = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string fullname = name + " " + family;
                if (MessageBox.Show($"Are you sure you want to remove {fullname}?","Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int contactid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    repository.Delete(contactid);
                    fgrid();
                }
            }
            else
            {
                MessageBox.Show("Please select a person from the list.");
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repository.Search(txtsearch.Text);
        }
    }
}
