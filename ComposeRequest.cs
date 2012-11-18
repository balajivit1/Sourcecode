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
    public partial class ComposeRequest : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        Class1 cs = new Class1();
        int id;
        string p1, whoislogin = "", p2 = "", p3 = "", p4 = "", p5 = "", p6;
        string req, nam, city, exploc, curloc, wholog;
        public ComposeRequest()
        {
            InitializeComponent();
        }

        private void ComposeRequest_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 50;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.textBox1, "First Letter Shoul be Capital.");

            comboBox1.Enabled = true;
            comboBox1.Items.Insert(0, "--Select--");
            comboBox1.Items.Insert(1, "Hospital");
            comboBox1.Items.Insert(2, "Hotel");
            comboBox1.Items.Insert(3, "Bank");
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "--Select--")
            {
                comboBox2.Items.Clear();

                comboBox2.Text = "--Select--";
                comboBox3.Text = "--Select--";
                comboBox4.Text = "--Select--";
                comboBox5.Text = "--Select--";
                comboBox6.Text = "--Select--";
                comboBox7.Text = "--Select--";

                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;

            }
            else
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();

                if (comboBox1.SelectedItem.ToString() == "Hospital")
                {
                    comboBox2.Items.Insert(0, "--Select--");
                    comboBox2.Items.Insert(1, "Sri Rama Chandra");
                    comboBox2.Items.Insert(2, "Billroth");
                    comboBox2.Items.Insert(3, "Miot");
                    comboBox2.Items.Insert(4, "Hande");
                    comboBox2.Items.Insert(5, "Nagmani");
                    comboBox2.Items.Insert(6, "Other");
                    comboBox2.SelectedIndex = 0;
                }
                else
                {
                    if (comboBox1.SelectedItem.ToString() == "Hotel")
                    {
                        comboBox2.Items.Insert(0, "--Select--");
                        comboBox2.Items.Insert(1, "Grand Orient");
                        comboBox2.Items.Insert(2, "Radisson");
                        comboBox2.Items.Insert(3, "Goutham Manor");
                        comboBox2.Items.Insert(4, "Fisherman's Cove");
                        comboBox2.Items.Insert(5, "Park Sherton");
                        comboBox2.Items.Insert(6, "Other");
                        comboBox2.SelectedIndex = 0;
                    }
                    else
                    {
                        if (comboBox1.SelectedItem.ToString() == "Bank")
                        {
                            comboBox2.Items.Insert(0, "--Select--");
                            comboBox2.Items.Insert(1, "Corporation");
                            comboBox2.Items.Insert(2, "Canara");
                            comboBox2.Items.Insert(3, "Axis");
                            comboBox2.Items.Insert(4, "ABN AMRO");
                            comboBox2.Items.Insert(5, "IOB");
                            comboBox2.Items.Insert(6, "Other");
                            comboBox2.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Other")
            {
                comboBox2.Visible = false;
                textBox1.Visible = true;
            }

            if (comboBox2.SelectedItem.ToString() == "--Select--")
            {
                comboBox3.Text = "--Select--";
                comboBox4.Text = "--Select--";
                comboBox5.Text = "--Select--";
                comboBox6.Text = "--Select--";
                comboBox7.Text = "--Select--";

                comboBox3.Items.Clear();

                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
            }
            else
            {
                comboBox3.Items.Clear();

                comboBox3.Enabled = true;
                comboBox3.Items.Insert(0, "--Select--");
                comboBox3.Items.Insert(1, "Trichy");
                comboBox3.Items.Insert(2, "Chennai");
                comboBox3.Items.Insert(3, "Kanchipuram");
                comboBox3.Items.Insert(4, "Tirunelveli");
                comboBox3.Items.Insert(5, "Tanjore");
                comboBox3.SelectedIndex = 0;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "--Select--")
            {
                comboBox4.Text = "--Select--";
                comboBox5.Text = "--Select--";
                comboBox6.Text = "--Select--";
                comboBox7.Text = "--Select--";

                comboBox4.Items.Clear();
                comboBox6.Items.Clear();

                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
            }
            else
            {
                comboBox4.Enabled = true;
                comboBox4.Items.Clear();
                comboBox6.Items.Clear();

                if (comboBox3.SelectedItem.ToString() == "Trichy")
                {
                    comboBox4.Items.Insert(0, "--Select--");
                    comboBox4.Items.Insert(1, "Any..");
                    comboBox4.Items.Insert(2, "Koraikudi");
                    comboBox4.Items.Insert(3, "Pungalur");
                    comboBox4.Items.Insert(4, "Kumbakonam");
                    comboBox4.Items.Insert(5, "Thuvakudi ");
                    comboBox4.Items.Insert(6, "Karur");
                    comboBox4.Items.Insert(7, "Other");
                    comboBox4.SelectedIndex = 0;

                    comboBox6.Items.Insert(0, "--Select--");
                    comboBox6.Items.Insert(1, "Karur");
                    comboBox6.Items.Insert(2, "Koraikudi");
                    comboBox6.Items.Insert(3, "Pungalur");
                    comboBox6.Items.Insert(4, "Kumbakonam");
                    comboBox6.Items.Insert(5, "Thuvakudi ");
                    comboBox6.Items.Insert(6, "Other");
                    comboBox6.SelectedIndex = 0;
                }
                else
                {
                    if (comboBox3.SelectedItem.ToString() == "Chennai")
                    {
                        comboBox4.Items.Insert(0, "--Select--");
                        comboBox4.Items.Insert(1, "Any..");
                        comboBox4.Items.Insert(2, "Saidapet");
                        comboBox4.Items.Insert(3, "Tnagar");
                        comboBox4.Items.Insert(4, "Guindy");
                        comboBox4.Items.Insert(5, "Koyambedu ");
                        comboBox4.Items.Insert(6, "Kodambakam ");
                        comboBox4.Items.Insert(7, "Other");
                        comboBox4.SelectedIndex = 0;

                        comboBox6.Items.Insert(0, "--Select--");
                        comboBox6.Items.Insert(1, "Kodambakam");
                        comboBox6.Items.Insert(2, "Saidapet");
                        comboBox6.Items.Insert(3, "Tnagar");
                        comboBox6.Items.Insert(4, "Guindy");
                        comboBox6.Items.Insert(5, "Koyambedu ");
                        comboBox6.Items.Insert(6, "Other");
                        comboBox6.SelectedIndex = 0;
                    }
                    else
                    {
                        if (comboBox3.SelectedItem.ToString() == "Kanchipuram")
                        {
                            comboBox4.Items.Insert(0, "--Select--");
                            comboBox4.Items.Insert(1, "Any..");
                            comboBox4.Items.Insert(2, "Attur");
                            comboBox4.Items.Insert(3, "Menachi");
                            comboBox4.Items.Insert(4, "Melur");
                            comboBox4.Items.Insert(5, "Kachana");
                            comboBox4.Items.Insert(6, "Cheyur");
                            comboBox4.Items.Insert(7, "Other");
                            comboBox4.SelectedIndex = 0;

                            comboBox6.Items.Insert(0, "--Select--");
                            comboBox6.Items.Insert(1, "Cheyur");
                            comboBox6.Items.Insert(2, "Attur");
                            comboBox6.Items.Insert(3, "Menachi");
                            comboBox6.Items.Insert(4, "Melur");
                            comboBox6.Items.Insert(5, "Kachana");
                            comboBox6.Items.Insert(6, "Other");
                            comboBox6.SelectedIndex = 0;
                        }
                        else
                        {
                            if (comboBox3.SelectedItem.ToString() == "Tirunelveli")
                            {
                                comboBox4.Items.Insert(0, "--Select--");
                                comboBox4.Items.Insert(1, "Any..");
                                comboBox4.Items.Insert(2, "Tiruchendur");
                                comboBox4.Items.Insert(3, "Sivakasi");
                                comboBox4.Items.Insert(4, "Kovilpatti");
                                comboBox4.Items.Insert(5, "Tuty");
                                comboBox4.Items.Insert(6, "Nazareth");
                                comboBox4.Items.Insert(7, "Other");
                                comboBox4.SelectedIndex = 0;

                                comboBox6.Items.Insert(0, "--Select--");
                                comboBox6.Items.Insert(1, "Nazareth");
                                comboBox6.Items.Insert(2, "Tiruchendur");
                                comboBox6.Items.Insert(3, "Sivakasi");
                                comboBox6.Items.Insert(4, "Kovilpatti");
                                comboBox6.Items.Insert(5, "Tuty");
                                comboBox6.Items.Insert(6, "Other");
                                comboBox6.SelectedIndex = 0;
                            }
                            else
                            {
                                if (comboBox3.SelectedItem.ToString() == "Tanjore")
                                {
                                    comboBox4.Items.Insert(0, "--Select--");
                                    comboBox4.Items.Insert(1, "Any..");
                                    comboBox4.Items.Insert(2, "Brihadeeswara ");
                                    comboBox4.Items.Insert(3, "Manora");
                                    comboBox4.Items.Insert(4, "Napoleo");
                                    comboBox4.Items.Insert(5, "Satiy");
                                    comboBox4.Items.Insert(6, "Keranoor");
                                    comboBox4.Items.Insert(7, "Other");
                                    comboBox4.SelectedIndex = 0;

                                    comboBox6.Items.Insert(0, "--Select--");
                                    comboBox6.Items.Insert(1, "Keranoor");
                                    comboBox6.Items.Insert(2, "Brihadeeswara ");
                                    comboBox6.Items.Insert(3, "Manora");
                                    comboBox6.Items.Insert(4, "Napoleo");
                                    comboBox6.Items.Insert(5, "Satiy");
                                    comboBox6.Items.Insert(6, "Other");
                                    comboBox6.SelectedIndex = 0;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString() == "Other")
            {
                comboBox4.Visible = false;
                textBox2.Visible = true;
            }

            if (comboBox4.SelectedItem.ToString() == "--Select--")
            {
                comboBox5.Text = "--Select--";
                comboBox6.Text = "--Select--";
                comboBox7.Text = "--Select--";

                //comboBox6.Items.Clear();

                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
            }
            else
            {
                comboBox6.Enabled = true;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedItem.ToString() == "Other")
            {
                comboBox6.Visible = false;
                textBox3.Visible = true;
            }

            if (comboBox6.SelectedItem.ToString() == "--Select--")
            {
                comboBox7.Text = "--Select--";

                comboBox7.Items.Clear();

                comboBox7.Enabled = false;
            }
            else
            {
                comboBox7.Enabled = true;
                comboBox7.Items.Clear();

                comboBox7.Items.Insert(0, "--Select--");
                comboBox7.SelectedIndex = 0;
                SqlConnection con1 = new SqlConnection(constring);
                con1.Open();
                SqlDataAdapter adp = new SqlDataAdapter("Select LoginID from Registration where LoginType='Admin'", con1);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    comboBox7.Items.Add(ds.Tables[0].Rows[i]["LoginID"].ToString());
                }
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedItem.ToString() == "--Select--")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);

            SqlDataAdapter adp = new SqlDataAdapter("Select LoginID,whoislogin from Registration where whoislogin !='" + whoislogin + "'", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                p1 = ds.Tables[0].Rows[i]["LoginID"].ToString();
            }

            SqlDataAdapter adp1 = new SqlDataAdapter("select * from ComposeRequest", con);
            DataSet ds1=new DataSet();
            adp1.Fill(ds1);

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                req = ds1.Tables[0].Rows[i]["CReqby"].ToString();
                nam = ds1.Tables[0].Rows[i]["CName"].ToString();
                city = ds1.Tables[0].Rows[i]["CCity"].ToString();
                exploc = ds1.Tables[0].Rows[i]["CExpLocation"].ToString();
                curloc = ds1.Tables[0].Rows[i]["CcurLocation"].ToString();
                wholog = ds1.Tables[0].Rows[i]["CReqFrom"].ToString();

                if (comboBox2.Visible == false & comboBox4.Visible == true & comboBox6.Visible == true)
                {
                    if (comboBox1.SelectedItem.ToString() == req & textBox1.Text == nam & comboBox3.SelectedItem.ToString() == city & comboBox4.SelectedItem.ToString() == exploc & comboBox6.SelectedItem.ToString() == curloc & p1 == wholog)
                    {
                        p5 = "yes";

                        DialogResult dlgResult1 = MessageBox.Show("This Request is already sent.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (dlgResult1 == DialogResult.OK)
                        {
                            button2_Click(null, EventArgs.Empty);
                        }
                        goto Outer;
                    }
                }

                if (comboBox2.Visible == false & comboBox4.Visible == false & comboBox6.Visible == true)
                {
                    if (comboBox1.SelectedItem.ToString() == req & textBox1.Text == nam & comboBox3.SelectedItem.ToString() == city & textBox2.Text == exploc & comboBox6.SelectedItem.ToString() == curloc & p1 == wholog)
                    {
                        p5 = "yes";

                        DialogResult dlgResult1 = MessageBox.Show("This Request is already sent.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (dlgResult1 == DialogResult.OK)
                        {
                            button2_Click(null, EventArgs.Empty);
                        }
                        goto Outer;
                    }
                }

                if (comboBox2.Visible == true & comboBox4.Visible == false & comboBox6.Visible == false)
                {
                    if (comboBox1.SelectedItem.ToString() == req & comboBox2.SelectedItem.ToString() == nam & comboBox3.SelectedItem.ToString() == city & textBox2.Text == exploc & textBox3.Text == curloc & p1 == wholog)
                    {
                        p5 = "yes";

                        DialogResult dlgResult1 = MessageBox.Show("This Request is already sent.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (dlgResult1 == DialogResult.OK)
                        {
                            button2_Click(null, EventArgs.Empty);
                        }
                        goto Outer;
                    }
                }

                if (comboBox2.Visible == true & comboBox4.Visible == true & comboBox6.Visible == false)
                {
                    if (comboBox1.SelectedItem.ToString() == req & comboBox2.SelectedItem.ToString() == nam & comboBox3.SelectedItem.ToString() == city & comboBox4.SelectedItem.ToString() == exploc & textBox3.Text == curloc & p1 == wholog)
                    {
                        p5 = "yes";

                        DialogResult dlgResult1 = MessageBox.Show("This Request is already sent.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (dlgResult1 == DialogResult.OK)
                        {
                            button2_Click(null, EventArgs.Empty);
                        }
                        goto Outer;
                    }
                }

                if (comboBox2.Visible == false & comboBox4.Visible == true & comboBox6.Visible == false)
                {
                    if (comboBox1.SelectedItem.ToString() == req & textBox1.Text == nam & comboBox3.SelectedItem.ToString() == city & comboBox4.SelectedItem.ToString() == exploc & textBox3.Text == curloc & p1 == wholog)
                    {
                        p5 = "yes";

                        DialogResult dlgResult1 = MessageBox.Show("This Request is already sent.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (dlgResult1 == DialogResult.OK)
                        {
                            button2_Click(null, EventArgs.Empty);
                        }
                        goto Outer;
                    }
                }

                if (comboBox2.Visible == true & comboBox4.Visible == false & comboBox6.Visible == true)
                {
                    if (comboBox1.SelectedItem.ToString() == req & comboBox2.SelectedItem.ToString() == nam & comboBox3.SelectedItem.ToString() == city & textBox2.Text == exploc & comboBox6.SelectedItem.ToString() == curloc & p1 == wholog)
                    {
                        p5 = "yes";

                        DialogResult dlgResult1 = MessageBox.Show("This Request is already sent.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (dlgResult1 == DialogResult.OK)
                        {
                            button2_Click(null, EventArgs.Empty);
                        }
                        goto Outer;
                    }
                }

                if (comboBox2.Visible == true & comboBox4.Visible == true & comboBox6.Visible == false)
                {
                    if (comboBox1.SelectedItem.ToString() == req & textBox1.Text == nam & comboBox3.SelectedItem.ToString() == city & comboBox4.SelectedItem.ToString() == exploc & textBox3.Text == curloc & p1 == wholog)
                    {
                        p5 = "yes";

                        DialogResult dlgResult1 = MessageBox.Show("This Request is already sent.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (dlgResult1 == DialogResult.OK)
                        {
                            button2_Click(null, EventArgs.Empty);
                        }
                        goto Outer;
                    }
                }
            }
        Outer:
            p6 = "";

            if (p5 != "yes")
            {
                id = Convert.ToInt32(cs.composedetails());
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPComposeRequest";

                cmd.Parameters.Add("@CID", SqlDbType.Int, 0);
                cmd.Parameters["@CID"].Value = id;

                cmd.Parameters.Add("@CReqby", SqlDbType.VarChar, 50);
                cmd.Parameters["@CReqby"].Value = comboBox1.SelectedItem.ToString();

                if (comboBox2.Visible == true)
                {
                    cmd.Parameters.Add("@CName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CName"].Value = comboBox2.SelectedItem.ToString();
                }
                else
                {
                    cmd.Parameters.Add("@CName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CName"].Value = textBox1.Text;
                }

                cmd.Parameters.Add("@CCity", SqlDbType.VarChar, 50);
                cmd.Parameters["@CCity"].Value = comboBox3.SelectedItem.ToString();

                if (comboBox4.Visible == true)
                {
                    cmd.Parameters.Add("@CExpLocation", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CExpLocation"].Value = comboBox4.SelectedItem.ToString();
                }
                else
                {
                    cmd.Parameters.Add("@CExpLocation", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CExpLocation"].Value = textBox2.Text;
                }

                if (comboBox6.Visible == true)
                {
                    cmd.Parameters.Add("@CcurLocation", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CcurLocation"].Value = comboBox6.SelectedItem.ToString();
                }
                else
                {
                    cmd.Parameters.Add("@CcurLocation", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CcurLocation"].Value = textBox3.Text;
                }

                cmd.Parameters.Add("@CReqFrom", SqlDbType.VarChar, 50);
                cmd.Parameters["@CReqFrom"].Value = p1;

                cmd.Parameters.Add("@CReqTo", SqlDbType.VarChar, 50);
                cmd.Parameters["@CReqTo"].Value = comboBox7.SelectedItem.ToString();

                cmd.Parameters.Add("@CView", SqlDbType.VarChar, 50);
                cmd.Parameters["@CView"].Value = p2;

                cmd.Parameters.Add("@CReqToManager", SqlDbType.VarChar, 50);
                cmd.Parameters["@CReqToManager"].Value = p3;

                cmd.Parameters.Add("@CStatus", SqlDbType.VarChar, 50);
                cmd.Parameters["@CStatus"].Value = p4;

                cmd.Parameters.Add("@CSentManToAdmin", SqlDbType.VarChar, 50);
                cmd.Parameters["@CSentManToAdmin"].Value = p4;

                cmd.ExecuteNonQuery();

                DialogResult dlgResult = MessageBox.Show("Request Sent Successfully..", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (dlgResult == DialogResult.OK)
                {
                    button2_Click(null, EventArgs.Empty);
                }
            }
            //
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox2.Visible = true;
            textBox1.Visible = false;
            comboBox4.Visible = true;
            textBox2.Visible = false;
            comboBox6.Visible = true;
            textBox3.Visible = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox6.Enabled = false;
            comboBox7.Enabled = false;

            comboBox1.Text = "--Select--";
            comboBox2.Text = "--Select--";
            comboBox3.Text = "--Select--";
            comboBox4.Text = "--Select--";
            comboBox6.Text = "--Select--";
            comboBox7.Text = "--Select--";

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            button1.Enabled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
