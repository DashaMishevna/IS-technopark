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
        OracleConnection ORACLE = new OracleConnection(constr);
        static string constr = "User Id=Technopark; Password=DIP1937;Data Source=127.0.0.1:1521/xe";
        OracleDataAdapter oraAdap = new OracleDataAdapter();
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
                string query = "UPDATE TECHNOPARK.LEARNER SET FIO=:FIO, CLASS=:CLASS, BIRTHDAY=:BIRTHDAY, SCHOOL=:SCHOOL, PHONE=:PHONE, SHIFT=:SHIFT, E_MAIL=:E_MAIL, INTERESTS=:INTERESTS, COMMENTS=:COMMENTS WHERE ID_LEARNER=:ID_LEARNER";
                OracleCommand oraclecmd = new OracleCommand(query, oraConnection);
                oraclelcon.Open();
                //oraclecmd.CommandText = "UPDATE TECHNOPARK.LEARNER SET FIO=@FIO; SHIFT=@SHIFT";
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
                oraclecmd.Parameters.Add("ID_LEARNER", e.NewValues["ID_LEARNER"]);

                oraclecmd.ExecuteNonQuery();
                GridView1.EditIndex = -1;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {
                using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                {

                    //GridViewRow row = GridView1.Rows[e.RowIndex];
                    string query = "INSERT INTO TECHNOPARK.LEARNER (FIO, CLASS, BIRTHDAY, SCHOOL, PHONE, SHIFT, E_MAIL, INTERESTS, COMMENTS) VALUES (:FIO, :BIRTHDAY, :SCHOOL, :PHONE, :SHIFT, :E_MAIL, :INTERESTS, :COMMENTS)";
                    OracleCommand oraclecmd = new OracleCommand(query, oraConnection);
                    oraclelcon.Open();
                    oraclecmd.Connection.Open();
                    oraclecmd.Parameters.Add("FIO", TextBox1.Text);
                    oraclecmd.Parameters.Add("CLASS", TextBox1.Text);
                    oraclecmd.Parameters.Add("BIRTHDAY", Convert.ToDateTime(TextBox2.Text));
                    oraclecmd.Parameters.Add("SCHOOL", TextBoxFirst.Text);
                    oraclecmd.Parameters.Add("PHONE", "PHONE");
                    oraclecmd.Parameters.Add("SHIFT", TextBox1.Text);
                    oraclecmd.Parameters.Add("E_MAIL", "E_MAIL");
                    oraclecmd.Parameters.Add("INTERESTS", "INTERESTS");
                    oraclecmd.Parameters.Add("COMMENTS", "COMMENTS");
                    //oraclecmd.Parameters.Add("ID_LEARNER", "ID_LEARNER");
                    oraclecmd.ExecuteNonQuery();
                    GridView1.EditIndex = -1;

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                {
                    ORACLE.Open();
                    string query = "INSERT INTO TECHNOPARK.LEARNER (FIO, CLASS, BIRTHDAY, SCHOOL, PHONE, SHIFT, E_MAIL, INTERESTS, COMMENTS)  VALUES('" + TextBoxFirst.Text + "', '" + TextBox1.Text + "', '" + DateTime.Parse(TextBox2.Text).ToShortDateString() + "', '" + TextBox1.Text + "', '" + TextBox1.Text + "', '" + TextBox1.Text + "', '" + TextBoxFirst.Text + "', '" + TextBoxFirst.Text + "', '" + TextBoxFirst.Text + "')";
                    oraAdap.InsertCommand = new OracleCommand(query, ORACLE);
                    oraAdap.InsertCommand.ExecuteNonQuery();
                    GridView1.DataBind();
                    //oraclecmd.Parameters.Add("FIO", TextBox1.Text);
                    //oraclecmd.Parameters.Add("CLASS", TextBox1.Text);
                    //oraclecmd.Parameters.Add("BIRTHDAY", Convert.ToDateTime(TextBox2.Text));
                    //oraclecmd.Parameters.Add("SCHOOL", TextBoxFirst.Text);
                    //oraclecmd.Parameters.Add("PHONE", TextBox1.Text);
                    //oraclecmd.Parameters.Add("SHIFT", TextBox1.Text);
                    //oraclecmd.Parameters.Add("E_MAIL", TextBox1.Text);
                    //oraclecmd.Parameters.Add("INTERESTS", TextBox1.Text);
                    //oraclecmd.Parameters.Add("COMMENTS", TextBox1.Text);
                    //oraclecmd.Parameters.Add("ID_LEARNER", "ID_LEARNER");
                    //oraclecmd.ExecuteNonQuery();
                    //GridView1.EditIndex = -1;
                }
            }
            catch
            {
               // Label1.Visible = true;
                //Label1.Text = "Проверьте введенные данные!";
            }
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
                    oraclecmd.Parameters.Add("ID_LEARNER", "ID_LEARNER");
                    oraclecmd.ExecuteNonQuery();
                    //GridView1.EditIndex = -1;

                }
            }
            catch
            {

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