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
            //oraConnection = new OracleConnection ("Data Source = XXX; Password = XXXX; User ID = XXXX;");
            DataTable table = new DataTable();
            string s = "SELECT FIO, CLASS, BIRTHDAY, SCHOOL as Школа, PHONE FROM TECHNOPARK.LEARNER";
            OracleDataAdapter adapter = new OracleDataAdapter(s, oraConnection);
            //OracleDataReader oraReader = adapter.SelectCommand.ExecuteReader();
            adapter.Fill(table);
            //cmb.ValueMember = "ID";
            //cmb.DisplayMember = "Name";
            GridView2.DataSource = table;
            GridView2.DataBind();
            //while (oraReader.Read())
            //{
            //    GridView2.Rows.Add(oraReader[“Name”], oraReader[“Otdel”]);
            //    GridView2.Rows.Add(oraReader.GetValue(0), oraReader.GetValue(1));
            //}
            //ORACLE.Open();
            //oraAdap.SelectCommand = new OracleCommand();
            //oraAdap.SelectCommand.Connection = ORACLE;

            //DataTable data = new DataTable();
            //oraAdap.SelectCommand.CommandText.Fill(data);
            //GridView2.Visible = true;
            //GridView2.DataSource = data;
            //GridView2.DataBind();

            //GridView2.Visible = false;
            //GridView1.Visible = true;
            //SqlDataSource1.SelectCommand = "SELECT ID_LEARNER, FIO, CLASS, BIRTHDAY, SCHOOL, PHONE, SHIFT, E_MAIL, INTERESTS, COMMENTS FROM TECHNOPARK.LEARNER";
            //GridView1.DataBind();

            //GridView1.DataSource = zp1;
            //GridView1.DataBind();

            // var zp1 = from x in oraAdap.SelectCommand.CommandText
            //   select new
            //  {
            //    FIO = x
            // };
            //GridView1.Visible = false;
            //GridView2.Visible = true;
            // GridView1.DataSource = zp1;
            // GridView1.DataBind();

        }
    }
}