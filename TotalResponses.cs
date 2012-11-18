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
    public partial class TotalResponses : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        string wholog = "", p1 = "View", adminviewempty = "";
        public TotalResponses()
        {
            InitializeComponent();
        }

        private void TotalResponses_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from Registration where whoislogin!='" + wholog + "'", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            wholog = ds1.Tables[0].Rows[0]["whoislogin"].ToString();

            SqlDataAdapter da = new SqlDataAdapter("Select ResID,RCity,RReqby,RName,RExpLocation,RCurLocation,RStatus from ResManagerToAdmin where RResUser='" + wholog + "'", con);
            DataSet ds = new DataSet();
            BindingSource bsourse = new BindingSource();
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            da.Fill(ds, "ResManagerToAdmin");
            //ds.Tables[0].Constraints.Add("CReqTo", ds.Tables[0].Columns[0], true);
            bsourse.DataSource = ds.Tables["ResManagerToAdmin"];
            dataGridView1.DataSource = bsourse;
            dataGridView1.Visible = true;
            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int curRow = int.Parse(e.RowIndex.ToString());
            string currentrow, currentrow1;
            currentrow = dataGridView1.Rows[curRow].Cells[1].Value.ToString();
            currentrow1 = dataGridView1.Rows[curRow].Cells[7].Value.ToString();

            SqlConnection con = new SqlConnection(constring);
            con.Open();

            SqlCommand cmd = new SqlCommand("Update ResManagerToAdmin set RView='" + p1 + "' where ResID='" + currentrow + "'", con);
            cmd.ExecuteNonQuery();

            if (currentrow1 == "Record Not Found")
            {
                RecordNotFound rnf = new RecordNotFound();
                rnf.ShowDialog();
            }
            else
            {
                ViewAdminResponses var = new ViewAdminResponses();
                var.ShowDialog();
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
    }
}
