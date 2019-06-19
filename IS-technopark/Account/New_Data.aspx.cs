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

        protected void Page_Load(object sender, EventArgs e)
        {
            Class_FIO.Director = "Петров Петр Петрович";
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

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Class_FIO.Director = TextBox1.Text;
            Label3.Text = Class_FIO.Director;
            TextBox1.Text = String.Empty;
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
            string s1 = "Select DIR_POSITION from DIR_POSITION";
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

        protected void Button1_Click1(object sender, EventArgs e)
        {
            oraConnection.Open();
            Get_ID_Position();

            if (TextBox2.Text != "" && DropDownList_Position.SelectedValue.ToString() != "-Выберите должность-")
            {
                //
                //string query = "INSERT INTO TECHNOPARK.EMPLOYEES (POSITION, FIO) VALUES(id_position, '" + TextBox2.Text + "')";
                //oraAdap.InsertCommand = new OracleCommand(query, oraConnection);
                //oraAdap.InsertCommand.ExecuteNonQuery();
                //oraConnection.Close();
                //Response.Write("<script>alert('Данные успешно добавлены!')</script>");
                Response.Write("<script>alert('Ваш пароль: " + id_position + "')</script>");
            }
            else
            {
                Response.Write("<script>alert('Проверьте введенные данные!')</script>");

            }
        }

    }
}