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
    public partial class RecordNotFound : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        string adminviewempty = "", Rname, Reqby, Pname, Ppost, p1;
        public RecordNotFound()
        {
            InitializeComponent();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            SqlDataAdapter adp = new SqlDataAdapter("Select * from ResManagerToAdmin where RView!='" + adminviewempty + "'", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Rname = ds.Tables[0].Rows[0]["RName"].ToString();
            Reqby = ds.Tables[0].Rows[0]["RReqby"].ToString();

            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from postdetails", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            
            for(int i=0; i<ds1.Tables[0].Rows.Count ; i++)
            {
                Pname = ds1.Tables[0].Rows[i]["PName"].ToString();
                if (Pname == Rname)
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select * from postdetails where PName='" + Pname + "'", con);
                    DataSet ds2 = new DataSet();
                    BindingSource bsourse = new BindingSource();
                    SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                    da.Fill(ds2, "SPpostdetails");
                    //ds.Tables[0].Constraints.Add("CReqTo", ds.Tables[0].Columns[0], true);
                    bsourse.DataSource = ds2.Tables["SPpostdetails"];
                    dataGridView1.DataSource = bsourse;
                    dataGridView1.Visible = true;

                    p1 = "yes";
                }
            }

            if (p1 != "yes")
            {
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                    Ppost = ds1.Tables[0].Rows[j]["PPost"].ToString();
                    if (Reqby == Ppost)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("Select * from postdetails where PPost='" + Reqby + "'", con);
                        DataSet ds3 = new DataSet();
                        BindingSource bsourse = new BindingSource();
                        SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                        da.Fill(ds3, "SPpostdetails");
                        //ds.Tables[0].Constraints.Add("CReqTo", ds.Tables[0].Columns[0], true);
                        bsourse.DataSource = ds3.Tables["SPpostdetails"];
                        dataGridView1.DataSource = bsourse;
                        dataGridView1.Visible = true;
                    }
                }
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
