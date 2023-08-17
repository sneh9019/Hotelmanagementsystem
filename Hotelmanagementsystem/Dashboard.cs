using System;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            Movingpanel.Left = btnAddRoom.Left+20;
            uC_AddRoom1.Visible = true;
            uC_AddRoom1.BringToFront();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_Employee1.Visible = false;

            uC_AddRoom1.Visible=false;
            uC_CustomerRegistration1.Visible=false;
            btnAddRoom.PerformClick();
        }

        private void btnCustomerReg_Click(object sender, EventArgs e)
        {
            Movingpanel.Left = btnCustomerReg.Left+20;
            uC_CustomerRegistration1.Visible = true;
            uC_CustomerRegistration1.BringToFront();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            uC_CustomerCheckout1.Visible=true;
            uC_CustomerCheckout1.BringToFront();
            Movingpanel.Left = btnCheckout.Left+20;

        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            customerDetails1.Visible = true;
            customerDetails1.BringToFront();
            Movingpanel.Left = btnCustomerDetails.Left+20;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
           uC_Employee1.Visible = true;
           uC_Employee1.BringToFront();
            Movingpanel.Left = btnEmployee.Left+20;
        }

        private void uC_Employee1_Load(object sender, EventArgs e)
        {

        }
    }
}
