using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace AnonumousProject
{
    class Class1
    {
        string constring = Convert.ToString(ConfigurationSettings.AppSettings["ConnectionString"]);
        string id,id1,id2,id3,id4;
        int eid,eid1,eid2,eid3,eid4;

        public int idgeneration()
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand c1;
            c1 = new SqlCommand("select max(ID) from Registration", con);
            id = Convert.ToString(c1.ExecuteScalar());
            if (id == "")
            {
                eid = 1;
            }
            else
            {
                eid = Convert.ToInt16(id);
                eid = eid + 1;
            }
            con.Close();
            return eid;
        }

        public int idondistance()
        {
            SqlConnection con1 = new SqlConnection(constring);
            con1.Open();
            SqlCommand c1;
            c1 = new SqlCommand("select max(DID) from Distance", con1);
            id1 = Convert.ToString(c1.ExecuteScalar());
            if (id1 == "")
            {
                eid1 = 1;
            }
            else
            {
                eid1 = Convert.ToInt16(id1);
                eid1 = eid1 + 1;
            }
            con1.Close();
            return eid1;
        }

        public int postdetails()
        {
            SqlConnection con2 = new SqlConnection(constring);
            con2.Open();
            SqlCommand c2;
            c2 = new SqlCommand("select max(PID) from postdetails", con2);
            id2 = Convert.ToString(c2.ExecuteScalar());
            if (id2 == "")
            {
                eid2 = 1;
            }
            else
            {
                eid2 = Convert.ToInt16(id2);
                eid2 = eid2 + 1;
            }
            con2.Close();
            return eid2;
        }

        public int composedetails()
        {
            SqlConnection con3 = new SqlConnection(constring);
            con3.Open();
            SqlCommand c3;
            c3 = new SqlCommand("select max(CID) from ComposeRequest", con3);
            id3 = Convert.ToString(c3.ExecuteScalar());
            if (id3 == "")
            {
                eid3 = 1;
            }
            else
            {
                eid3 = Convert.ToInt16(id3);
                eid3 = eid3 + 1;
            }
            con3.Close();
            return eid3;
        }

        public int AdminRecivedRequest()
        {
            SqlConnection con4 = new SqlConnection(constring);
            con4.Open();
            SqlCommand c4;
            c4 = new SqlCommand("select max(RID) from AdminRecivedRequest", con4);
            id4 = Convert.ToString(c4.ExecuteScalar());
            if (id4 == "")
            {
                eid4 = 1;
            }
            else
            {
                eid4 = Convert.ToInt16(id4);
                eid4 = eid4 + 1;
            }
            con4.Close();
            return eid4;
        }
    }
}
