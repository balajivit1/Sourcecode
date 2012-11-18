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
    public partial class Admin : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        Class1 cs = new Class1();
        int id;
        string whoislog = "", LoginType = "Manager", p1 = "View", novalue = "", status = "Success", adminview = "View", adminviewempty = "";
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'anonoyDataSet1.ComposeRequest' table. You can move, or remove it, as needed.
            //this.composeRequestTableAdapter1.Fill(this.anonoyDataSet1.ComposeRequest);

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select whoislogin from Registration where whoislogin!='" + whoislog + "'", con);
            label5.Text = Convert.ToString(cmd1.ExecuteScalar());

            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from ComposeRequest where CReqTo='" + label5.Text + "'", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select CID,CReqby,CName,CCity,CReqFrom,CReqToManager,CStatus from ComposeRequest where CReqTo='" + label5.Text + "'", con);
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

            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from ResManagerToAdmin where RResAdmin='" + label5.Text + "'", con);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);

            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
            {
                //adminview = ds.Tables[0].Rows[j]["RView"].ToString();
                SqlCommand cmd = new SqlCommand("Update ResManagerToAdmin set RView='" + adminview + "'where RResAdmin='" + label5.Text + "'", con);
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

            SqlDataAdapter adp1 = new SqlDataAdapter("Select CView from ComposeRequest", con1);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                SqlCommand cmd1 = new SqlCommand("Update ComposeRequest set CView='" + whoislog + "'", con1);
                cmd1.ExecuteNonQuery();
            }

            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from ResManagerToAdmin where RResAdmin='" + label5.Text + "'", con1);
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

            SqlDataAdapter adp1 = new SqlDataAdapter("Select CView from ComposeRequest", con1);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                SqlCommand cmd1 = new SqlCommand("Update ComposeRequest set CView='" + whoislog + "'", con1);
                cmd1.ExecuteNonQuery();
            }

            con1.Close();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Request Sent to Manager Successfully..", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            int curRow = int.Parse(e.RowIndex.ToString());
            string currentrow;
            currentrow = dataGridView1.Rows[curRow].Cells[1].Value.ToString();

            SqlConnection con = new SqlConnection(constring);
            con.Open();

            SqlCommand cmd = new SqlCommand("Update ComposeRequest set CView='" + p1 + "' where CID='" + currentrow + "'", con);
            cmd.ExecuteNonQuery();

            ViewUserRequests vur = new ViewUserRequests();
            vur.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Load(null, EventArgs.Empty);
        }

        private void receivedRequestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewManagerResponces vmr = new ViewManagerResponces();
            vmr.ShowDialog();
        }

        private void sentResponsesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminSentRequests asr = new AdminSentRequests();
            asr.ShowDialog();
        }

        private void sentResponsesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdminSentResponsess asr = new AdminSentResponsess();
            asr.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyAccount my = new MyAccount();
            my.ShowDialog();
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

            SqlDataAdapter adp1 = new SqlDataAdapter("Select CView from ComposeRequest", con1);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                SqlCommand cmd1 = new SqlCommand("Update ComposeRequest set CView='" + whoislog + "'", con1);
                cmd1.ExecuteNonQuery();
            }

            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from ResManagerToAdmin where RResAdmin='" + label5.Text + "'", con1);
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

            SqlDataAdapter adp1 = new SqlDataAdapter("Select CView from ComposeRequest", con1);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                SqlCommand cmd1 = new SqlCommand("Update ComposeRequest set CView='" + whoislog + "'", con1);
                cmd1.ExecuteNonQuery();
            }

            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from ResManagerToAdmin where RResAdmin='" + label5.Text + "'", con1);
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

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ScheduleTasks st = new ScheduleTasks();
            //st.ShowDialog();
            Taskschedule ts = new Taskschedule();
            ts.ShowDialog();
        }
    }
}
