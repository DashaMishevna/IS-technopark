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
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            oraConnection.Open();
            DataTable table = new DataTable();
            //if (Class_FIO.Teachr_fio != null)
            //{ 
                string s = "SELECT FIO as ФИО, BIRTHDAY as Дата_рождения, CLASS as Класс, SCHOOL as Школа, SHIFT as Смена, PHONE as Телефон, E_MAIL, INTERESTS as Интресы , COMMENTS as Комментарии FROM TECHNOPARK.LEARNER WHERE FIO = '" + TextBox1.Text + "' ";
                OracleDataAdapter adapter = new OracleDataAdapter(s, oraConnection);
                //OracleDataReader oraReader = adapter.SelectCommand.ExecuteReader();
                adapter.Fill(table);
                GridView2.DataSource = table;
                GridView2.DataBind();
            //}
        }
    }
}