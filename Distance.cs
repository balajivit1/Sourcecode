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
    public partial class Distance : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        Class1 cs = new Class1();
        string F1, T1, p1;
        int id;
        public Distance()
        {
            InitializeComponent();
        }

        private void Distance_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 50;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.textBox1, "First Letter Shoul be Capital.");
            toolTip1.SetToolTip(this.textBox2, "First Letter Shoul be Capital.");

            comboBox1.Items.Insert(0, "--Select--");
            comboBox1.Items.Insert(1, "Trichy");
            comboBox1.Items.Insert(2, "Chennai");
            comboBox1.Items.Insert(3, "Kanchipuram");
            comboBox1.Items.Insert(4, "Tirunelveli");
            comboBox1.Items.Insert(5, "Tanjore");
            comboBox1.SelectedIndex = 0;

            comboBox4.Items.Insert(0, "--Select--");
            comboBox4.Items.Insert(1, "Trichy");
            comboBox4.Items.Insert(2, "Chennai");
            comboBox4.Items.Insert(3, "Kanchipuram");
            comboBox4.Items.Insert(4, "Tirunelveli");
            comboBox4.Items.Insert(5, "Tanjore");
            comboBox4.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "--Select--")
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                
                comboBox2.Text = "--Select--";
                comboBox3.Text = "--Select--";

                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;

                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Enabled = false;
                textBox3.Text = "";
                button1.Enabled = false;

            }
            else
            {
                comboBox2.Visible = true;
                comboBox3.Visible = true;

                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                textBox3.Enabled = true;
                button1.Enabled = true;

                comboBox2.Items.Clear();
                comboBox3.Items.Clear();

                if (comboBox1.SelectedItem.ToString() == "Trichy")
                  {
                      comboBox2.Items.Insert(0, "--Select--");
                      comboBox2.Items.Insert(1, "Karur");
                      comboBox2.Items.Insert(2, "Koraikudi");
                      comboBox2.Items.Insert(3, "Pungalur");
                      comboBox2.Items.Insert(4, "Kumbakonam");
                      comboBox2.Items.Insert(5, "Thuvakudi ");
                      comboBox2.Items.Insert(6, "Others");
                      comboBox2.SelectedIndex = 0;

                      comboBox3.Items.Insert(0, "--Select--");
                      comboBox3.Items.Insert(1, "Karur");
                      comboBox3.Items.Insert(2, "Koraikudi");
                      comboBox3.Items.Insert(3, "Pungalur");
                      comboBox3.Items.Insert(4, "Kumbakonam");
                      comboBox3.Items.Insert(5, "Thuvakudi ");
                      comboBox3.Items.Insert(6, "Others");
                      comboBox3.SelectedIndex = 0;
                  }
                  else
                  {
                      if (comboBox1.SelectedItem.ToString() == "Chennai")
                      {
                          comboBox2.Items.Insert(0, "--Select--");
                          comboBox2.Items.Insert(1, "Kodambakam");
                          comboBox2.Items.Insert(2, "Saidapet");
                          comboBox2.Items.Insert(3, "Tnagar");
                          comboBox2.Items.Insert(4, "Guindy");
                          comboBox2.Items.Insert(5, "Koyambedu ");
                          comboBox2.Items.Insert(6, "Others");
                          comboBox2.SelectedIndex = 0;

                          comboBox3.Items.Insert(0, "--Select--");
                          comboBox3.Items.Insert(1, "Kodambakam");
                          comboBox3.Items.Insert(2, "Saidapet");
                          comboBox3.Items.Insert(3, "Tnagar");
                          comboBox3.Items.Insert(4, "Guindy");
                          comboBox3.Items.Insert(5, "Koyambedu ");
                          comboBox3.Items.Insert(6, "Others");
                          comboBox3.SelectedIndex = 0;
                      }
                      else
                      {
                          if (comboBox1.SelectedItem.ToString() == "Kanchipuram")
                          {
                              comboBox2.Items.Insert(0, "--Select--");
                              comboBox2.Items.Insert(1, "Cheyur");
                              comboBox2.Items.Insert(2, "Attur");
                              comboBox2.Items.Insert(3, "Menachi");
                              comboBox2.Items.Insert(4, "Melur");
                              comboBox2.Items.Insert(5, "Kachana");
                              comboBox2.Items.Insert(6, "Others");
                              comboBox2.SelectedIndex = 0;

                              comboBox3.Items.Insert(0, "--Select--");
                              comboBox3.Items.Insert(1, "Cheyur");
                              comboBox3.Items.Insert(2, "Attur");
                              comboBox3.Items.Insert(3, "Menachi");
                              comboBox3.Items.Insert(4, "Melur");
                              comboBox3.Items.Insert(5, "Kachana");
                              comboBox3.Items.Insert(6, "Others");
                              comboBox3.SelectedIndex = 0;
                          }
                          else
                          {
                              if (comboBox1.SelectedItem.ToString() == "Tirunelveli")
                              {
                                  comboBox2.Items.Insert(0, "--Select--");
                                  comboBox2.Items.Insert(1, "Nazareth");
                                  comboBox2.Items.Insert(2, "Tiruchendur");
                                  comboBox2.Items.Insert(3, "Sivakasi");
                                  comboBox2.Items.Insert(4, "Kovilpatti");
                                  comboBox2.Items.Insert(5, "Tuty");
                                  comboBox2.Items.Insert(6, "Others");
                                  comboBox2.SelectedIndex = 0;

                                  comboBox3.Items.Insert(0, "--Select--");
                                  comboBox3.Items.Insert(1, "Nazareth");
                                  comboBox3.Items.Insert(2, "Tiruchendur");
                                  comboBox3.Items.Insert(3, "Sivakasi");
                                  comboBox3.Items.Insert(4, "Kovilpatti");
                                  comboBox3.Items.Insert(5, "Tuty");
                                  comboBox3.Items.Insert(6, "Others");
                                  comboBox3.SelectedIndex = 0;
                              }
                              else
                              {
                                  if (comboBox1.SelectedItem.ToString() == "Tanjore")
                                  {
                                      comboBox2.Items.Insert(0, "--Select--");
                                      comboBox2.Items.Insert(1, "Keranoor");
                                      comboBox2.Items.Insert(2, "Brihadeeswara ");
                                      comboBox2.Items.Insert(3, "Manora");
                                      comboBox2.Items.Insert(4, "Napoleo");
                                      comboBox2.Items.Insert(5, "Satiy");
                                      comboBox2.Items.Insert(6, "Others");
                                      comboBox2.SelectedIndex = 0;

                                      comboBox3.Items.Insert(0, "--Select--");
                                      comboBox3.Items.Insert(1, "Keranoor");
                                      comboBox3.Items.Insert(2, "Brihadeeswara ");
                                      comboBox3.Items.Insert(3, "Manora");
                                      comboBox3.Items.Insert(4, "Napoleo");
                                      comboBox3.Items.Insert(5, "Satiy");
                                      comboBox3.Items.Insert(6, "Others");
                                      comboBox3.SelectedIndex = 0;
                                  }
                              }
                          }
                      }
                  }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Others")
            {
                textBox1.Visible = true;
                comboBox2.Text = "--Select--";
                comboBox2.Visible = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "Others")
            {
                textBox2.Visible = true;
                comboBox3.Text = "--Select--";
                comboBox3.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            textBox1.Visible = false;
            comboBox3.Visible = true;
            textBox2.Visible = false;
            textBox3.Text = "";

            comboBox1.Text = "--Select--";
            comboBox2.Text = "--Select--";
            comboBox3.Text = "--Select--";
            textBox3.Enabled = false;
            button1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
        }

    private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "--Select--")
            {
                MessageBox.Show("Selct City.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (comboBox2.SelectedItem.ToString() == "--Select--" & textBox1.Text == "")
                {
                        MessageBox.Show("Selct From.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (comboBox3.SelectedItem.ToString() == "--Select--" & textBox2.Text == "")
                    {
                            MessageBox.Show("Selct To.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (textBox3.Text == "")
                        {
                            MessageBox.Show("Enter Distance in /KM.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                        else
                        {
                            SqlConnection con = new SqlConnection(constring);
                            SqlDataAdapter adp = new SqlDataAdapter("Select DFrom,DTo from Distance", con);
                            DataSet ds = new DataSet();
                            adp.Fill(ds);

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                F1 = ds.Tables[0].Rows[i]["DFrom"].ToString();
                                T1 = ds.Tables[0].Rows[i]["DTo"].ToString();

                                if (textBox1.Visible == false & textBox2.Visible == false)
                                {
                                    if (F1 == comboBox2.SelectedItem.ToString() & T1 == comboBox3.SelectedItem.ToString())
                                    {
                                        p1 = "yes";
                                        DialogResult dlgResult1 = MessageBox.Show("Distance should be alredy exists.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        if (dlgResult1 == DialogResult.OK)
                                        {
                                            comboBox2.Text = "--Select--";
                                            comboBox3.Text = "--Select--";
                                            textBox1.Text = "";
                                            textBox2.Text = "";
                                            textBox3.Text = "";
                                        }
                                    }
                                }

                                if (textBox1.Visible == true & textBox2.Visible == false)
                                {
                                    if (F1 == textBox1.Text & T1 == comboBox3.SelectedItem.ToString())
                                    {
                                        p1 = "yes";
                                        DialogResult dlgResult1 = MessageBox.Show("Distance should be alredy exists.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        if (dlgResult1 == DialogResult.OK)
                                        {
                                            comboBox2.Text = "--Select--";
                                            comboBox3.Text = "--Select--";
                                            textBox1.Text = "";
                                            textBox2.Text = "";
                                            textBox3.Text = "";
                                        }
                                    }
                                }

                                if (textBox1.Visible == true & textBox2.Visible == true)
                                {
                                    if (F1 == textBox1.Text & T1 == textBox2.Text)
                                    {
                                        p1 = "yes";
                                        DialogResult dlgResult1 = MessageBox.Show("Distance should be alredy exists.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        if (dlgResult1 == DialogResult.OK)
                                        {
                                            comboBox2.Text = "--Select--";
                                            comboBox3.Text = "--Select--";
                                            textBox1.Text = "";
                                            textBox2.Text = "";
                                            textBox3.Text = "";
                                        }
                                    }
                                }

                                if (textBox1.Visible == false  & textBox2.Visible == true)
                                {
                                    if (F1 == comboBox2.SelectedItem.ToString() & T1 == textBox2.Text)
                                    {
                                        p1 = "yes";
                                        DialogResult dlgResult1 = MessageBox.Show("Distance should be alredy exists.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        if (dlgResult1 == DialogResult.OK)
                                        {
                                            comboBox2.Text = "--Select--";
                                            comboBox3.Text = "--Select--";
                                            textBox1.Text = "";
                                            textBox2.Text = "";
                                            textBox3.Text = "";
                                        }
                                    }
                                }
                            }


                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                F1 = ds.Tables[0].Rows[i]["DTo"].ToString();
                                T1 = ds.Tables[0].Rows[i]["DFrom"].ToString();

                                if (textBox1.Visible == false & textBox2.Visible == false)
                                {
                                    if (F1 == comboBox2.SelectedItem.ToString() & T1 == comboBox3.SelectedItem.ToString())
                                    {
                                        p1 = "yes";
                                        DialogResult dlgResult1 = MessageBox.Show("Distance should be alredy exists.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        if (dlgResult1 == DialogResult.OK)
                                        {
                                            comboBox2.Text = "--Select--";
                                            comboBox3.Text = "--Select--";
                                            textBox1.Text = "";
                                            textBox2.Text = "";
                                            textBox3.Text = "";
                                        }
                                    }
                                }

                                if (textBox1.Visible == true & textBox2.Visible == false)
                                {
                                    if (F1 == textBox1.Text & T1 == comboBox3.SelectedItem.ToString())
                                    {
                                        p1 = "yes";
                                        DialogResult dlgResult1 = MessageBox.Show("Distance should be alredy exists.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        if (dlgResult1 == DialogResult.OK)
                                        {
                                            comboBox2.Text = "--Select--";
                                            comboBox3.Text = "--Select--";
                                            textBox1.Text = "";
                                            textBox2.Text = "";
                                            textBox3.Text = "";
                                        }
                                    }
                                }

                                if (textBox1.Visible == true & textBox2.Visible == true)
                                {
                                    if (F1 == textBox1.Text & T1 == textBox2.Text)
                                    {
                                        p1 = "yes";
                                        DialogResult dlgResult1 = MessageBox.Show("Distance should be alredy exists.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        if (dlgResult1 == DialogResult.OK)
                                        {
                                            comboBox2.Text = "--Select--";
                                            comboBox3.Text = "--Select--";
                                            textBox1.Text = "";
                                            textBox2.Text = "";
                                            textBox3.Text = "";
                                        }
                                    }
                                }

                                if (textBox1.Visible == false & textBox2.Visible == true)
                                {
                                    if (F1 == comboBox2.SelectedItem.ToString() & T1 == textBox1.Text)
                                    {
                                        p1 = "yes";
                                        DialogResult dlgResult1 = MessageBox.Show("Distance should be alredy exists.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        if (dlgResult1 == DialogResult.OK)
                                        {
                                            comboBox2.Text = "--Select--";
                                            comboBox3.Text = "--Select--";
                                            textBox1.Text = "";
                                            textBox2.Text = "";
                                            textBox3.Text = "";
                                        }
                                    }
                                }

                            }

                            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            //{
                            //    F1 = ds.Tables[0].Rows[i]["DFrom"].ToString();
                            //    T1 = ds.Tables[0].Rows[i]["DTo"].ToString();
                            //    if ((T1 == comboBox2.SelectedItem.ToString() & F1 == comboBox3.SelectedItem.ToString()) || (T1 == textBox1.Text || F1 == textBox2.Text))
                            //    {
                            //        p1="yes";
                            //        DialogResult dlgResult2 = MessageBox.Show("Distance should be alredy exists.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //        if (dlgResult2 == DialogResult.OK)
                            //        {
                            //            comboBox2.Text = "--Select--";
                            //            comboBox3.Text = "--Select--";
                            //            textBox1.Text = "";
                            //            textBox2.Text = "";
                            //            textBox3.Text = "";
                            //        }
                            //    }
                            //}

                            if (p1 != "yes")
                            {
                                id = Convert.ToInt32(cs.idondistance());
                                SqlCommand cmd = new SqlCommand();
                                con.Open();
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "SPDistance";

                                cmd.Parameters.Add("@DID", SqlDbType.Int, 0);
                                cmd.Parameters["@DID"].Value = id;

                                cmd.Parameters.Add("@DCity", SqlDbType.VarChar, 50);
                                cmd.Parameters["@DCity"].Value = comboBox1.SelectedItem.ToString();

                                if (comboBox2.Visible == true || textBox1.Visible == false)
                                {
                                    cmd.Parameters.Add("@DFrom", SqlDbType.NVarChar, 50);
                                    cmd.Parameters["@DFrom"].Value = comboBox2.SelectedItem.ToString();
                                }
                                else
                                {
                                    cmd.Parameters.Add("@DFrom", SqlDbType.NVarChar, 50);
                                    cmd.Parameters["@DFrom"].Value = textBox1.Text;
                                }

                                if (comboBox3.Visible == true || textBox2.Visible == false)
                                {
                                    cmd.Parameters.Add("@DTo", SqlDbType.NVarChar, 20);
                                    cmd.Parameters["@DTo"].Value = comboBox3.SelectedItem.ToString();
                                }
                                else
                                {
                                    cmd.Parameters.Add("@DTo", SqlDbType.NVarChar, 15);
                                    cmd.Parameters["@DTo"].Value = textBox2.Text;
                                }

                                cmd.Parameters.Add("@DDistance", SqlDbType.NVarChar, 50);
                                cmd.Parameters["@DDistance"].Value = textBox3.Text;

                                cmd.ExecuteNonQuery();

                                DialogResult dlgResult = MessageBox.Show("Updated Successfully..", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (dlgResult == DialogResult.OK)
                                {
                                    button2_Click(null, EventArgs.Empty);
                                }
                                F1 = "";
                                T1 = "";
                                p1 = "";
                            }
                            p1 = "";
                        }


                    }
                }
            }
        }

    private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox4.SelectedItem.ToString() == "--Select--")
        {
            dataGridView1.Visible = false;
        }
        else
        {
            dataGridView1.Visible = true;

            SqlConnection con1 = new SqlConnection(constring);
            con1.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Distance where DCity='"+comboBox4.SelectedItem.ToString()+"'", con1);
            DataSet ds = new DataSet();
            BindingSource bsourse = new BindingSource();
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            da.Fill(ds, "Distance");
            ds.Tables[0].Constraints.Add("DCity", ds.Tables[0].Columns[0], true);
            bsourse.DataSource = ds.Tables["Distance"];
            dataGridView1.DataSource = bsourse;
            con1.Close();
        }
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        this.Close();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        this.Close();
    }
  }
}
