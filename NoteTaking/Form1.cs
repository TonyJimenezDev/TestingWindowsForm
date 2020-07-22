using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTaking
{
    public partial class Form1 : Form
    {
        DataTable dataTable;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Messages", typeof(string));

            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Messages"].Visible = false;
            dataGridView1.Columns["Title"].Width = 140;
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            textTitle.Clear();
            textMessage.Clear();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textTitle.Text)) MessageBox.Show("Title cannot be left empty");
            else
            {
                dataTable.Rows.Add(textTitle.Text, textMessage.Text);

                textTitle.Clear();
                textMessage.Clear();
            }
        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            // User picksup index of selected row
            int index = dataGridView1.CurrentCell.RowIndex;

            if(index >= 0)
            {
                textTitle.Text = dataTable.Rows[index].ItemArray[0].ToString();
                textMessage.Text = dataTable.Rows[index].ItemArray[1].ToString();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            // User picksup index of selected row
            int index = dataGridView1.CurrentCell.RowIndex;

            dataTable.Rows[index].Delete();
        }
    }
}
