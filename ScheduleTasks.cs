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
    public partial class ScheduleTasks : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);

        public ScheduleTasks()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void ScheduleTasks_Load(object sender, EventArgs e)
        {
            label2.Text = "Requests for Hospitals";
            SqlConnection con1 = new SqlConnection(constring);

           
                con1.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select CID,CReqby,CName,CCity,CExpLocation,CcurLocation,CReqFrom from ComposeRequest where CReqby='Hospital'", con1);
                DataSet ds = new DataSet();
                BindingSource bsourse = new BindingSource();
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                da.Fill(ds, "ComposeRequest");
                //ds.Tables[0].Constraints.Add("PCity", ds.Tables[0].Columns[0], true);
                bsourse.DataSource = ds.Tables["ComposeRequest"];
                dataGridView1.DataSource = bsourse;
                con1.Close();
                dataGridView1.Visible = true;
           
        }
    }
}
