﻿using System;
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
    public partial class UC_CustomerCheckout : UserControl
    {
        function fn = new function();
        string query;
        public UC_CustomerCheckout()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UC_CustomerCheckout_Load(object sender, EventArgs e)
        {
            query= "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof ,customer.checkin,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid=rooms.roomid where chekout='NO'";
            DataSet ds=fn.getData(query);
            guna2DataGridView1.DataSource= ds.Tables[0];

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query= "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof ,customer.checkin,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid=rooms.roomid where cname like '"+txtName.Text+ "%' and chekout='NO'" ;
            DataSet ds= fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        int id;

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoom.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if(txtCName.Text!="")
            {
                 if(MessageBox.Show("Are you sure??","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
                 {
                      string cdate= txtCheckOutDate.Text;
                    query = "update customer set chekout='YES',checkout='" + cdate + "' where cid=" + id + " update rooms set booked='NO' where roomNo='" + txtRoom.Text + "' ";
                    fn.setData(query, "CheckOut Successful.");
                    UC_CustomerCheckout_Load(this, null);
                    clearAll();

                 }
            }
            else
            {
                MessageBox.Show("No Customer Selected.","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void clearAll()
        {
            txtCName.Clear();
            txtRoom.Clear();
            txtName.Clear();
            txtCheckOutDate.ResetText();
        }

        private void UC_CustomerCheckout_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
