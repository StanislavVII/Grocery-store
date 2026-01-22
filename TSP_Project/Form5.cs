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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        string ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = F:\6сем\к.пр.ТСП\project.mdb";
        OleDbConnection dbConnection = new OleDbConnection();
        private void Form5_Load(object sender, EventArgs e)
        {
            button6.Text = "Back";
            DisplayData();
        }

        private void DisplayData()
        {
            string MySelect = "select * from Product where Quantity < 5 ";
            dbConnection.ConnectionString = ConnectionString;
            dbConnection.Open();
            OleDbDataAdapter Adapt = new OleDbDataAdapter(MySelect, dbConnection);
            DataTable dt = new DataTable();
            Adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dbConnection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
