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
    public partial class ViewUserRequests : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        string p1 = "View", p2 = "Manager", p3 = "", p4 = "Success";
        public ViewUserRequests()
        {
            InitializeComponent();
        }

        private void ViewUserRequests_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("Select * from ComposeRequest where CView='" + p1 + "'", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                label14.Text = ds.Tables[0].Rows[0]["CID"].ToString();
                label4.Text = ds.Tables[0].Rows[0]["CReqby"].ToString();
                label5.Text = ds.Tables[0].Rows[0]["CName"].ToString();
                label10.Text = ds.Tables[0].Rows[0]["CCity"].ToString();
                label11.Text = ds.Tables[0].Rows[0]["CExpLocation"].ToString();
                label12.Text = ds.Tables[0].Rows[0]["CcurLocation"].ToString();
            }

            //SqlDataAdapter adp1 = new SqlDataAdapter("Select * from Registration where LoginType='" + p2 + "'", con);
            //DataSet ds1 = new DataSet();
            //adp1.Fill(ds1);
            SqlDataAdapter adp1 = new SqlDataAdapter("Select manage from schedules where task='" + label4.Text + "'", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            comboBox1.Items.Insert(0, "--Select--");
            comboBox1.SelectedIndex = 0;
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds1.Tables[0].Rows[i]["manage"].ToString());
            }

            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from ComposeRequest where CID='" + label14.Text + "'", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            string status=ds1.Tables[0].Rows[0]["CStatus"].ToString();

            if (status == "Success")
            {
                DialogResult dlg1 = MessageBox.Show("Request Already Sent To Manager.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dlg1 == DialogResult.OK)
                {
                    ViewUserRequests vur = new ViewUserRequests();
                    vur.Close();
                }
            }
            else
            {
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                    SqlCommand cmd1 = new SqlCommand("Update ComposeRequest set CReqToManager='" + comboBox1.SelectedItem.ToString() + "' where CID='" + label14.Text + "'", con);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("Update ComposeRequest set CStatus='" + p4 + "' where CID='" + label14.Text + "'", con);
                    cmd2.ExecuteNonQuery();
                }

                DialogResult dlg = MessageBox.Show("Request Sent To Manager.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (dlg == DialogResult.OK)
                {
                    ViewUserRequests vur = new ViewUserRequests();
                    vur.Close();

                }
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "--Select--")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from ComposeRequest", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                SqlCommand cmd1 = new SqlCommand("Update ComposeRequest set CView='" + p3 + "'", con);
                cmd1.ExecuteNonQuery();
            }
            con.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from ComposeRequest", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                SqlCommand cmd1 = new SqlCommand("Update ComposeRequest set CView='" + p3 + "'", con);
                cmd1.ExecuteNonQuery();
            }
            con.Close();
            this.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
