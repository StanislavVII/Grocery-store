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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = F:\6сем\к.пр.ТСП\project.mdb";
        OleDbConnection dbConnection = new OleDbConnection();
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "ID";
            label2.Text = "Code";
            label3.Text = "Name";
            label4.Text = "Expiry date";
            label5.Text = "Price";
            label6.Text = "Quantity";
            button1.Text = "Add Product";
            button2.Text = "Edit Product";
            button3.Text = "Delete Product";
            button4.Text = "Low Quantity";
            button5.Text = "Sell Product";
            button6.Text = "Back";
            button7.Text = "Sales history";
            DisplayData();
        }

        private void DisplayData() 
        {
            string MySelect = "select * from Product";
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
            string MySelect = "insert into Product(PrCode, [PrName], ExpDate, Price, Quantity)values(" + textBox2.Text + ", '" + textBox3.Text + "', '" + dateTimePicker1.Text + "', " + textBox5.Text + ", " + textBox6.Text + ")";
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
            string MySelect = "update Product set Quantity = '" + textBox6.Text + "' where ProductID =" + textBox1.Text;
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
            string MySelect = "delete from Product where ProductID = " + textBox1.Text;
            OleDbCommand dbCommand = new OleDbCommand(MySelect, dbConnection);
            dbConnection.Open();
            dbCommand.CommandText = MySelect;
            dbCommand.Connection = dbConnection;
            dbCommand.ExecuteNonQuery();
            MessageBox.Show("Record delete");
            dbConnection.Close();
            DisplayData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
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
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
                dbConnection.ConnectionString = ConnectionString;
                string MySelect = "update Product set Quantity = Quantity-" + textBox6.Text + " where [PrName] ='" + textBox3.Text + "' and Quantity >= "+ textBox6.Text ;
                OleDbCommand dbCommand = new OleDbCommand(MySelect, dbConnection);
                dbConnection.Open();
                dbCommand.CommandText = MySelect;
                dbCommand.Connection = dbConnection;
                int count=dbCommand.ExecuteNonQuery();
                dbConnection.Close();
                DisplayData();
            if (count > 0)
            {
                MessageBox.Show("Product Sold");

                dbConnection.ConnectionString = ConnectionString;
                MySelect = "insert into Sold (ProductID) select ProductID from Product where [PrName]='"+ textBox3.Text +"'";
                dbCommand = new OleDbCommand(MySelect, dbConnection);
                dbConnection.Open();
                dbCommand.CommandText = MySelect;
                dbCommand.Connection = dbConnection;
                dbCommand.ExecuteNonQuery();
                dbConnection.Close();

                dbConnection.ConnectionString = ConnectionString;
                MySelect = "update Sold inner join Product ON Sold.ProductID= Product.ProductID set Sold.SQuantity =" + textBox6.Text + " where [Product.PrName] ='" + textBox3.Text + "'";
                dbCommand = new OleDbCommand(MySelect, dbConnection);
                dbConnection.Open();
                dbCommand.CommandText = MySelect;
                dbCommand.Connection = dbConnection;
                dbCommand.ExecuteNonQuery();
                dbConnection.Close();

            }

            else
                MessageBox.Show("Not enough products");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show();
        }
    }
}
