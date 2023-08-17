using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotelmanagementsystem.All_User_Control
{
    public partial class UC_CustomerRegistration : UserControl
    {
        function fn = new function();
        public UC_CustomerRegistration()
        {
            InitializeComponent();
        }

        public void setComboBox(string query,ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while(sdr.Read())
            {
                for(int i=0;i<sdr.FieldCount;i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtRoomtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomno.Items.Clear();
            txtPrice.Clear();

            string query= "select roomNo from rooms where bed='"+txtBed.Text+"' and roomType='"+txtRoomtype.Text+"' and booked='NO' ";
            setComboBox(query, txtRoomno);

        }

        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomtype.SelectedIndex = -1;
            txtRoomno.Items.Clear ();
            txtPrice.Clear ();
        }

        int rid;
        private void txtRoomno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select price,roomid from rooms where roomNo='" + txtRoomno.Text + "'";
            DataSet ds=fn.getData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        private void btnAllocateroom_Click(object sender, EventArgs e)
        {
            if(txtName.Text!="" && txtContact.Text!="" && txtNationality.Text!="" && txtGender.Text!="" && txtDob.Text!="" && txtIdProof.Text!="" && txtAddress.Text!="" && txtCheckin.Text!="" && txtPrice.Text!="")
            {
                string name=txtName.Text;
                Int64 mobile= Int64.Parse(txtContact.Text);
                String national=txtNationality.Text;
                string gender =txtGender.Text;
                String dob = txtDob.Text;  
                string idproof=txtIdProof.Text;
                string address = txtAddress.Text;   
                string checkin=txtCheckin.Text;


                string query = "insert into customer (cname,mobile,nationality,gender,dob,idproof,checkin,roomid) values ('" +name+ "'," +mobile+ " ,'" +national+ "','" +gender+ "','" +dob+ "','" +idproof+ "','" + checkin+ "'," +rid+ ") update rooms set booked ='YES' where Roomno='" +txtRoomno.Text+ "'";
                fn.setData(query,"Room No"+txtRoomno.Text + " Allocation successful.");
                clearAll();
            }
            else
            {
                MessageBox.Show("Fill All Fields", "Information !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void clearAll()
        {
            txtName.Clear();
            txtNationality.Clear();
            txtIdProof.Clear();
            txtGender.SelectedIndex=-1;
            txtDob.ResetText();
            txtCheckin.ResetText();
            txtAddress.Clear();
            txtContact.Clear();
            txtBed.SelectedIndex = -1;
            txtRoomno.Items.Clear();
            txtRoomtype.SelectedIndex = -1;
            txtPrice.Clear();


        }

        private void UC_CustomerRegistration_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_CustomerRegistration_Load(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdProof_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
