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
    public partial class User : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        string whoislog = "", p1 = "", status, adminviewempty = "", p2 = "View";
        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select whoislogin from Registration where whoislogin!='" + whoislog + "'", con);
            label5.Text = Convert.ToString(cmd1.ExecuteScalar());
            
            SqlDataAdapter adp3 = new SqlDataAdapter("Select * from ResManagerToAdmin", con);
            DataSet ds3 = new DataSet();
            adp3.Fill(ds3);
            for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
            {
                //adminview = ds.Tables[0].Rows[j]["RView"].ToString();
                SqlCommand cmd = new SqlCommand("Update ResManagerToAdmin set RView='" + adminviewempty + "'", con);
                cmd.ExecuteNonQuery();
            }

            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from ResManagerToAdmin where RResUser='" + label5.Text + "' and RFinalView!='" + p2 + "'", con);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);

            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select ResID,RCity,RReqby,RName,RExpLocation,RCurLocation,RStatus from ResManagerToAdmin where RResUser='" + label5.Text + "' and RFinalView!='" + p2 + "'", con);
                DataSet ds = new DataSet();
                BindingSource bsourse = new BindingSource();
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                da.Fill(ds, "ResManagerToAdmin");
                //ds.Tables[0].Constraints.Add("CReqTo", ds.Tables[0].Columns[0], true);
                bsourse.DataSource = ds.Tables["ResManagerToAdmin"];
                dataGridView1.DataSource = bsourse;
                dataGridView1.Visible = true;

                p1 = "yes";
                label2.Visible=true;
                dataGridView1.Visible=true;
            }

            if(p1 !="yes")
            {
                label2.Visible = false;
                dataGridView1.Visible = false;
                label3.Visible = true;
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection con1 = new SqlConnection(constring);
            con1.Open();
            SqlDataAdapter adp = new SqlDataAdapter("Select whoislogin from Registration", con1);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("Update Registration set whoislogin='" + whoislog + "'", con1);
                cmd.ExecuteNonQuery();
            }

            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from ResManagerToAdmin",con1);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
            {
                //adminview = ds.Tables[0].Rows[j]["RView"].ToString();
                SqlCommand cmd = new SqlCommand("Update ResManagerToAdmin set RView='" + adminviewempty + "'", con1);
                cmd.ExecuteNonQuery();
            }

            con1.Close();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void composeRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            int curRow = int.Parse(e.RowIndex.ToString());
            string currentrow;
            currentrow = dataGridView1.Rows[curRow].Cells[1].Value.ToString();

            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from ResManagerToAdmin where ResID='" + currentrow + "'", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);

            SqlCommand cmd = new SqlCommand("Update ResManagerToAdmin set RView='" + p2 + "' where ResID='" + currentrow + "'", con);
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("Update ResManagerToAdmin set RFinalView='" + p2 + "' where ResID='" + currentrow + "'", con);
            cmd1.ExecuteNonQuery();

            status = ds1.Tables[0].Rows[0]["RStatus"].ToString();

            if (status == "Success")
            {
                ViewAdminResponses var = new ViewAdminResponses();
                var.ShowDialog();
            }
            else
            {
                RecordNotFound rnf = new RecordNotFound();
                rnf.ShowDialog();
            }
        }

        private void totalResponsesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sentRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SqlConnection con2 = new SqlConnection(constring);
            con2.Open();
            SqlDataAdapter adp = new SqlDataAdapter("Select whoislogin from Registration", con2);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("Update Registration set whoislogin='" + whoislog + "'", con2);
                cmd.ExecuteNonQuery();
            }
            con2.Close();
            this.Close();
        }

        private void composeRequestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ComposeRequest cr = new ComposeRequest();
            cr.ShowDialog();
        }

        private void sentRequestsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UserSentRequests usr = new UserSentRequests();
            usr.ShowDialog();
        }

        private void totalResponsesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TotalResponses tr = new TotalResponses();
            tr.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyAccount MA = new MyAccount();
            MA.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection con1 = new SqlConnection(constring);
            con1.Open();
            SqlDataAdapter adp = new SqlDataAdapter("Select whoislogin from Registration", con1);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("Update Registration set whoislogin='" + whoislog + "'", con1);
                cmd.ExecuteNonQuery();
            }

            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from ResManagerToAdmin", con1);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
            {
                //adminview = ds.Tables[0].Rows[j]["RView"].ToString();
                SqlCommand cmd = new SqlCommand("Update ResManagerToAdmin set RView='" + adminviewempty + "'", con1);
                cmd.ExecuteNonQuery();
            }

            con1.Close();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(constring);
            con1.Open();
            SqlDataAdapter adp = new SqlDataAdapter("Select whoislogin from Registration", con1);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("Update Registration set whoislogin='" + whoislog + "'", con1);
                cmd.ExecuteNonQuery();
            }

            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from ResManagerToAdmin", con1);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
            {
                //adminview = ds.Tables[0].Rows[j]["RView"].ToString();
                SqlCommand cmd = new SqlCommand("Update ResManagerToAdmin set RView='" + adminviewempty + "'", con1);
                cmd.ExecuteNonQuery();
            }

            con1.Close();
            this.Close();
        }

    }
}
