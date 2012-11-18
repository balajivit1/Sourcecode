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
    public partial class ViewManagerResponces : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        string view = "View", p1 = "", p3 = "Sent", id = "", sentornot;
        public ViewManagerResponces()
        {
            InitializeComponent();
        }

        private void ViewManagerResponces_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);

            SqlDataAdapter da = new SqlDataAdapter("Select ResID,RCity,RReqby,RName,RExpLocation,RCurLocation,RStatus,RSentStatus from ResManagerToAdmin where RView='" + view + "'", con);
            DataSet ds = new DataSet();
            BindingSource bsourse = new BindingSource();
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            da.Fill(ds, "ResManagerToAdmin");
            //ds.Tables[0].Constraints.Add("CReqTo", ds.Tables[0].Columns[0], true);
            bsourse.DataSource = ds.Tables["ResManagerToAdmin"];
            dataGridView1.DataSource = bsourse;
            dataGridView1.Visible = true;

            linkLabel2.Visible = true;
            button3.Visible = true;
            button1.Visible = true;
            pictureBox2.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);

            int curRow = int.Parse(e.RowIndex.ToString());
            string currentrow;
            currentrow = dataGridView1.Rows[curRow].Cells[1].Value.ToString();

            dataGridView1.Visible = false;
            button1.Visible = false;
            panel1.Visible = true;
            linkLabel2.Visible = false;
            button3.Visible = false;
            pictureBox2.Visible = false;

            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from ResManagerToAdmin where ResID='" + currentrow + "'", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);

            id = ds1.Tables[0].Rows[0]["ResID"].ToString();
            label2.Text = ds1.Tables[0].Rows[0]["RCity"].ToString();
            label3.Text = ds1.Tables[0].Rows[0]["RReqby"].ToString();
            label4.Text = ds1.Tables[0].Rows[0]["RName"].ToString();
            label5.Text = ds1.Tables[0].Rows[0]["RExpLocation"].ToString();

            if (ds1.Tables[0].Rows[0]["RDistance"].ToString() == p1)
            {
                label6.Text = "[Not Defined]";
            }
            else
            {
                label6.Text = ds1.Tables[0].Rows[0]["RDistance"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["RAddress"].ToString() == p1)
            {
                label7.Text = "[Not Defined]";
            }
            else
            {
                label7.Text = ds1.Tables[0].Rows[0]["RAddress"].ToString();
            }

            if (ds1.Tables[0].Rows[0]["RPhone"].ToString() == p1)
            {
                label8.Text = "[Not Defined]";
            }
            else
            {
                label8.Text = ds1.Tables[0].Rows[0]["RPhone"].ToString();
            }

            label12.Text = ds1.Tables[0].Rows[0]["RStatus"].ToString();
            label22.Text = ds1.Tables[0].Rows[0]["RResUser"].ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);

            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from ResManagerToAdmin where ResID='" + id + "'", con);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);

            sentornot = ds2.Tables[0].Rows[0]["RSentStatus"].ToString();

            if (sentornot != "Sent")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update ResManagerToAdmin set RSentStatus='" + p3 + "' where ResID='" + id + "'", con);
                cmd.ExecuteNonQuery();

                DialogResult dlgResult = MessageBox.Show("Responce is Sent To User.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dlgResult == DialogResult.OK)
                {
                    //panel1.Visible = false;
                    //dataGridView1.Visible = true;
                    //linkLabel2.Visible = true;
                    //button1.Visible = true;
                }
                con.Close();
            }
            else
            {
                DialogResult dlgResult1 = MessageBox.Show("This Responce is Already Sent To User.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dlgResult1 == DialogResult.OK)
                {
                    //panel1.Visible = false;
                    //dataGridView1.Visible = true;
                    //linkLabel2.Visible = true;
                    //button1.Visible = true;
                    //pictureBox2.Visible = true;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = true;
            linkLabel2.Visible = true;
            button1.Visible = true;
            button3.Visible = true;
            pictureBox2.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewManagerResponces_Load(null, EventArgs.Empty);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
