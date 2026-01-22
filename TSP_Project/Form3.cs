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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        string ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = F:\6сем\к.пр.ТСП\project.mdb";
        OleDbConnection dbConnection = new OleDbConnection();
        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Delivery ID";
            label2.Text = "Product ID";
            label3.Text = "Company ID";
            label4.Text = "Delivery Number";
            label5.Text = "Delivery Date";
            label6.Text = "Quantity";
            button1.Text = "Add Delivery";
            button2.Text = "Edit Delivery";
            button3.Text = "Delete Delivery";
            button6.Text = "Back";
            DisplayData();
        }

        private void DisplayData()
        {
            string MySelect = "select * from Delivery";
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
            string MySelect = "insert into Delivery(ProductID, CompanyID, DelNumber, DelDate, DelQuantity)values(" + textBox2.Text + ", " + textBox3.Text + ", " + textBox5.Text + ", '" + dateTimePicker1.Text + "', " + textBox6.Text + ")";
            OleDbCommand dbCommand = new OleDbCommand(MySelect, dbConnection);
            dbConnection.Open();
            dbCommand.CommandText = MySelect;
            dbCommand.Connection = dbConnection;
            dbCommand.ExecuteNonQuery();
            MessageBox.Show("Delivery added");
            dbConnection.Close();
            DisplayData();

            dbConnection.ConnectionString = ConnectionString;
            MySelect = "update Product set Quantity = Quantity +" + textBox6.Text + " where ProductID =" + textBox2.Text;
            dbCommand = new OleDbCommand(MySelect, dbConnection);
            dbConnection.Open();
            dbCommand.CommandText = MySelect;
            dbCommand.Connection = dbConnection;
            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbConnection.ConnectionString = ConnectionString;
            string MySelect = "update Delivery set DelQuantity = " + textBox6.Text + " where DeliveryID =" + textBox1.Text;
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
            string MySelect = "delete from Delivery where DeliveryID = " + textBox1.Text;
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
