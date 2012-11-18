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
using System.Security.Cryptography;
using System.IO;

namespace AnonumousProject
{
    public partial class ViewAdminRequests : Form
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        string p1 = "View", p2 = "Success", p3 = "", p4 = "", wholog = "", p5 = "Sent";
        string F1, T1, x, y, z;
        string city, post, name, location;
        string recuser, id="";
        string encreq, encloc;
        string encdis;
        public ViewAdminRequests()
        {
            InitializeComponent();
        }

        private static string sKey = "UJYHCX783her*&5@$%#(MJCX**38n*#6835ncv56tvbry(&#MX98cn342cn4*&X#&";

        public static string Encrypt(string sPainText)
        {
            if (sPainText.Length == 0)
                return (sPainText);
            return (EncryptString(sPainText, sKey));
        }

        public static string Decrypt(string sEncryptText)
        {
            if (sEncryptText.Length == 0)
                return (sEncryptText);
            return (DecryptString(sEncryptText, sKey));
        }

        protected static string EncryptString(string InputText, string Password)
        {
            // "Password" string variable is nothing but the key(your secret key) value which is sent from the front end.
            // "InputText" string variable is the actual password sent from the login page.
            // We are now going to create an instance of the
            // Rihndael class.
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            // First we need to turn the input strings into a byte array.
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(InputText);
            // We are using Salt to make it harder to guess our key
            // using a dictionary attack.
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            // The (Secret Key) will be generated from the specified
            // password and Salt.
            //PasswordDeriveBytes -- It Derives a key from a password
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            // Create a encryptor from the existing SecretKey bytes.
            // We use 32 bytes for the secret key
            // (the default Rijndael key length is 256 bit = 32 bytes) and
            // then 16 bytes for the IV (initialization vector),
            // (the default Rijndael IV length is 128 bit = 16 bytes)
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
            // Create a MemoryStream that is going to hold the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();
            // Create a CryptoStream through which we are going to be processing our data.
            // CryptoStreamMode.Write means that we are going to be writing data
            // to the stream and the output will be written in the MemoryStream
            // we have provided. (always use write mode for encryption)
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            // Start the encryption process.
            cryptoStream.Write(PlainText, 0, PlainText.Length);
            // Finish encrypting.
            cryptoStream.FlushFinalBlock();
            // Convert our encrypted data from a memoryStream into a byte array.
            byte[] CipherBytes = memoryStream.ToArray();
            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();
            // Convert encrypted data into a base64-encoded string.
            // A common mistake would be to use an Encoding class for that.
            // It does not work, because not all byte values can be
            // represented by characters. We are going to be using Base64 encoding
            // That is designed exactly for what we are trying to do.
            string EncryptedData = Convert.ToBase64String(CipherBytes);
            // Return encrypted string.
            return EncryptedData;
        }

        protected static string DecryptString(string InputText, string Password)
        {
            try
            {
                RijndaelManaged RijndaelCipher = new RijndaelManaged();
                byte[] EncryptedData = Convert.FromBase64String(InputText);
                byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
                // Create a decryptor from the existing SecretKey bytes.
                ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream(EncryptedData);
                // Create a CryptoStream. (always use Read mode for decryption).
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
                // Since at this point we don't know what the size of decrypted data
                // will be, allocate the buffer long enough to hold EncryptedData;
                // DecryptedData is never longer than EncryptedData.
                byte[] PlainText = new byte[EncryptedData.Length];
                // Start decrypting.
                int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                memoryStream.Close();
                cryptoStream.Close();
                // Convert decrypted data into a string.
                string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
                // Return decrypted string.
                return DecryptedData;
            }
            catch (Exception exception)
            {
                return (exception.Message);
            }
        }

