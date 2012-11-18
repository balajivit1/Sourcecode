using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace AnonumousProject
{
    public partial class ViewAdminResponses : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        string adminviewempty = "", p1 = "View", p2 = "";

        public ViewAdminResponses()
        {
            InitializeComponent();
        }

        private void ViewAdminResponses_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from ResManagerToAdmin where RView='" + p1 + "'", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);

            label10.Text = ds1.Tables[0].Rows[0]["ResID"].ToString();
            label2.Text = ds1.Tables[0].Rows[0]["RCity"].ToString();
            label3.Text = ds1.Tables[0].Rows[0]["RReqby"].ToString();
            label4.Text = ds1.Tables[0].Rows[0]["RName"].ToString();
            label5.Text = ds1.Tables[0].Rows[0]["RExpLocation"].ToString();

            if (ds1.Tables[0].Rows[0]["RDistance"].ToString() == p2)
            {
                label6.Text = "[Not Defined]";
            }
            else
            {
                label6.Text = ds1.Tables[0].Rows[0]["RDistance"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["RAddress"].ToString() == p2)
            {
                label7.Text = "[Not Defined]";
            }
            else
            {
                label7.Text = ds1.Tables[0].Rows[0]["RAddress"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["RPhone"].ToString() == p2)
            {
                label8.Text = "[Not Defined]";
            }
            else
            {
                label8.Text = ds1.Tables[0].Rows[0]["RPhone"].ToString();
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from ResManagerToAdmin", con);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
            {
                //adminview = ds.Tables[0].Rows[j]["RView"].ToString();
                SqlCommand cmd = new SqlCommand("Update ResManagerToAdmin set RView='" + adminviewempty + "'", con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from ResManagerToAdmin", con);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
            {
                //adminview = ds.Tables[0].Rows[j]["RView"].ToString();
                SqlCommand cmd = new SqlCommand("Update ResManagerToAdmin set RView='" + adminviewempty + "'", con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from ResManagerToAdmin", con);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
            {
                //adminview = ds.Tables[0].Rows[j]["RView"].ToString();
                SqlCommand cmd = new SqlCommand("Update ResManagerToAdmin set RView='" + adminviewempty + "'", con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            this.Close();
        }
    }
}
