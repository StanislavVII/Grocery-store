using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace TSP_Project
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        string ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = F:\6сем\к.пр.ТСП\project.mdb";
        OleDbConnection dbConnection = new OleDbConnection();

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = "Company ID";
            label2.Text = "Company Name";
            label3.Text = "Company Address";
            label4.Text = "Representative Phone";
            label5.Text = "Representative Name";
            button1.Text = "Add Company";
            button2.Text = "Edit Company";
            button3.Text = "Delete Company";
            button6.Text = "Back";
            DisplayData();
        }

        private void DisplayData()
        {
            string MySelect = "select * from Company";
            dbConnection.ConnectionString = ConnectionString;
            dbConnection.Open();
            OleDbDataAdapter Adapt = new OleDbDataAdapter(MySelect, dbConnection);
            DataTable dt = new DataTable();
            Adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dbConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbConnection.ConnectionString = ConnectionString;
            string MySelect = "insert into Company([ComName], [ComAddress], ComPhone, [ComRepName])values('" + textBox2.Text + "', '" + textBox3.Text + "', " + textBox5.Text + ", '" + textBox6.Text + "')";
            OleDbCommand dbCommand = new OleDbCommand(MySelect, dbConnection);
            dbConnection.Open();
            dbCommand.CommandText = MySelect;
            dbCommand.Connection = dbConnection;
            dbCommand.ExecuteNonQuery();
            MessageBox.Show("Record submit");
            dbConnection.Close();
            DisplayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbConnection.ConnectionString = ConnectionString;
            string MySelect = "update Company set [ComName] = '" + textBox2.Text + "' where CompanyID =" + textBox1.Text;
            OleDbCommand dbCommand = new OleDbCommand(MySelect, dbConnection);
            dbConnection.Open();
            dbCommand.CommandText = MySelect;
            dbCommand.Connection = dbConnection;
            dbCommand.ExecuteNonQuery();
            MessageBox.Show("Record update");
            dbConnection.Close();
            DisplayData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbConnection.ConnectionString = ConnectionString;
            string MySelect = "delete from Company where CompanyID = " + textBox1.Text;
            OleDbCommand dbCommand = new OleDbCommand(MySelect, dbConnection);
            dbConnection.Open();
            dbCommand.CommandText = MySelect;
            dbCommand.Connection = dbConnection;
            dbCommand.ExecuteNonQuery();
            MessageBox.Show("Record delete");
            dbConnection.Close();
            DisplayData();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
