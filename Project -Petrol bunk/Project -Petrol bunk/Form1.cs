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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.CharacterCasing = CharacterCasing.Upper;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            listBox1.Items.Clear();
            int wheels = 0;
            int diesel = 0;
            int petrol = 0;
            double total = 0;
            double coa = 0;
            int op = 0;
            int pp = 0;
            int dp = 0;
            int cof = 0;
            int litres = 0;
            string TempWheels = "";
            listBox1.Items.Add("\t" + "   HP Petrol Bunk");
            listBox1.Items.Add("Register number : " + textBox1.Text);
            if (radioButton1.Checked)
            {
                TempWheels = radioButton1.Text;
                wheels = 2;
                listBox1.Items.Add("Vehicle type  : " + radioButton1.Text);
            }
            else if (radioButton2.Checked)
            {
                TempWheels = radioButton2.Text;
                wheels = 3;
                listBox1.Items.Add("Vehicle type : " + radioButton2.Text);
            }
            else if (radioButton3.Checked)
            {
                TempWheels = radioButton3.Text;
                wheels = 4;
                listBox1.Items.Add("Vehicle type  : " + radioButton3.Text);
            }
            if (comboBox1.SelectedItem == "Petrol")
            {
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
                    comm.CommandText = "select petrol from updateprice";
                    petrol = (int)comm.ExecuteScalar();
                    litres = (int)numericUpDown1.Value;
                    cof = litres * petrol;
                    total = total + cof;
                    listBox1.Items.Add("Fuel type :" + comboBox1.Text);
                }
            }
                else if (comboBox1.SelectedItem == "Diesel")
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = "SERVER=DESKTOP-3MUST40\\SQLEXPRESS; Database=master; Integrated Security=true";
                    try
                    {
                        conn.Open();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Connection failed");
                    }
                    if (conn.State == ConnectionState.Open)
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = conn;
                        comm.CommandText = "select diesel from updateprice";
                        diesel = (int)comm.ExecuteScalar();
                        litres = (int)numericUpDown1.Value;
                        cof = litres * diesel;
                        total = total + cof;
                        listBox1.Items.Add("Fuel type : " + comboBox1.Text);
                    }
               }
            
       
           
            if (checkBox1.Checked)
            {
                coa = (2.5f) * wheels;
                listBox1.Items.Add("Cost for filling air :" + coa);
                total = total + coa;
            }

            if (checkBox3.Checked)
            {
                int ml = (int)numericUpDown2.Value;
                op = 3 * ml;
                listBox1.Items.Add("Cost of filling oil :" + op);
                total = total + op;
            }
            listBox1.Items.Add("Total amount to be paid :" + total);

            SqlConnection sqlconn = new SqlConnection();
            sqlconn.ConnectionString = "SERVER=.\\SQLEXPRESS; Database=master; Integrated Security=true";
            try
            {
                sqlconn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Failed");
            }
            if (sqlconn.State == ConnectionState.Open)
            {

                SqlCommand sqlcomm = new SqlCommand();
                sqlcomm.Connection = sqlconn;
                sqlcomm.CommandText = "Insert into fuelbunk4 values('" + textBox1.Text + "','" + TempWheels + "','" + comboBox1.Text + "'," + litres + "," + coa + "," + cof + "," + op + "," + total + ",'"+DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss")+"')";
               
                sqlcomm.ExecuteNonQuery();
           
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            comboBox1.SelectedIndex= -1;  
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            listBox1.Items.Clear();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
          

           
        }
    }
} 