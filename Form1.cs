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
using System.Configuration;
using System.Xml;

namespace AnonumousProject
{
    public partial class Form1 : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        string p1, p2, p3 = "",whoislog="";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string dd;
            dd = Application.StartupPath;

            comboBox1.Items.Insert(0, "--Select--");
            comboBox1.Items.Insert(1, "User");
            comboBox1.Items.Insert(2, "Admin");
            comboBox1.Items.Insert(3, "Manager");
            comboBox1.SelectedIndex = 0;

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("Select whoislogin from Registration", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("Update Registration set whoislogin='" + whoislog + "'", con);
                cmd.ExecuteNonQuery();
            }

            SqlDataAdapter adp1 = new SqlDataAdapter("Select CView from ComposeRequest", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                SqlCommand cmd1 = new SqlCommand("Update ComposeRequest set CView='" + whoislog + "'", con);
                cmd1.ExecuteNonQuery();
            }

            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register frm2 = new register();
            frm2.Show();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    textBox1.Text = "";
        //    textBox2.Text = "";
        //    comboBox1.SelectedIndex = 0;
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter LoginID.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter Password.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        MessageBox.Show("Select LoginType.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        SqlConnection con1 = new SqlConnection(constring);
                        con1.Open();

                        SqlDataAdapter adp1 = new SqlDataAdapter("Select whoislogin from Registration", con1);
                        DataSet ds1 = new DataSet();
                        adp1.Fill(ds1);
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            SqlCommand cmd1 = new SqlCommand("Update Registration set whoislogin='" + whoislog + "'", con1);
                            cmd1.ExecuteNonQuery();
                        }

                        SqlDataAdapter adp = new SqlDataAdapter("Select LoginID,LPassword,LoginType from Registration where LoginID='" + textBox1.Text + "'and LPassword='" + textBox2.Text + "'and LoginType='" + comboBox1.SelectedItem.ToString() + "'", con1);
                        DataSet ds = new DataSet();
                        adp.Fill(ds);

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            p1 = ds.Tables[0].Rows[i]["LoginID"].ToString();
                            p2 = ds.Tables[0].Rows[i]["LPassword"].ToString();
                            p3 = ds.Tables[0].Rows[i]["LoginType"].ToString();

                            if (p1 == textBox1.Text && p2 == textBox2.Text && p3 == "User")
                            {
                                SqlCommand cmd = new SqlCommand("Update Registration set whoislogin='" + p1 + "'where LoginID='" + p1 + "'", con1);
                                cmd.ExecuteNonQuery();
                                textBox1.Text = "";
                                textBox2.Text = "";
                                comboBox1.SelectedIndex = 0;
                                User usr = new User();
                                usr.ShowDialog();
                                goto Outer;
                            }
                            else
                            {
                                if (p1 == textBox1.Text && p2 == textBox2.Text &&  p3 == "Manager")
                                    {
                                        SqlCommand cmd = new SqlCommand("Update Registration set whoislogin='" + p1 + "'where LoginID='" + p1 + "'", con1);
                                        cmd.ExecuteNonQuery();
                                        textBox1.Text = "";
                                        textBox2.Text = "";
                                        comboBox1.SelectedIndex = 0;
                                        Manager mgr = new Manager();
                                        mgr.ShowDialog(); ;
                                        goto Outer;
                                    }

                                else
                                {
                                    //if (p1 == textBox1.Text && p2 == textBox2.Text && p3 == "Admin")
                                    if (p3 == "Admin")
                                    {
                                        SqlCommand cmd = new SqlCommand("Update Registration set whoislogin='" + p1 + "'where LoginID='" + p1 + "'", con1);
                                        cmd.ExecuteNonQuery();
                                        textBox1.Text = "";
                                        textBox2.Text = "";
                                        comboBox1.SelectedIndex = 0;
                                        Admin adm = new Admin();
                                        adm.ShowDialog();
                                        goto Outer;
                                    }
                                    else
                                    {
                                        //MessageBox.Show("Enter Correct LoginID/Password.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            p1 = "";
                            p2 = "";
                            p3 = "";
                        }
                        MessageBox.Show("Enter Correct LoginID/Password.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Outer:
                        p1 = "";
                        p2 = "";
                        p3 = "";
                    }
                }
            }
            
        }


    }
}
