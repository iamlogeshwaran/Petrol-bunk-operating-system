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
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            string username = textBox1.Text;
            string passcode = textBox2.Text;
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
                comm.CommandText = "select passcode from serv where username='" + username + "'";
                string dbpasscode = (string)comm.ExecuteScalar();
                if (dbpasscode == passcode)
                {
                    comm.CommandText = "select usertype from serv where username='"+username+"' and passcode ='"+passcode+"'";
                    string usertype = (string)comm.ExecuteScalar();
                    if (usertype == "admin")
                    {
                        Admin frm = new Admin();
                        frm.ShowDialog();
                    }
                    else if (usertype == "user")
                    {
                        Form1 frm = new Form1();
                        frm.ShowDialog();
                    }
                    else if (usertype == "manager")
                    {
                        manager frm = new manager();
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password please enter valid username & password");
                    }
                }
            }
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Server_Load(object sender, EventArgs e)
        {
        
        }
    }
}
