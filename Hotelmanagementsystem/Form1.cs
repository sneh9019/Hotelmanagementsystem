﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotelmanagementsystem
{
    public partial class Form1 : Form
    {
        function fn = new function();
        string query;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void labelError_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            query = "select username,pass from employee where username='" + txtUsername.Text + "'  and pass='"+txtPassword.Text+"'  ";
            DataSet ds = fn.getData(query);
       
            
           if (ds.Tables[0].Rows.Count !=0) 
            {
                labelError.Visible = false;
               Dashboard dash=new Dashboard();
                this.Hide();
                dash.Show();
            }
            else
            {
                labelError.Visible = true;
                txtPassword.Clear();
            }
        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
             
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
