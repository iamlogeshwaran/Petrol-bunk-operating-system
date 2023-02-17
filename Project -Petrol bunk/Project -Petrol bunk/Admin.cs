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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
         
              SqlConnection con=new SqlConnection();
            con.ConnectionString = "SERVER=DESKTOP-3MUST40\\SQLEXPRESS; Database=master; Integrated Security=true";
            try
            {
                con.Open();
                MessageBox.Show("connected successfully");
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection failed");
            }
            if (con.State == ConnectionState.Open)
            {
                string fueltype = comboBox2.SelectedItem.ToString();
                if (fueltype == "petrol")
                {
                    int petrolprice = Convert.ToInt32(textBox6.Text);
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = con;
                    comm.CommandText = "update updateprice set petrol="+ petrolprice + "";
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Petrol updated sucessfully");
                }

                else if (fueltype == "diesel")
                {
                    int dieselprice = Convert.ToInt32(textBox6.Text);
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = con;
                    comm.CommandText = "update updateprice set petrol=" + dieselprice + "";
                    comm.ExecuteNonQuery();
                    MessageBox.Show("diesel updated sucessfully");
                }
                else if (fueltype == "oil")
                {
                    int oilprice = Convert.ToInt32(textBox6.Text);
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = con;
                    comm.CommandText = "update updateprice set petrol=" + oilprice + "";
                    comm.ExecuteNonQuery();
                    MessageBox.Show("oil updated sucessfully");
                }



            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox5.Text;
            SqlConnection con=new SqlConnection();
            con.ConnectionString = "SERVER=DESKTOP-3MUST40\\SQLEXPRESS; Database=master; Integrated Security=true";
            try
            {
                con.Open();
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection failed");
            }
            if (con.State == ConnectionState.Open)
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                //delete from serv where username='ramesh'
                comm.CommandText = "delete from serv where username='" + username + "'";
                comm.ExecuteNonQuery();
                MessageBox.Show("User deleted successfully");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username=textBox3.Text;
            string oldpassword=textBox7.Text;
            string newpassword=textBox4.Text;
            SqlConnection con=new SqlConnection();
            con.ConnectionString = "SERVER=DESKTOP-3MUST40\\SQLEXPRESS; Database=master; Integrated Security=true";
            try
            {
                con.Open();
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection failed");
            }
            if (con.State == ConnectionState.Open)
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                comm.CommandText="select passcode from serv where username='"+username+"'";
                string opass=(string)comm.ExecuteScalar();
                if (opass == oldpassword)
                {
                     SqlCommand command = new SqlCommand();
                command.Connection = con;
                    //update serv set passcode='sathish123' where username='sathish'
                command.CommandText = "update serv set passcode='" + newpassword + "'where username='" + username + "'";
                command.ExecuteNonQuery();
                MessageBox.Show("Password reseted sucessfully");
                }
            }
                
            }
        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string username = textBox1.Text;
            string passcode = textBox2.Text;
            string usertype = comboBox1.SelectedItem.ToString();
 SqlConnection con=new SqlConnection();
            con.ConnectionString = "SERVER=DESKTOP-3MUST40\\SQLEXPRESS; Database=master; Integrated Security=true";
            try
            {
                con.Open();
             
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection failed");
            }
           
            if (con.State == ConnectionState.Open)
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                comm.CommandText = "insert into serv values('" + username + "','" + passcode + "','" + usertype + "')";

                comm.ExecuteNonQuery();
                MessageBox.Show("Inserted Successfully");
               
            }
            else if (con.State == ConnectionState.Open)
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                comm.CommandText = "select passcode from serv where username='" + username + "'";
                string dbpasscode = (string)comm.ExecuteScalar();
                if (dbpasscode == username)
                {
                    MessageBox.Show("Username already exist");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
        }
    }
}
