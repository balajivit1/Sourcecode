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
    public partial class register : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        Class1 cs = new Class1();
        string p1,p2;

        public register()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label3.Text = Convert.ToString(cs.idgeneration());

            comboBox1.Items.Insert(0, "--Select--");
            comboBox1.Items.Insert(1, "User");
            comboBox1.Items.Insert(2, "Admin");
            comboBox1.Items.Insert(3, "Manager");
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = Convert.ToString(cs.idgeneration());
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Your Name.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter LoginID.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (textBox3.Text == "")
                    {
                        MessageBox.Show("Enter Password.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (textBox4.Text == "")
                        {
                            MessageBox.Show("Enter Date.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (textBox5.Text == "")
                            {
                                MessageBox.Show("Enter Mobile.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if (textBox6.Text == "")
                                {
                                    MessageBox.Show("Enter EmailID.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    if (comboBox1.SelectedIndex == 0)
                                    {
                                        MessageBox.Show("Select LoginType.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        SqlConnection con = new SqlConnection(constring);

                                        SqlDataAdapter adp = new SqlDataAdapter("Select LoginID from Registration", con);
                                        DataSet ds = new DataSet();
                                        adp.Fill(ds);
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {
                                            p1 = ds.Tables[0].Rows[i]["LoginID"].ToString();
                                            if (p1 == textBox2.Text)
                                            {
                                                p2 = "yes";
                                                MessageBox.Show("LoginID aready Exists.Please enter another LoginID.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                goto Outer;
                                            }
                                            p1 = "";
                                        }
                                                if (p2 != "yes")
                                                {
                                                    SqlCommand cmd = new SqlCommand();
                                                    con.Open();
                                                    cmd.Connection = con;
                                                    cmd.CommandType = CommandType.StoredProcedure;
                                                    cmd.CommandText = "SPRegistration";

                                                    cmd.Parameters.Add("@ID", SqlDbType.Int, 0);
                                                    cmd.Parameters["@ID"].Value = label3.Text;

                                                    cmd.Parameters.Add("@LName", SqlDbType.VarChar, 50);
                                                    cmd.Parameters["@LName"].Value = textBox1.Text;

                                                    cmd.Parameters.Add("@LoginID", SqlDbType.NVarChar, 50);
                                                    cmd.Parameters["@LoginID"].Value = textBox2.Text;

                                                    cmd.Parameters.Add("@LPassword", SqlDbType.NVarChar, 50);
                                                    cmd.Parameters["@LPassword"].Value = textBox3.Text;

                                                    cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 20);
                                                    cmd.Parameters["@Date"].Value = textBox4.Text;

                                                    cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar, 15);
                                                    cmd.Parameters["@Mobile"].Value = textBox5.Text;

                                                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50);
                                                    cmd.Parameters["@Email"].Value = textBox6.Text;

                                                    cmd.Parameters.Add("@LoginType", SqlDbType.VarChar, 10);
                                                    cmd.Parameters["@LoginType"].Value = comboBox1.SelectedItem.ToString();

                                                    cmd.ExecuteNonQuery();

                                                    DialogResult dlgResult = MessageBox.Show("Registration Successfully..", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    if (dlgResult == DialogResult.OK)
                                                    {
                                                        label3.Text = Convert.ToString(cs.idgeneration());
                                                        textBox1.Text = "";
                                                        textBox2.Text = "";
                                                        textBox3.Text = "";
                                                        textBox4.Text = "";
                                                        textBox5.Text = "";
                                                        textBox6.Text = "";
                                                        comboBox1.SelectedIndex = 0;
                                                    }
                                                }
                                            }
                                        }
                                    Outer:
                                        p2 = "";
                                    }
                                }
                            }
                        }
                    }
                }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
            }
        }

