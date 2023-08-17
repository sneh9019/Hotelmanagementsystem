using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotelmanagementsystem.All_User_Control
{
    public partial class UC_Employee : UserControl
    {
        function fn = new function();
        string query;
        public UC_Employee()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
             getMaxId();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtName.Text!="" && txtMobile.Text!="" && txtGender.Text!="" && txtEmail.Text!="" && txtUsername.Text!="" && txtPassword.Text!="")
            {
                string name=txtName.Text;
                Int64 mobile=Int64.Parse(txtMobile.Text);
                string gender=txtGender.Text;
                string email=txtEmail.Text;
                string username=txtUsername.Text;
                string pass=txtPassword.Text;

                query = "insert into employee (ename,mobile,gender,emailid,username,pass) values('" + name + "'," + mobile + ",'" + gender + "','" + email + "','" + username + "','" + pass + "')";
                fn.setData(query, "Employee Registered");

                clearAll();
                getMaxId();
            }
            else
            {
                MessageBox.Show("Fill All Fields.","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
         

        private void tabEmployeeDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabEmployeeDetails.SelectedIndex == 1)
            {
                query = "select * from employee";
                DataSet ds =fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
            }
            else if(tabEmployeeDetails.SelectedIndex == 2) 
            {
                query = "select * from employee";
                DataSet ds = fn.getData(query);
                guna2DataGridView2.DataSource = ds.Tables[0];
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (MessageBox.Show("Are you sure??", "Confirmation...!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from employee where eid=" + txtID.Text + "";
                    fn.setData(query, "Deleted Successfully");
                    tabEmployeeDetails_SelectedIndexChanged(this, null);
                }
            }
        }

        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }



        //---------------------------------METHODS-------------------------------------------------------------------
        public void getMaxId()
        {
            query = "select max(eid) from employee";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSet.Text = (num + 1).ToString();
            }
        }
        public void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
        }

         
    }
}
