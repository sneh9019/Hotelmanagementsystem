using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotelmanagementsystem
{
    internal class function
    {
        protected SqlConnection getConnection() 
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = " data source = LAPTOP-4MIGV8BT\\SQLEXPRESS1;database=myHotel;integrated security=True";
            return conn;
        }
        public DataSet getData(string query)       //get data from dataset
        {
            SqlConnection conn=getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
        public void setData(string query,String message) 
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("'" + message + "'", "success",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
        public SqlDataReader getForCombo(string query)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd =new SqlCommand(query,conn);
            SqlDataReader sdr=cmd.ExecuteReader();
            return sdr;
        }
    }
}
