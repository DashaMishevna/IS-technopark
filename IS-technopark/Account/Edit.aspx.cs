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
    public partial class Edit : Page
    {
        OracleConnection ORACLE = new OracleConnection(constr);
        static string constr = "User Id=Technopark; Password=DIP1937;Data Source=127.0.0.1:1521/xe";
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        //AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        List<string> textBox = new List<string>();
        DataTable fio_l = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        { 
            Label3.Visible = false;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            ORACLE.Open();
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "Select FIO from EMPLOYEES";
            oraAdap.SelectCommand.Connection = ORACLE;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                textBox.Add(values[0].ToString());
            }

            bool flag = false;
            for (int i = 0; i < textBox.Count; i++)
            {
              if (textBox[i] == TextBox1.Text) flag = true;
            }

            int query = (from users in oraAdap.SelectCommand.CommandText
                         where users.ToString()==(TextBox1.Text)
                         select new
                         {
                             count_user = users

                         }).Count();
            if (flag==true) Response.Redirect("HomePage");
            //{
            //    var query2 = (from users in textBox
            //                  where users.ToString() == (TextBox1.Text)
            //                  select new
            //                  {
            //                      id = users
            //                  });

            //    foreach (var a in query2)
            //    {
            //        HttpContext.Current.Session["id"] = a.id.ToString();
            //        //HttpContext.Current.Session["fio"] = a.fio.ToString();
            //    }
            //    Response.Redirect("HomePage.aspx");
            //    ORACLE.Close();
            //}

            else
            {
                Label3.Visible = true;
                Label3.Text = "Нет совпадений!";
            }
        }
             
                //        ORACLE.Close();
            

    }

}