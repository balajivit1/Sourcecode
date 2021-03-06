﻿using System;
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
    public partial class UserSentRequests : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        string wholog = "";

        public UserSentRequests()
        {
            InitializeComponent();
        }

        private void UserSentRequests_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from Registration where whoislogin!='" + wholog + "'", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            wholog = ds1.Tables[0].Rows[0]["whoislogin"].ToString();

            SqlDataAdapter da = new SqlDataAdapter("Select CID,CReqby,CName,CCity,CExpLocation,CcurLocation,CReqTo from ComposeRequest where CReqFrom='" + wholog + "'", con);
            DataSet ds = new DataSet();
            BindingSource bsourse = new BindingSource();
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            da.Fill(ds, "ComposeRequest");
            //ds.Tables[0].Constraints.Add("CReqTo", ds.Tables[0].Columns[0], true);
            bsourse.DataSource = ds.Tables["ComposeRequest"];
            dataGridView1.DataSource = bsourse;
            dataGridView1.Visible = true;
            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