        private void ViewAdminRequests_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 50;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.label16, "Encrypted Value");
            toolTip1.SetToolTip(this.label40, "Encrypted Value");
            toolTip1.SetToolTip(this.label19, "Encrypted Value");

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("Select * from ComposeRequest where CView='" + p1 + "'", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                label14.Text = ds.Tables[0].Rows[0]["CID"].ToString();
                label15.Text = ds.Tables[0].Rows[0]["CReqby"].ToString();

                encreq = ds.Tables[0].Rows[0]["CName"].ToString();
                label16.Text = Encrypt(encreq);

                label17.Text = ds.Tables[0].Rows[0]["CCity"].ToString();
                label18.Text = ds.Tables[0].Rows[0]["CExpLocation"].ToString();

                encloc = ds.Tables[0].Rows[0]["CcurLocation"].ToString();
                label19.Text = Encrypt(encloc);

                label22.Text = ds.Tables[0].Rows[0]["CReqTo"].ToString();
                recuser = ds.Tables[0].Rows[0]["CReqFrom"].ToString();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from ComposeRequest", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                SqlCommand cmd1 = new SqlCommand("Update ComposeRequest set CView='" + p3 + "'", con);
                cmd1.ExecuteNonQuery();
            }
            con.Close();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
            button2.Visible = true;
            pictureBox2.Visible = true;


            SqlConnection con = new SqlConnection(constring);
            con.Open();

            SqlDataAdapter adp2 = new SqlDataAdapter("Select * from postdetails", con);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);

            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                city = ds2.Tables[0].Rows[i]["PCity"].ToString();
                post = ds2.Tables[0].Rows[i]["PPost"].ToString();
                name = ds2.Tables[0].Rows[i]["PName"].ToString();
                location = ds2.Tables[0].Rows[i]["PLocation"].ToString();
                if (city == label17.Text & post == label15.Text & name == encreq & location == label18.Text)
                {
                    //SqlDataAdapter adp3 = new SqlDataAdapter("Select * from postdetails", con);
                    //DataSet ds3 = new DataSet();
                    //adp3.Fill(ds3);
                    label25.Text = label17.Text;
                    label39.Text = label15.Text;
                    label40.Text = label16.Text;
                    label41.Text = label18.Text;
                    label43.Text = ds2.Tables[0].Rows[i]["PAddress"].ToString();
                    label44.Text = ds2.Tables[0].Rows[i]["PPhone"].ToString();
                    x = "yes";
                    goto Outer;
                }
            Outer:
                z = "";
                if (city == label17.Text & post == label15.Text & name == encreq & label18.Text == "Any..")
                {
                    //SqlDataAdapter adp3 = new SqlDataAdapter("Select * from postdetails", con);
                    //DataSet ds3 = new DataSet();
                    //adp3.Fill(ds3);
                    label25.Text = label17.Text;
                    label39.Text = label15.Text;
                    label40.Text = label16.Text;
                    label41.Text = ds2.Tables[0].Rows[i]["PLocation"].ToString();
                    label43.Text = ds2.Tables[0].Rows[i]["PAddress"].ToString();
                    label44.Text = ds2.Tables[0].Rows[i]["PPhone"].ToString();
                    x = "yes";
                    goto Outer1;
                }
            Outer1:
                z = "";
            }

            if (x == "yes")
            {
                SqlDataAdapter adp3 = new SqlDataAdapter("Select * from Distance", con);
                DataSet ds3 = new DataSet();
                adp3.Fill(ds3);

                encdis = Decrypt(label19.Text);

                for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
                {
                    F1 = ds3.Tables[0].Rows[j]["DFrom"].ToString();
                    T1 = ds3.Tables[0].Rows[j]["DTo"].ToString();
                    
                    if (F1 == encdis & T1 == label18.Text)
                    {
                        y = "yes";
                        label42.Text = ds3.Tables[0].Rows[j]["DDistance"].ToString() + " KM";
                    }
                }

                if (y != "yes")
                {
                    for (int k = 0; k < ds3.Tables[0].Rows.Count; k++)
                    {
                        F1 = ds3.Tables[0].Rows[k]["DFrom"].ToString();
                        T1 = ds3.Tables[0].Rows[k]["DTo"].ToString();
                        if (F1 == label18.Text & T1 == encdis)
                        {
                            y = "yes";
                            label42.Text = ds3.Tables[0].Rows[k]["DDistance"].ToString()+" KM";
                            //z="yes";
                        }
                    }
                }

                if (y != "yes")
                {
                    label42.Text = "KM (Not Defined)";
                }
            }
            else
            {
                panel2.Visible = false;
                label23.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
                        
            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from Registration where whoislogin!='" + wholog + "'", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            wholog = ds1.Tables[0].Rows[0]["whoislogin"].ToString();

            SqlDataAdapter adp = new SqlDataAdapter("Select * from ResManagerToAdmin where ResID='" + label14.Text + "'", con);
            DataSet ds=new DataSet();
            adp.Fill(ds);
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                id=ds.Tables[0].Rows[i]["ResID"].ToString();
            }

            if (id == "")
            {
                if (label23.Visible == true)
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SPResManagerToAdmin";

                    cmd.Parameters.Add("@ResID", SqlDbType.Int, 0);
                    cmd.Parameters["@ResID"].Value = label14.Text;

                    cmd.Parameters.Add("@RCity", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RCity"].Value = label17.Text;

                    cmd.Parameters.Add("@RReqby", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RReqby"].Value = label15.Text;

                    //cmd.Parameters.Add("@RName", SqlDbType.VarChar, 50);
                    //cmd.Parameters["@RName"].Value = label16.Text;

                    cmd.Parameters.Add("@RName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RName"].Value = encreq;

                    cmd.Parameters.Add("@RExpLocation", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RExpLocation"].Value = label18.Text;

                    cmd.Parameters.Add("@RCurLocation", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RCurLocation"].Value = encloc;

                    cmd.Parameters.Add("@RDistance", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RDistance"].Value = p4;

                    cmd.Parameters.Add("@RAddress", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RAddress"].Value = p4;

                    cmd.Parameters.Add("@RPhone", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RPhone"].Value = p4;

                    cmd.Parameters.Add("@RResAdmin", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RResAdmin"].Value = label22.Text;

                    cmd.Parameters.Add("@RResUser", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RResUser"].Value = recuser;

                    cmd.Parameters.Add("@RResManager", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RResManager"].Value = wholog;

                    cmd.Parameters.Add("@RStatus", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RStatus"].Value = label23.Text;

                    cmd.Parameters.Add("@RView", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RView"].Value = p4;

                    cmd.Parameters.Add("@RSentStatus", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RSentStatus"].Value = p4;

                    cmd.Parameters.Add("@RFinalView", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RFinalView"].Value = p4;

                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand("Update ComposeRequest set CSentManToAdmin='" + p5 + "' where CID='" + label14.Text + "'", con);
                    cmd1.ExecuteNonQuery();

                    DialogResult dlgResult = MessageBox.Show("Responce is Sent To Admin", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (dlgResult == DialogResult.OK)
                    {
                        button1.Enabled = false;
                        panel2.Visible = false;
                        label20.Visible = false;
                        label21.Visible = false;
                        label22.Visible = false;
                        label23.Visible = false;
                        button2.Visible = false;
                        pictureBox2.Visible = false;
                    }
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SPResManagerToAdmin";

                    cmd.Parameters.Add("@ResID", SqlDbType.Int, 0);
                    cmd.Parameters["@ResID"].Value = label14.Text;

                    cmd.Parameters.Add("@RCity", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RCity"].Value = label25.Text;

                    cmd.Parameters.Add("@RReqby", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RReqby"].Value = label39.Text;

                    cmd.Parameters.Add("@RName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RName"].Value = encreq;

                    cmd.Parameters.Add("@RExpLocation", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RExpLocation"].Value = label41.Text;

                    cmd.Parameters.Add("@RCurLocation", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RCurLocation"].Value = encloc;

                    cmd.Parameters.Add("@RDistance", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@RDistance"].Value = label42.Text;

                    cmd.Parameters.Add("@RAddress", SqlDbType.NVarChar, 300);
                    cmd.Parameters["@RAddress"].Value = label43.Text;

                    cmd.Parameters.Add("@RPhone", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@RPhone"].Value = label44.Text;

                    cmd.Parameters.Add("@RResAdmin", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RResAdmin"].Value = label22.Text;

                    cmd.Parameters.Add("@RResUser", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RResUser"].Value = recuser;

                    cmd.Parameters.Add("@RResManager", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RResManager"].Value = wholog;

                    cmd.Parameters.Add("@RStatus", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RStatus"].Value = p2;

                    cmd.Parameters.Add("@RView", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RView"].Value = p4;

                    cmd.Parameters.Add("@RSentStatus", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RSentStatus"].Value = p4;

                    cmd.Parameters.Add("@RFinalView", SqlDbType.VarChar, 50);
                    cmd.Parameters["@RFinalView"].Value = p4;

                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("Update ComposeRequest set CSentManToAdmin='" + p5 + "' where CID='" + label14.Text + "'", con);
                    cmd2.ExecuteNonQuery();

                    DialogResult dlgResult = MessageBox.Show("Responce is Sent To Admin", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (dlgResult == DialogResult.OK)
                    {
                        button1.Enabled = false;
                        panel2.Visible = false;
                        label20.Visible = false;
                        label21.Visible = false;
                        label22.Visible = false;
                        label23.Visible = false;
                        button2.Visible = false;
                        pictureBox2.Visible = false;
                    }
                }
            }
            else
            {
                DialogResult dlgResult1 = MessageBox.Show("This Responce already Sent To Admin", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dlgResult1 == DialogResult.OK)
                {
                    button1.Enabled = false;
                    panel2.Visible = false;
                    label20.Visible = false;
                    label21.Visible = false;
                    label22.Visible = false;
                    label23.Visible = false;
                    button2.Visible = false;
                    pictureBox2.Visible = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter adp1 = new SqlDataAdapter("Select * from ComposeRequest", con);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                SqlCommand cmd1 = new SqlCommand("Update ComposeRequest set CView='" + p3 + "'", con);
                cmd1.ExecuteNonQuery();
            }
            con.Close();
            this.Close();
        }
    }
}
