using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataUsers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        DataTable table = new DataTable();

        public void Update()
        {
            table.Clear();
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * From Users",connetion);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            adapter.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connetion.Open();
            OleDbCommand command = new OleDbCommand("Insert into Users (FullName,City,Age) values ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"')",connetion);
            command.ExecuteNonQuery();
            connetion.Close();
            Update();
            MessageBox.Show("Added !");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connetion.Open();
            OleDbCommand command = new OleDbCommand("Delete from Users where ID=" + Convert.ToInt32(textBox4.Text),connetion);
            command.ExecuteNonQuery();
            connetion.Close();
            Update();
            MessageBox.Show("Deleted !");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Update();
        }
    }
}
