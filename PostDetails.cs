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
    public partial class PostDetails : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        Class1 cs = new Class1();
        int id;
        public PostDetails()
        {
            InitializeComponent();
        }

        private void PostDetails_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Insert(0, "--Select--");
            comboBox1.Items.Insert(1, "Trichy");
            comboBox1.Items.Insert(2, "Chennai");
            comboBox1.Items.Insert(3, "Kanchipuram");
            comboBox1.Items.Insert(4, "Tirunelveli");
            comboBox1.Items.Insert(5, "Tanjore");
            comboBox1.Items.Insert(6, "Other");
            comboBox1.SelectedIndex = 0;

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 50;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.textBox1, "First Letter Should be Capital.");
            toolTip1.SetToolTip(this.textBox2, "First Letter Should be Capital.");
            toolTip1.SetToolTip(this.textBox3, "First Letter Should be Capital.");
            toolTip1.SetToolTip(this.textBox4, "First Letter Should be Capital.");

            comboBox5.Items.Insert(0, "--Select--");
            comboBox5.Items.Insert(1, "City");
            comboBox5.Items.Insert(2, "Post");
            comboBox5.Items.Insert(3, "Location");
            comboBox5.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Enabled == false & textBox1.Text=="")
            {
                    MessageBox.Show("Enter City.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (comboBox2.SelectedItem.ToString() == "--Select--")
                {
                    MessageBox.Show("Selct Post.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (comboBox3.SelectedItem.ToString() == "--Select--")
                    {
                        MessageBox.Show("Selct Name.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (richTextBox1.Text == "")
                        {
                            MessageBox.Show("Enter Address.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (comboBox3.SelectedItem.ToString() == "--Select--")
                            {
                                MessageBox.Show("Selct Location.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if (comboBox2.Enabled == false & textBox2.Text == "")
                                {
                                    MessageBox.Show("Enter Post.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    if (comboBox3.Enabled == false & textBox3.Text == "")
                                    {
                                        MessageBox.Show("Enter Name.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        if (comboBox4.Enabled == false & textBox4.Text == "")
                                        {
                                            MessageBox.Show("Enter Location.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                        
                                        
                                        else
                                        {
                                            if (textBox5.Text == "")
                                            {
                                                MessageBox.Show("Enter Phone Number.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                            else
                                            {
                                                SqlConnection con = new SqlConnection(constring);
                                                id = Convert.ToInt32(cs.postdetails());
                                                SqlCommand cmd = new SqlCommand();
                                                con.Open();
                                                cmd.Connection = con;
                                                cmd.CommandType = CommandType.StoredProcedure;
                                                cmd.CommandText = "SPpostdetails";

                                                cmd.Parameters.Add("@PID", SqlDbType.Int, 0);
                                                cmd.Parameters["@PID"].Value = id;

                                                if (comboBox1.Enabled == true)
                                                {
                                                    cmd.Parameters.Add("@PCity", SqlDbType.VarChar, 50);
                                                    cmd.Parameters["@PCity"].Value = comboBox1.SelectedItem.ToString();
                                                }
                                                else
                                                {
                                                    cmd.Parameters.Add("@PCity", SqlDbType.VarChar, 50);
                                                    cmd.Parameters["@PCity"].Value = textBox1.Text;
                                                }

                                                if (comboBox2.Enabled == true)
                                                {
                                                    cmd.Parameters.Add("@PPost", SqlDbType.VarChar, 50);
                                                    cmd.Parameters["@PPost"].Value = comboBox2.SelectedItem.ToString();
                                                }
                                                else
                                                {
                                                    cmd.Parameters.Add("@PPost", SqlDbType.VarChar, 50);
                                                    cmd.Parameters["@PPost"].Value = textBox2.Text;
                                                }

                                                if (comboBox3.Enabled == true)
                                                {
                                                    cmd.Parameters.Add("@PName", SqlDbType.VarChar, 50);
                                                    cmd.Parameters["@PName"].Value = comboBox3.SelectedItem.ToString();
                                                }
                                                else
                                                {
                                                    cmd.Parameters.Add("@PName", SqlDbType.VarChar, 50);
                                                    cmd.Parameters["@PName"].Value = textBox3.Text;
                                                }

                                                cmd.Parameters.Add("@PAddress", SqlDbType.NVarChar, 100);
                                                cmd.Parameters["@PAddress"].Value = richTextBox1.Text;

                                                if (comboBox4.Enabled == true)
                                                {
                                                    cmd.Parameters.Add("@PLocation", SqlDbType.VarChar, 50);
                                                    cmd.Parameters["@PLocation"].Value = comboBox4.SelectedItem.ToString();
                                                }
                                                else
                                                {
                                                    cmd.Parameters.Add("@PLocation", SqlDbType.VarChar, 50);
                                                    cmd.Parameters["@PLocation"].Value = textBox4.Text;
                                                }

                                                cmd.Parameters.Add("@PPhone", SqlDbType.VarChar, 50);
                                                cmd.Parameters["@PPhone"].Value = textBox5.Text;

                                                cmd.ExecuteNonQuery();

                                                DialogResult dlgResult = MessageBox.Show("Details Posted Successfully..", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                if (dlgResult == DialogResult.OK)
                                                {
                                                    button2_Click(null, EventArgs.Empty);
                                                }
                                            }
                                        }


                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            richTextBox1.Enabled = false;
            comboBox4.Enabled = false;

            comboBox1.Text = "--Select--";
            comboBox2.Text = "--Select--";
            comboBox3.Text = "--Select--";
            comboBox4.Text = "--Select--";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            richTextBox1.Text = "";

            label7.Visible = false;
            textBox1.Visible = false;
            label8.Visible = false;
            textBox2.Visible = false;
            label9.Visible = false;
            textBox3.Visible = false;
            label10.Visible = false;
            textBox4.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "--Select--")
            {
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                richTextBox1.Enabled = false;
                comboBox4.Enabled = false;

                comboBox2.Text = "--Select--";
                comboBox3.Text = "--Select--";
                comboBox4.Text = "--Select--";
                richTextBox1.Text = "";

                label7.Visible = false;
                textBox1.Visible = false;
                label8.Visible = false;
                textBox2.Visible = false;
                label9.Visible = false;
                textBox3.Visible = false;
                label10.Visible = false;
                textBox4.Visible = false;
            }
            else
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();
                comboBox4.Items.Clear();
                comboBox2.Items.Insert(0, "--Select--");
                comboBox2.Items.Insert(1, "Hospital");
                comboBox2.Items.Insert(2, "Hotel");
                comboBox2.Items.Insert(3, "Bank");
                comboBox2.Items.Insert(4, "Other");
                comboBox2.SelectedIndex = 0;

                if (comboBox1.SelectedItem.ToString() == "Trichy")
                {
                    comboBox4.Items.Insert(0, "--Select--");
                    comboBox4.Items.Insert(1, "Koraikudi");
                    comboBox4.Items.Insert(2, "Pungalur");
                    comboBox4.Items.Insert(3, "Kumbakonam");
                    comboBox4.Items.Insert(4, "Thuvakudi ");
                    comboBox4.Items.Insert(5, "Karur");
                    comboBox4.Items.Insert(6, "Other");
                    comboBox4.SelectedIndex = 0;
                }
                else
                {
                    if (comboBox1.SelectedItem.ToString() == "Chennai")
                    {
                        comboBox4.Items.Insert(0, "--Select--");
                        comboBox4.Items.Insert(1, "Saidapet");
                        comboBox4.Items.Insert(2, "Tnagar");
                        comboBox4.Items.Insert(3, "Guindy");
                        comboBox4.Items.Insert(4, "Koyambedu ");
                        comboBox4.Items.Insert(5, "Kodambakam ");
                        comboBox4.Items.Insert(6, "Other");
                        comboBox4.SelectedIndex = 0;
                    }
                    else
                    {
                        if (comboBox1.SelectedItem.ToString() == "Kanchipuram")
                        {
                            comboBox4.Items.Insert(0, "--Select--");
                            comboBox4.Items.Insert(1, "Attur");
                            comboBox4.Items.Insert(2, "Menachi");
                            comboBox4.Items.Insert(3, "Melur");
                            comboBox4.Items.Insert(4, "Kachana");
                            comboBox4.Items.Insert(5, "Cheyur");
                            comboBox4.Items.Insert(6, "Other");
                            comboBox4.SelectedIndex = 0;
                        }
                        else
                        {
                            if (comboBox1.SelectedItem.ToString() == "Tirunelveli")
                            {
                                comboBox4.Items.Insert(0, "--Select--");
                                comboBox4.Items.Insert(1, "Tiruchendur");
                                comboBox4.Items.Insert(2, "Sivakasi");
                                comboBox4.Items.Insert(3, "Kovilpatti");
                                comboBox4.Items.Insert(4, "Tuty");
                                comboBox4.Items.Insert(5, "Nazareth");
                                comboBox4.Items.Insert(6, "Other");
                                comboBox4.SelectedIndex = 0;
                            }
                            else
                            {
                                if (comboBox1.SelectedItem.ToString() == "Tanjore")
                                {
                                    comboBox4.Items.Insert(0, "--Select--");
                                    comboBox4.Items.Insert(1, "Brihadeeswara ");
                                    comboBox4.Items.Insert(2, "Manora");
                                    comboBox4.Items.Insert(3, "Napoleo");
                                    comboBox4.Items.Insert(4, "Satiy");
                                    comboBox4.Items.Insert(5, "Keranoor");
                                    comboBox4.Items.Insert(6, "Other");
                                    comboBox4.SelectedIndex = 0;
                                }
                                else
                                {
                                    if (comboBox1.SelectedItem.ToString() == "Other")
                                    {
                                        comboBox1.Enabled = false;
                                        comboBox2.Enabled = true;
                                        label7.Visible = true;
                                        textBox1.Visible = true;
                                        label10.Visible = true;
                                        textBox4.Visible = true;
                                        button1.Enabled = true;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                        }
                    }
                }

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "--Select--")
            {
                comboBox3.Enabled = false;
                richTextBox1.Enabled = false;
                comboBox4.Enabled = false;

                comboBox3.Text = "--Select--";
                comboBox4.Text = "--Select--";
                richTextBox1.Text = "";

                label8.Visible = false;
                textBox2.Visible = false;
                label9.Visible = false;
                textBox3.Visible = false;
                label10.Visible = false;
                textBox4.Visible = false;
            }
            else
            {
                comboBox3.Enabled = true;
                comboBox4.Enabled = false;
                comboBox3.Items.Clear();

                if (comboBox2.SelectedItem.ToString() == "Hospital")
                {
                    comboBox3.Items.Insert(0, "--Select--");
                    comboBox3.Items.Insert(1, "Sri Rama Chandra");
                    comboBox3.Items.Insert(2, "Billroth");
                    comboBox3.Items.Insert(3, "Miot");
                    comboBox3.Items.Insert(4, "Hande");
                    comboBox3.Items.Insert(5, "Nagmani");
                    comboBox3.Items.Insert(6, "Other");
                    comboBox3.SelectedIndex = 0;
                }
                else
                {
                    if (comboBox2.SelectedItem.ToString() == "Hotel")
                    {
                        comboBox3.Items.Insert(0, "--Select--");
                        comboBox3.Items.Insert(1, "Grand Orient");
                        comboBox3.Items.Insert(2, "Radisson");
                        comboBox3.Items.Insert(3, "Goutham Manor");
                        comboBox3.Items.Insert(4, "Fisherman's Cove");
                        comboBox3.Items.Insert(5, "Park Sherton");
                        comboBox3.Items.Insert(6, "Other");
                        comboBox3.SelectedIndex = 0;
                    }
                    else
                    {
                        if (comboBox2.SelectedItem.ToString() == "Bank")
                        {
                            comboBox3.Items.Insert(0, "--Select--");
                            comboBox3.Items.Insert(1, "Corporation");
                            comboBox3.Items.Insert(2, "Canara");
                            comboBox3.Items.Insert(3, "Axis");
                            comboBox3.Items.Insert(4, "ABN AMRO");
                            comboBox3.Items.Insert(5, "IOB");
                            comboBox3.Items.Insert(6, "Other");
                            comboBox3.SelectedIndex = 0;
                        }
                        else
                        {
                            if (comboBox2.SelectedItem.ToString() == "Other")
                            {
                                comboBox3.Text = "Other";
                                comboBox4.Text = "Other";
                                comboBox2.Enabled = false;
                                comboBox3.Enabled = true;
                                comboBox3.Items.Clear();
                                comboBox3.Items.Insert(0, "--Select--");
                                comboBox3.Items.Insert(1, "Other");
                                comboBox3.SelectedIndex = 0;
                                comboBox4.Enabled = false;
                                richTextBox1.Enabled = true;
                                label8.Visible = true;
                                textBox2.Visible = true;
                                label9.Visible = false;
                                textBox3.Visible = false;
                                label10.Visible = true;
                                textBox4.Visible = true;
                                button1.Enabled = true;
                            }
                            else
                            {
                                if (comboBox2.SelectedItem.ToString() != "Other")
                                {
                                    label9.Visible = false;
                                    textBox3.Visible = false;
                                }
                            }

                        }
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "--Select--")
            {
                comboBox4.Text = "--Select--";
                comboBox4.Enabled = false;
                
                label10.Visible = false;
                textBox4.Visible = false;
            }
            else
            {
                richTextBox1.Enabled = true;
                comboBox4.Enabled = true;
                if (comboBox3.SelectedItem.ToString() == "Other")
                {
                    comboBox3.Enabled = false;
                    button1.Enabled = true;
                    //label8.Visible = true;
                    //textBox2.Visible = true;
                    comboBox4.Enabled = false;
                    label9.Visible = true;
                    textBox3.Visible = true;
                    label10.Visible = true;
                    textBox4.Visible = true;
                }
                else
                {
                    if (comboBox3.SelectedItem.ToString() != "Other")
                    {
                        label9.Visible = false;
                        textBox3.Visible = false;
                    }
                }
            }
           
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString() == "--Select--")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                if (comboBox4.SelectedItem.ToString() == "Other")
                {
                    comboBox4.Enabled = false;
                    label10.Visible = true;
                    textBox4.Visible = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(constring);

            if (comboBox5.SelectedItem.ToString() == "City")
            {
                con1.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from postdetails where PCity='" + comboBox6.SelectedItem.ToString() + "'", con1);
                DataSet ds = new DataSet();
                BindingSource bsourse = new BindingSource();
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                da.Fill(ds, "postdetails");
                ds.Tables[0].Constraints.Add("PCity", ds.Tables[0].Columns[0], true);
                bsourse.DataSource = ds.Tables["postdetails"];
                dataGridView1.DataSource = bsourse;
                con1.Close();
                dataGridView1.Visible = true;
            }
            else
            {
                if (comboBox5.SelectedItem.ToString() == "Post")
                {
                    con1.Open();
                    SqlDataAdapter da = new SqlDataAdapter("Select * from postdetails where PPost='" + comboBox6.SelectedItem.ToString() + "'", con1);
                    DataSet ds = new DataSet();
                    BindingSource bsourse = new BindingSource();
                    SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                    da.Fill(ds, "postdetails");
                    ds.Tables[0].Constraints.Add("PPost", ds.Tables[0].Columns[0], true);
                    bsourse.DataSource = ds.Tables["postdetails"];
                    dataGridView1.DataSource = bsourse;
                    con1.Close();
                    dataGridView1.Visible = true;
                }
                else
                {
                    if (comboBox5.SelectedItem.ToString() == "Location")
                    {
                        con1.Open();
                        SqlDataAdapter da = new SqlDataAdapter("Select * from postdetails where PLocation='" + comboBox6.SelectedItem.ToString() + "'", con1);
                        DataSet ds = new DataSet();
                        BindingSource bsourse = new BindingSource();
                        SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                        da.Fill(ds, "postdetails");
                        ds.Tables[0].Constraints.Add("PLocation", ds.Tables[0].Columns[0], true);
                        bsourse.DataSource = ds.Tables["postdetails"];
                        dataGridView1.DataSource = bsourse;
                        con1.Close();
                        dataGridView1.Visible = true;
                    }
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);

            if (comboBox5.SelectedItem.ToString() == "City")
            {
                button3.Enabled = true;
                comboBox6.Enabled = true;
                comboBox6.Items.Clear();
                comboBox6.Items.Insert(0, "--Select--");
                comboBox6.SelectedIndex = 0;
                con.Open();
                SqlCommand cmd;
                SqlDataReader dr;
                cmd = new SqlCommand("Select DISTINCT PCity from postdetails", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr[0].ToString().Length > 0)
                    {
                        comboBox6.Items.Add(dr[0].ToString());
                    }
                }
                con.Close();
            }
            else
            {
                if (comboBox5.SelectedItem.ToString() == "Post")
                {
                    button3.Enabled = true;
                    comboBox6.Enabled = true;
                    comboBox6.Items.Clear();
                    comboBox6.Items.Insert(0, "--Select--");
                    comboBox6.SelectedIndex = 0;
                    con.Open();
                    SqlCommand cmd;
                    SqlDataReader dr;
                    cmd = new SqlCommand("Select DISTINCT PPost from postdetails", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString().Length > 0)
                        {
                            comboBox6.Items.Add(dr[0].ToString());
                        }
                    }
                    con.Close();
                }
                else
                {
                    if (comboBox5.SelectedItem.ToString() == "Location")
                    {
                        button3.Enabled = true;
                        comboBox6.Enabled = true;
                        comboBox6.Items.Clear();
                        comboBox6.Items.Insert(0, "--Select--");
                        comboBox6.SelectedIndex = 0;
                        con.Open();
                        SqlCommand cmd;
                        SqlDataReader dr;
                        cmd = new SqlCommand("Select DISTINCT PLocation from postdetails", con);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString().Length > 0)
                            {
                                comboBox6.Items.Add(dr[0].ToString());
                            }
                        }
                        con.Close();
                    }
                    else
                    {
                        if (comboBox6.Text == "--Select--")
                        {
                            button3.Enabled = false;
                        }
                        else
                        {
                            if (comboBox5.Text == "--Select--")
                            {
                                button3.Enabled = false;
                            }
                        }
                    }
                }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
