using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IS_technopark.Account
{
    public partial class New_Data : System.Web.UI.Page
    {
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataSet ds = new DataSet();
        DataSet ds_position = new DataSet();
        string id_position = "";
        string s_key = "";
        string id_lab = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Class_FIO.Director = "Петров Петр Петрович";
            Label3.Text = Class_FIO.Director;
            if (!IsPostBack)
            {
                GetDropList();
            }
            if (!IsPostBack)
            {
                GetPosition();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Class_FIO.Employees_position == "1")
            {
                oraConnection.Open();
                try
                {
                    string query_update_q = "Update TECHNOPARK.EMPLOYEES SET FIO = '" + TextBox1.Text + "' WHERE POSITION = 3";
                    oraAdap.UpdateCommand = new OracleCommand(query_update_q, oraConnection);
                    oraAdap.UpdateCommand.ExecuteNonQuery();
                    Label3.DataBind();
                }
                catch
                {

                }

                //Class_FIO.Director = TextBox1.Text;
                //Label3.Text = Class_FIO.Director;
                TextBox1.Text = String.Empty;
                oraAdap.SelectCommand = new OracleCommand();

                oraAdap.SelectCommand = new OracleCommand();
                oraAdap.SelectCommand.CommandText = "Select FIO From EMPLOYEES where POSITION=3";
                oraAdap.SelectCommand.Connection = oraConnection;
                OracleDataReader oraReader1 = oraAdap.SelectCommand.ExecuteReader();
                while (oraReader1.Read())
                {
                    object[] values = new object[oraReader1.FieldCount];
                    oraReader1.GetValues(values);
                    Class_FIO.Director = values[0].ToString();
                }

                oraAdap.SelectCommand.CommandText = "with t as (select FIO as name from EMPLOYEES where POSITION=3) select regexp_replace(t.name, ' (.*)') LASTNAME, regexp_replace(regexp_replace(t.name, ' (.*)|^[^ ]* '),'.*','.',2,1)||regexp_replace(regexp_replace(t.name, '(.*) '),'.*','.',2,1) INITIALS from t";
                oraAdap.SelectCommand.Connection = oraConnection;
                OracleDataReader oraReader2 = oraAdap.SelectCommand.ExecuteReader();
                while (oraReader2.Read())
                {
                    object[] values = new object[oraReader2.FieldCount];
                    oraReader2.GetValues(values);
                    Class_FIO.DirectorDD = values[0].ToString();
                    Class_FIO.DirectorDD = Class_FIO.DirectorDD + " " + values[1].ToString();
                }
                Label3.Text = Class_FIO.Director;
            }
            else
            {
                Response.Write("<script>alert('Только методист может менять ФИО директора!')</script>");
            }
        }

        private void GetDropList()
        {
            string s1 = "Select Laboratory from DIR_LABORATORIES";
            OracleDataAdapter oraAdap = new OracleDataAdapter(s1, oraConnection);
            oraAdap.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "Laboratory";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("-Выберите направление-"));
                DropDownList1.SelectedIndex = 0;
            }
        }

        private void GetPosition()
        {
            string s1 = "Select DIR_POSITION from DIR_POSITION Where ID_DIR_POSITION <>3";
            OracleDataAdapter oraAdap = new OracleDataAdapter(s1, oraConnection);
            oraAdap.Fill(ds_position);
            if (ds_position.Tables[0].Rows.Count > 0)
            {
                DropDownList_Position.DataSource = ds_position;
                DropDownList_Position.DataTextField = "DIR_POSITION";
                DropDownList_Position.DataBind();
                DropDownList_Position.Items.Insert(0, new ListItem("-Выберите должность-"));
                DropDownList_Position.SelectedIndex = 0;
            }
        }

        public void Get_ID_Position()
        {
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "Select ID_DIR_POSITION from DIR_POSITION where DIR_POSITION = '" + DropDownList_Position.SelectedValue + "'";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                id_position = values[0].ToString();
            }
        }

        public void Select_Key()
        {
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "select key from(select  max(ID_EMPLOYEES) as m from EMPLOYEES)b, EMPLOYEES where EMPLOYEES.ID_EMPLOYEES=b.m";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                s_key = values[0].ToString();
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (Class_FIO.Employees_position == "1")
            {
                oraConnection.Open();
                Get_ID_Position();

                if (TextBox2.Text != "" && DropDownList_Position.SelectedValue.ToString() != "-Выберите должность-")
                {
                    string query = "INSERT INTO TECHNOPARK.EMPLOYEES (POSITION, FIO) VALUES('" + id_position + "', '" + TextBox2.Text + "')";
                    oraAdap.InsertCommand = new OracleCommand(query, oraConnection);
                    oraAdap.InsertCommand.ExecuteNonQuery();
                    Select_Key();
                    Response.Write("<script>alert('Данные успешно добавлены! Ваш пароль: " + s_key + "')</script>");
                    GridView1.DataBind();
                    TextBox2.Text = string.Empty;
                    DropDownList_Position.ClearSelection();
                    //DropDownList1.SelectedIndex = -1;
                    DropDownList_Position.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Проверьте введенные данные!')</script>");
                }
            }
            else
            {
                TextBox2.Text = string.Empty;
                DropDownList_Position.ClearSelection();
                Response.Write("<script>alert('Только методист может добавлять нового сотрудника!')</script>");
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //try
            //{
                GridViewRow row = GridView1.Rows[e.RowIndex];
                string query = "UPDATE TECHNOPARK.EMPLOYEES SET FIO=:FIO WHERE ID_EMPLOYEES=:ID_EMPLOYEES";
                OracleCommand oraclecmd = new OracleCommand(query, oraConnection);
                oraConnection.Open();
                oraclecmd.Parameters.Add("FIO", e.NewValues["FIO"]);
                //oraclecmd.Parameters.Add("DIR_POSITION", e.NewValues["DIR_POSITION"]);
                oraclecmd.Parameters.Add("ID_EMPLOYEES", GridView1.DataKeys[e.RowIndex].Value);
                oraclecmd.ExecuteNonQuery();
                GridView1.EditIndex = -1;
                oraConnection.Close();
            //}
            //catch
            //{
            //    Response.Write("<script>alert('Проверьте введенные данные!')</script>");
            //}
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Class_FIO.Employees_position == "1")
            {
                if (TextBox3.Text != "")
                {
                    oraConnection.Open();
                    string query = "INSERT INTO TECHNOPARK.DIR_LABORATORIES (LABORATORY) VALUES('" + TextBox3.Text + "')";
                    oraAdap.InsertCommand = new OracleCommand(query, oraConnection);
                    oraAdap.InsertCommand.ExecuteNonQuery();
                   // GetDropList();
                    Response.Write("<script>alert('Данные успешно добавлены!')</script>");
                    TextBox3.Text = string.Empty;
                    GetDropList();
                    oraConnection.Close();
                }
                else
                {
                    Response.Write("<script>alert('Проверьте введенные данные!')</script>");
                }
            }
            else
            {
                TextBox3.Text = string.Empty;
                Response.Write("<script>alert('Только методист может добавлять направление!')</script>");
            }
        }

        public void Get_ID_Lab()
        {
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "Select ID_LABORATORIES from DIR_LABORATORIES where LABORATORY = '" + DropDownList1.SelectedValue + "'";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                id_lab = values[0].ToString();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Class_FIO.Employees_position == "1")
            {
                if (TextBox4.Text != "" && DropDownList1.SelectedValue.ToString() != "-Выберите направление-")
                {
                    oraConnection.Open();
                    Get_ID_Lab();
                    string query = "INSERT INTO TECHNOPARK.DIR_PROJECTS (ID_LABORATORY, TITLE) VALUES('" + id_lab + "', '" + TextBox4.Text + "')";
                    oraAdap.InsertCommand = new OracleCommand(query, oraConnection);
                    oraAdap.InsertCommand.ExecuteNonQuery();
                    Response.Write("<script>alert('Данные успешно добавлены!')</script>");
                    TextBox4.Text = string.Empty;
                    DropDownList1.ClearSelection();
                    oraConnection.Close();
                }
                else
                {
                    Response.Write("<script>alert('Проверьте введенные данные!')</script>");
                }
            }
            else
            {
                TextBox4.Text = string.Empty;
                DropDownList1.ClearSelection();
                Response.Write("<script>alert('Только методист может добавлять проект!')</script>");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (Class_FIO.Employees_position == "1")
            {

            }

            else
            {
                Response.Write("<script>alert('Только методист может изменять пароль!')</script>");
            }
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
                        string query = "DELETE FROM TECHNOPARK.EMPLOYEES WHERE ID_EMPLOYEES = :ID_EMPLOYEES";
                        OracleCommand oraclecmd = new OracleCommand(query, oraConnection);
                        oraclecmd.Connection.Open();
                        oraclecmd.Parameters.Add("ID_EMPLOYEES", GridView1.DataKeys[e.RowIndex].Value);

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
    }
}