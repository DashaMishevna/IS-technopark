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
        string sqlconnection = "Data Source=127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;";

        protected void Page_Load(object sender, EventArgs e)
        {
            oraConnection.Open();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = e.RowIndex;

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(sqlconnection))
            {
                    sqlcon.Open();
                    string query = "UPDATE TECHNOPARK.LEARNER SET FIO=@FIO, CLASS=@CLASS, BIRTHDAY=@BIRTHDAY, SCHOOL=@SCHOOL, PHONE=@PHONE, SHIFT=@SHIFT, E_MAIL=@E_MAIL, INTERESTS=@INTERESTS, COMMENTS=@COMMENTS WHERE ID_LEARNER=@ID_LEARNER";
                    SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                    sqlcmd.Parameters.AddWithValue("@FIO", (GridView1.Rows[e.RowIndex].FindControl("FIO")));
                    sqlcmd.Parameters.AddWithValue("@CLASS", (GridView1.Rows[e.RowIndex].FindControl("CLASS")));
                    sqlcmd.Parameters.AddWithValue("@BIRTHDAY", (GridView1.Rows[e.RowIndex].FindControl("BIRTHDAY")));
                    sqlcmd.Parameters.AddWithValue("@SCHOOL", (GridView1.Rows[e.RowIndex].FindControl("SCHOOL")));
                    sqlcmd.Parameters.AddWithValue("@PHONE", (GridView1.Rows[e.RowIndex].FindControl("PHONE")));
                    sqlcmd.Parameters.AddWithValue("@SHIFT", (GridView1.Rows[e.RowIndex].FindControl("SHIFT")));
                    sqlcmd.Parameters.AddWithValue("@E_MAIL", (GridView1.Rows[e.RowIndex].FindControl("E_MAIL")));
                    sqlcmd.Parameters.AddWithValue("@INTERESTS", (GridView1.Rows[e.RowIndex].FindControl("INTERESTS")));
                    sqlcmd.Parameters.AddWithValue("@COMMENTS", (GridView1.Rows[e.RowIndex].FindControl("COMMENTS")));
                    sqlcmd.ExecuteNonQuery();
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