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
namespace Project__Petrol_bunk
{
    public partial class manager : Form
    {
        public manager()
        {
            InitializeComponent();
        }

        private void manager_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "SERVER=DESKTOP-3MUST40\\SQLEXPRESS; Database=master; Integrated Security=true";
            try
            {
                con.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection failed");
            }
            if (con.State == ConnectionState.Open)
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                comm.CommandText = "select fueltype, sum(litres) from bills where billdate='" + date + "' group by fueltype";

                SqlDataReader dr = comm.ExecuteReader();
                listBox1.Items.Clear();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr.GetString(0) + " : " + dr.GetInt32(1));
                }
                dr.Close();


                comm.CommandText = "select Sum(total) from bills where billdate='" + date + "'";
                string total = comm.ExecuteScalar().ToString();

                listBox1.Items.Add("Total :" + total);
            }
        }
    }
}
