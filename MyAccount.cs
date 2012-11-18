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
    public partial class MyAccount : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        string p1 = "View", whoislog = "";
        public MyAccount()
        {
            InitializeComponent();
        }

        private void MyAccount_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Registration where whoislogin!='" + whoislog + "'", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            label2.Text = ds.Tables[0].Rows[0]["ID"].ToString();
            label3.Text = ds.Tables[0].Rows[0]["LName"].ToString();
            label4.Text = ds.Tables[0].Rows[0]["LoginID"].ToString();
            label5.Text = ds.Tables[0].Rows[0]["Date"].ToString();
            label6.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            label7.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            label8.Text = ds.Tables[0].Rows[0]["LoginType"].ToString();

            label2.Text = ds.Tables[0].Rows[0]["ID"].ToString();
            textBox1.Text = ds.Tables[0].Rows[0]["LName"].ToString();
            label12.Text = ds.Tables[0].Rows[0]["LoginID"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["Date"].ToString();
            textBox4.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            textBox5.Text = ds.Tables[0].Rows[0]["Email"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand(("Update Registration set LName='" + textBox1.Text + "',Date='" + textBox3.Text + "',Mobile='" + textBox4.Text + "',Email='" + textBox5.Text + "'where whoislogin!='" + whoislog + "'"),con);
            cmd.ExecuteNonQuery();
            con.Close();

            DialogResult dlgResult = MessageBox.Show("Updated Successfully..", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (dlgResult == DialogResult.OK)
            {
                MyAccount_Load(null, EventArgs.Empty);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
