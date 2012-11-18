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
    public partial class Manager : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        string whoislog = "", novalue = "", p1 = "View", adminviewempty = "";

        public Manager()
        {
            InitializeComponent();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select whoislogin from Registration where whoislogin!='" + whoislog + "'", con);
            label5.Text = Convert.ToString(cmd1.ExecuteScalar());

            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from ComposeRequest where CReqToManager='" + label5.Text + "'", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select CID,CReqby,CCity,CExpLocation,CcurLocation,CSentManToAdmin from ComposeRequest where CReqToManager='" + label5.Text + "'", con);
                DataSet ds = new DataSet();
                BindingSource bsourse = new BindingSource();
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                da.Fill(ds, "ComposeRequest");
                ds.Tables[0].Constraints.Add("CReqTo", ds.Tables[0].Columns[0], true);
                bsourse.DataSource = ds.Tables["ComposeRequest"];
                dataGridView1.DataSource = bsourse;
                dataGridView1.Visible = true;
                novalue = "no";

                dataGridView1.Visible = true;
                label3.Visible = true;
            }
            if (novalue != "no")
            {
                dataGridView1.Visible = false;
                label2.Visible = true;
                label3.Visible = false;
            }

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
            con1.Close();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void postDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PostDetails pd = new PostDetails();
            pd.ShowDialog();
        }

        private void placeDistanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Distance dst = new Distance();
            dst.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int curRow = int.Parse(e.RowIndex.ToString());
            string currentrow;
            currentrow = dataGridView1.Rows[curRow].Cells[1].Value.ToString();

            SqlConnection con = new SqlConnection(constring);
            con.Open();

            SqlCommand cmd = new SqlCommand("Update ComposeRequest set CView='" + p1 + "' where CID='" + currentrow + "'", con);
            cmd.ExecuteNonQuery();

            ViewAdminRequests var = new ViewAdminRequests();
            var.ShowDialog();
        }

        private void sentResponsesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerSentResponses msr = new ManagerSentResponses();
            msr.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager_Load(null, EventArgs.Empty);
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
            con1.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
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
            con1.Close();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyAccount ma = new MyAccount();
            ma.ShowDialog();
        }
    }
}
