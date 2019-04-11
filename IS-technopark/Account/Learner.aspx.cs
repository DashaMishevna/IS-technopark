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
    public partial class Learner : System.Web.UI.Page
    {
        //OracleConnection ORACLE = new OracleConnection(constr);
        //static string constr = "User Id=Technopark; Password=DIP1937;Data Source=127.0.0.1:1521/xe";
        //OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection ("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataTable table = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            oraConnection.Open();
            string s = "SELECT FIO as ФИО, BIRTHDAY as Дата_рождения, CLASS as Класс, SCHOOL as Школа, SHIFT as Смена, PHONE as Телефон, E_MAIL, INTERESTS as Интресы , COMMENTS as Комментарии FROM TECHNOPARK.LEARNER WHERE FIO LIKE '%" + TextBox1.Text + "%' ";
                OracleDataAdapter adapter = new OracleDataAdapter(s, oraConnection);
                //OracleDataReader oraReader = adapter.SelectCommand.ExecuteReader();
                adapter.Fill(table);
                GridView2.DataSource = table;
                GridView2.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {


            string s = "SELECT FIO as ФИО, BIRTHDAY as Дата_рождения, CLASS as Класс, SCHOOL as Школа, SHIFT as Смена, PHONE as Телефон, E_MAIL, INTERESTS as Интресы , COMMENTS as Комментарии FROM TECHNOPARK.LEARNER WHERE INTERESTS LIKE '%" + TextBox2.Text + "%' ";
            OracleDataAdapter adapter = new OracleDataAdapter(s, oraConnection);
            //OracleDataReader oraReader = adapter.SelectCommand.ExecuteReader();
            adapter.Fill(table);
            GridView2.DataSource = table;
            GridView2.DataBind();
            //oraConnection.Open();
            //DataTable table = new DataTable();
            ////if (Class_FIO.Teachr_fio != null)
            ////{ 
            ////string s = "SELECT FIO as ФИО, BIRTHDAY as Дата_рождения, CLASS as Класс, SCHOOL as Школа, SHIFT as Смена, PHONE as Телефон, E_MAIL, INTERESTS as Интресы , COMMENTS as Комментарии FROM TECHNOPARK.LEARNER";
            //string s = "Select * from QWE";
            //OracleDataAdapter adapter = new OracleDataAdapter(s, oraConnection);
            ////OracleDataReader oraReader = adapter.SelectCommand.ExecuteReader();
            //adapter.Fill(table);
            //GridView2.DataSource = table;
            //GridView2.DataBind();
            ////}
            //oraConnection.Close();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if(e.CommandName.Equals("Add"))
            //{
            //    using (OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
            //    {
            //        oraConnection.Open();
            //        string query = "INSERT INTO TECHNOPARK.QWE (ID_LEARNER, FIO, CLASS) VALUES (@ID_LEARNER, @FIO, @CLASS)";
            //        OracleDataAdapter adapter = new OracleDataAdapter(query, oraConnection);
            //        GridViewRow footer = GridView2.FooterRow;
                   

            //    }
            //}
        }
    }
}