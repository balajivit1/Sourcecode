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
    public partial class Taskschedule : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);

        public Taskschedule()
        {
            InitializeComponent();
        }

        private void Taskschedule_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            comboBox1.Items.Clear();

            comboBox1.Items.Insert(0, "--Select--");
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Clear();

            comboBox2.Items.Insert(0, "--Select--");
            comboBox2.SelectedIndex = 0;
            SqlConnection con1 = new SqlConnection(constring);
            con1.Open();
            SqlDataAdapter adp = new SqlDataAdapter("Select distinct PPost from postdetails", con1);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i]["PPost"].ToString());
            }
            SqlDataAdapter adp1 = new SqlDataAdapter("Select LoginID from Registration where LoginType='Manager'", con1);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                comboBox2.Items.Add(ds1.Tables[0].Rows[j]["LoginID"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter adapter = new SqlDataAdapter("select task,manage from schedules where task='" + comboBox1.SelectedItem.ToString() + "' and manage='" + comboBox2.SelectedItem.ToString() + "'", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            SqlDataAdapter adapter1 = new SqlDataAdapter("select task from schedules where task='" + comboBox1.SelectedItem.ToString() + "' ", con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1);
            SqlDataAdapter adapter2 = new SqlDataAdapter("select manage from schedules where manage='" + comboBox2.SelectedItem.ToString() + "' ", con);
            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DialogResult dlgResult1 = MessageBox.Show("This task is already assigned.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dlgResult1 == DialogResult.OK)
                {
                    //Admin vur = new Admin();
                    //vur.ShowDialog();
                    //this.Close();
                }
                //label4.Visible = true;
                //label4.Text = "This task is already assigned";
            }
            else if (ds1.Tables[0].Rows.Count > 0)
            {
                DialogResult dlgResult1 = MessageBox.Show("This task is already assigned.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dlgResult1 == DialogResult.OK)
                {
                    //Admin vur = new Admin();
                    //vur.ShowDialog();
                    //this.Close();
                }
                //label4.Visible = true;
                //label4.Text = "This task is already assigned";
            }
            else if (ds2.Tables[0].Rows.Count > 0)
            {
                DialogResult dlgResult1 = MessageBox.Show("This task is already assigned.", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dlgResult1 == DialogResult.OK)
                {
                    //Admin vur = new Admin();
                    //vur.ShowDialog();
                    //this.Close();
                }
                //label4.Visible = true;
                //label4.Text = "This task is already assigned";
            }


            else
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "inserttask";

                cmd.Parameters.Add("@task", SqlDbType.VarChar, 50);
                cmd.Parameters["@task"].Value = comboBox1.SelectedItem.ToString();

                cmd.Parameters.Add("@man", SqlDbType.VarChar, 50);
                cmd.Parameters["@man"].Value = comboBox2.SelectedItem.ToString();
                cmd.ExecuteNonQuery();

                DialogResult dlgResult1 = MessageBox.Show("Task Successfully Sent To Manager...", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dlgResult1 == DialogResult.OK)
                {
                    //Admin vur = new Admin();
                    //vur.ShowDialog();
                    //this.Close();
                }

                //label4.Visible = true;
                //label4.Text = "Task successfully sent to manager";
                //SqlCommand command = new SqlCommand("update ComposeRequest set CReqToManager='" + comboBox2.SelectedItem.ToString() + "',CStatus='Success' where CReqby='" + comboBox1.SelectedItem.ToString() + "'", con);
                //command.ExecuteNonQuery();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from schedules", con);
            cmd.ExecuteNonQuery();

            DialogResult dlgResult1 = MessageBox.Show("Clear All Tasks Successfully...", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (dlgResult1 == DialogResult.OK)
            {
                //Admin vur = new Admin();
                //vur.ShowDialog();
                this.Close();
            }
            con.Close();
        }
    }
}
