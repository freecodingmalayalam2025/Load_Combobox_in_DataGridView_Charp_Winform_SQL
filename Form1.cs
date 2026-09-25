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

namespace WindowsFormsApp_LoadGridView_with_Combobox
{
    public partial class Form1 : Form
    {
        string strcon = @"Data Source=LAPTOP-R9MRDLN3\SQLEXPRESS;Initial Catalog=SampleDB;Integrated Security=True;Encrypt=False";
        public Form1()
        {
            InitializeComponent();
        }

        void LoadCustomer()
        {
            using(SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Country", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                DataGridViewComboBoxColumn dgvcbc = new DataGridViewComboBoxColumn();
                dgvcbc.HeaderText = "Country";
                dgvcbc.Name = "CountryName";
                dgvcbc.DataSource = dt;
                dgvcbc.DisplayMember = "Name";
                dgvcbc.ValueMember = "C_id";
                dgvcbc.DataPropertyName = "CountryId";

                DGV.Columns.Add(dgvcbc);


                SqlDataAdapter sda1 = new SqlDataAdapter("select * from customer", con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                DGV.DataSource = dt1;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCustomer();
        }
    }
}
