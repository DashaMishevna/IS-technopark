using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IS_technopark
{
    public partial class HomePage : Page
    {
        //OracleConnection ORACLE = new OracleConnection(constr);
        //static string constr = "User Id=Technopark; Password=DIP1937;Data Source=127.0.0.1:1521/xe";
        //OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        //string sqlconnection = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = 127.0.0.1)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = xe)));User ID=TECHNOPARK;Password=DIP1937;";

        protected void Page_Load(object sender, EventArgs e)
        {
            //oraConnection.Open();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = e.RowIndex;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
            {
                //oraclelcon.Open();
                GridViewRow row = GridView1.Rows[e.RowIndex];
                string query = "UPDATE TECHNOPARK.LEARNER SET FIO=@FIO, CLASS=@CLASS, BIRTHDAY=@BIRTHDAY, SCHOOL=@SCHOOL, PHONE=@PHONE, SHIFT=@SHIFT, E_MAIL=@E_MAIL, INTERESTS=@INTERESTS, COMMENTS=@COMMENTS WHERE ID_LEARNER=@ID_LEARNER";
                OracleCommand oraclecmd = new OracleCommand(query, oraConnection);
                oraclelcon.Open();
                //oraclecmd.CommandText = "UPDATE TECHNOPARK.LEARNER SET FIO=@FIO; SHIFT=@SHIFT";
                oraclecmd.Connection.Open();
                //oraclecmd.Parameters.Add("@FIO");
                //sqlcmd.Parameters.Add("@FIO", (GridView1.Rows[e.RowIndex].FindControl("FIO")));
                //    sqlcmd.Parameters.Add("@CLASS", (GridView1.Rows[e.RowIndex].FindControl("CLASS")));
                //    sqlcmd.Parameters.Add("@BIRTHDAY", (GridView1.Rows[e.RowIndex].FindControl("BIRTHDAY")));
                //    sqlcmd.Parameters.Add("@SCHOOL", (GridView1.Rows[e.RowIndex].FindControl("SCHOOL")));
                //    sqlcmd.Parameters.Add("@PHONE", (GridView1.Rows[e.RowIndex].FindControl("PHONE")));
                //    sqlcmd.Parameters.Add("@SHIFT", (GridView1.Rows[e.RowIndex].FindControl("SHIFT")));
                //    sqlcmd.Parameters.Add("@E_MAIL", (GridView1.Rows[e.RowIndex].FindControl("E_MAIL")));
                //    sqlcmd.Parameters.Add("@INTERESTS", (GridView1.Rows[e.RowIndex].FindControl("INTERESTS")));
                //    sqlcmd.Parameters.Add("@COMMENTS", (GridView1.Rows[e.RowIndex].FindControl("COMMENTS")));
                oraclecmd.ExecuteNonQuery();
                GridView1.EditIndex = -1;


            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    ORACLE.Open();
        //    oraAdap.SelectCommand = new OracleCommand();
        //    oraAdap.SelectCommand.CommandText = "Select KEY from EMPLOYEES ";
        //    oraAdap.SelectCommand.Connection = ORACLE;
        //    OracleDataReader oraReader1 = oraAdap.SelectCommand.ExecuteReader();
        //    while (oraReader1.Read())
        //    {
        //        object[] values = new object[oraReader1.FieldCount];
        //        oraReader1.GetValues(values);
        //        ListBox1.Items.Add(values[0].ToString());
        //    }
        //}

    }
}