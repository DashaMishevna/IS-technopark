﻿using System;
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
using IS_technopark.Account;

namespace IS_technopark
{
    public partial class Info : Page
    {
        OracleConnection ORACLE = new OracleConnection(constr);
        static string constr = "User Id=Technopark; Password=DIP1937;Data Source=127.0.0.1:1521/xe";
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataTable table = new DataTable();
        string id_l = "";
        List<string> id_l_list = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            int a = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                oraConnection.Open();
                CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
                if (cb != null && cb.Checked)
                {
                    oraAdap.SelectCommand = new OracleCommand();
                    oraAdap.SelectCommand.CommandText = "Select * FROM TECHNOPARK.LEARNER where TECHNOPARK.LEARNER.ID_LEARNER = '" + GridView1.DataKeys[a].Values[0] + "'";
                    oraAdap.SelectCommand.Connection = oraConnection;
                    OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
                    while (oraReader.Read())
                    {
                        object[] values = new object[oraReader.FieldCount];
                        oraReader.GetValues(values);
                        id_l_list.Add(values[0].ToString());
                    }
                }
                a += 1;
                // Response.Write(cb + "<b>tut</b><br/>");
                oraConnection.Close();
            }
          
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
            if (Class_FIO.Employees_position == "1")
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
            else
            {
                Response.Write("<script>alert('Только методист может редактировать данные!')</script>");
                //Response.Write(@"<script language='javascript'>alert('This is my Message')</script>");
                //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "SCRIPT", string.Format("alert('Hello World')"), true);
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

        public void GetId_l()
        {
            oraConnection.Open();
            if (id_l_list.Count == 1)
            {
                //oraAdap.SelectCommand = new OracleCommand();
                //oraAdap.SelectCommand.CommandText = "SELECT * FROM TECHNOPARK.LEARNER WHERE (FIO ='" + id_l_list[0] + "') and ID_LEARNER!=0";
                //oraAdap.SelectCommand.Connection = oraConnection;
                //OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
                //while (oraReader.Read())
                //{
                //    object[] values = new object[oraReader.FieldCount];
                //    oraReader.GetValues(values);
                //    id_l = values[0].ToString();
                //}

                SqlDataSource1.SelectCommand = "SELECT ID_PARENT, ID_LEARNER_P, FIO, PHONE, PHONE_WORK, E_MAIL, PLACE_WORK, POSITION FROM TECHNOPARK.PARENT WHERE PARENT.ID_LEARNER_P = '" + id_l_list[0] + "' and ID_PARENT!=0 and ID_LEARNER_P!=0";
                SqlDataSource1.DataBind();
                GridView2.DataBind();
                Label3.Text = "Данные родителя";
            }

            else
            {
                SqlDataSource1.SelectCommand = "SELECT ID_PARENT, ID_LEARNER_P, FIO, PHONE, PHONE_WORK, E_MAIL, PLACE_WORK, POSITION FROM TECHNOPARK.PARENT WHERE PARENT.ID_LEARNER_P = 0 and ID_PARENT!=0 and ID_LEARNER_P!=0";
                SqlDataSource1.DataBind();
                GridView2.DataBind();
                Label3.Text = "";
                //Label3.Visible=false;
            }
            oraConnection.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            oraConnection.Open();
            if (TextBox1.Text != "")
            {
                string command = Technopark.SelectCommand;
                Technopark.SelectCommand = "SELECT * FROM TECHNOPARK.LEARNER WHERE (FIO LIKE '%" + TextBox1.Text + "%') and ID_LEARNER!=0";
                Technopark.DataBind();
                GridView1.DataBind();
            }

            else
            {
                string command = Technopark.SelectCommand;
                Technopark.SelectCommand = "SELECT * FROM TECHNOPARK.LEARNER";
                Technopark.DataBind();
                GridView1.DataBind();
            }
            oraConnection.Close();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Class_FIO.Employees_position == "1")
            {
                try
                {
                  using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                  {
                        oraclelcon.Open();
                        GridViewRow row = GridView1.Rows[e.RowIndex];
                        string query = "DELETE FROM TECHNOPARK.LEARNER WHERE ID_LEARNER = :ID_LEARNER";
                        OracleCommand oraclecmd = new OracleCommand(query, oraConnection);
                        oraclecmd.Connection.Open();
                        oraclecmd.Parameters.Add("ID_LEARNER", GridView1.DataKeys[e.RowIndex].Value);

                        oraclecmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Response.Write("<script>alert('Ошибка')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Только методист может удалять данные!')</script>");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (Class_FIO.Employees_position == "1")
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
            else
            {
                Response.Write("<script>alter('Ошибка');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GetId_l();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            oraConnection.Open();
            string command = Technopark.SelectCommand;
            Technopark.SelectCommand = "SELECT * FROM TECHNOPARK.LEARNER order by FIO";
            Technopark.DataBind();
            GridView1.DataBind();
            oraConnection.Close();
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           try
            {
                //GridView2.EditIndex = -1;
                GridViewRow row = GridView2.Rows[e.RowIndex];
                //string query = "UPDATE TECHNOPARK.PARENT SET  PHONE=:PHONE WHERE ID_PARENT=:ID_PARENT";
                string query = "UPDATE TECHNOPARK.PARENT SET FIO=:FIO, PHONE=:PHONE, PHONE_WORK=:PHONE_WORK, E_MAIL=:E_MAIL, PLACE_WORK=:PLACE_WORK, POSITION=:POSITION WHERE ID_PARENT=:ID_PARENT";
                //oraConnection.Open();
                OracleCommand oraclecmd = new OracleCommand(query, oraConnection);
                oraclecmd.Connection.Open();
                oraclecmd.Parameters.Add("FIO", e.NewValues["FIO"]);
                oraclecmd.Parameters.Add("PHONE", e.NewValues["PHONE"]);
                oraclecmd.Parameters.Add("PHONE_WORK", e.NewValues["PHONE_WORK"]);
                oraclecmd.Parameters.Add("E_MAIL", e.NewValues["E_MAIL"]);
                oraclecmd.Parameters.Add("PLACE_WORK", e.NewValues["PLACE_WORK"]);
                oraclecmd.Parameters.Add("POSITION", e.NewValues["POSITION"]);
                oraclecmd.Parameters.Add("ID_PARENT", GridView2.DataKeys[e.RowIndex].Value);
                oraclecmd.ExecuteNonQuery();
                GridView2.EditIndex = -1;
                oraConnection.Close();
            }
            catch
            {
                Response.Write("<script>alert('Проверьте введенные данные!')</script>");
            }
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
           // GridView2.EditIndex = e.NewEditIndex;
            
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridView2.EditIndex = -1;
                GridView2.DataBind();
            if (this.IsPostBack)
            {
                string command2 = SqlDataSource1.SelectCommand;
                SqlDataSource1.SelectCommand = "SELECT ID_PARENT, ID_LEARNER_P, FIO, PHONE, PHONE_WORK, E_MAIL, PLACE_WORK, POSITION FROM TECHNOPARK.PARENT WHERE PARENT.ID_LEARNER_P = '" + id_l_list[0] + "' and ID_PARENT!=0 and ID_LEARNER_P!=0";
                SqlDataSource1.DataBind();
                GridView2.DataBind();
            }
            }
            catch
            {
                Response.Write("<script>alert('Выберите клиента!')</script>");
            }
        }
    }
}