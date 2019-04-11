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
        OracleConnection ORACLE = new OracleConnection(constr);
        static string constr = "User Id=Technopark; Password=DIP1937;Data Source=127.0.0.1:1521/xe";
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataTable table = new DataTable();
        //string sqlconnection = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = 127.0.0.1)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = xe)));User ID=TECHNOPARK;Password=DIP1937;";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataBind();
            if (this.IsPostBack)
            {
                string command = Technopark.SelectCommand;
                Technopark.SelectCommand = "SELECT * FROM TECHNOPARK.LEARNER WHERE (FIO LIKE '%" + TextBox1.Text + "%') and ID_LEARNER!=0";
                Technopark.DataBind();
                GridView1.DataBind();
            }

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (this.IsPostBack)
            {
                string command = Technopark.SelectCommand;
                Technopark.SelectCommand = "SELECT * FROM TECHNOPARK.LEARNER WHERE (FIO LIKE '%" + TextBox1.Text + "%') and ID_LEARNER!=0";
                Technopark.DataBind();
                GridView1.DataBind();
            }
            try
            {
                using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                {
                    GridViewRow row = GridView1.Rows[e.RowIndex];
                    string query = "UPDATE TECHNOPARK.LEARNER SET FIO=:FIO, CLASS=:CLASS, BIRTHDAY=:BIRTHDAY, SCHOOL=:SCHOOL, PHONE=:PHONE, SHIFT=:SHIFT, E_MAIL=:E_MAIL, INTERESTS=:INTERESTS, COMMENTS=:COMMENTS WHERE ID_LEARNER=:ID_LEARNER";
                    OracleCommand oraclecmd = new OracleCommand(query, oraConnection);
                    oraclelcon.Open();
                    oraclecmd.Connection.Open();
                    oraclecmd.Parameters.Add("FIO", e.NewValues["FIO"]);
                    oraclecmd.Parameters.Add("CLASS", e.NewValues["CLASS"]);
                    oraclecmd.Parameters.Add("BIRTHDAY", Convert.ToDateTime(e.NewValues["BIRTHDAY"]));
                    oraclecmd.Parameters.Add("SCHOOL", e.NewValues["SCHOOL"]);
                    oraclecmd.Parameters.Add("PHONE", e.NewValues["PHONE"]);
                    oraclecmd.Parameters.Add("SHIFT", e.NewValues["SHIFT"]);
                    oraclecmd.Parameters.Add("E_MAIL", e.NewValues["E_MAIL"]);
                    oraclecmd.Parameters.Add("INTERESTS", e.NewValues["INTERESTS"]);
                    oraclecmd.Parameters.Add("COMMENTS", e.NewValues["COMMENTS"]);
                    oraclecmd.Parameters.Add("ID_LEARNER", GridView1.DataKeys[e.RowIndex].Value);

                    oraclecmd.ExecuteNonQuery();
                    GridView1.EditIndex = -1;
                }
            }
            catch
            {
                Label1.Visible = true;
                Label1.Text = "Проверьте введенные данные!";
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (this.IsPostBack)
            {
                string command = Technopark.SelectCommand;
                Technopark.SelectCommand = "SELECT * FROM TECHNOPARK.LEARNER WHERE (FIO LIKE '%" + TextBox1.Text + "%') and ID_LEARNER!=0";
                Technopark.DataBind();
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            oraConnection.Open();
            if (this.IsPostBack)
            {
                string command = Technopark.SelectCommand;
                Technopark.SelectCommand = "SELECT * FROM TECHNOPARK.LEARNER WHERE (FIO LIKE '%" + TextBox1.Text + "%') and ID_LEARNER!=0";
                Technopark.DataBind();
                GridView1.DataBind();
            }
            oraConnection.Close();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                {

                    //GridViewRow row = GridView1.Rows[e.RowIndex];
                    string query = "DELETE FROM TECHNOPARK.LEARNER WHERE ID_LEARNER = :ID_LEARNER";
                    OracleCommand oraclecmd = new OracleCommand(query, oraConnection);
                    oraclelcon.Open();
                    oraclecmd.Connection.Open();
                    oraclecmd.ExecuteNonQuery();

                }
            }
            catch
            {

            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (this.IsPostBack)
            {
                string command = Technopark.SelectCommand;
                Technopark.SelectCommand = "SELECT * FROM TECHNOPARK.LEARNER WHERE (FIO LIKE '%" + TextBox1.Text + "%') and ID_LEARNER!=0";
                Technopark.DataBind();
                GridView1.DataBind();
            }
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();
        }

    }
}