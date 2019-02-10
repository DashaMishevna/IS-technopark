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
        List<string> textBox_f = new List<string>();
        List<string> textBox_k = new List<string>();
        List<string> textBox_auto = new List<string>();
        DataTable fio_l = new DataTable();
        TextBox textBox = new TextBox();


        protected void Button1_Click(object sender, EventArgs e)
        {
            ORACLE.Open();
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "Select L_name || ' ' || F_NAME as FIO from EMPLOYEES";
            oraAdap.SelectCommand.Connection = ORACLE;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                textBox_f.Add(values[0].ToString());
            }
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "Select KEY from EMPLOYEES";
            oraAdap.SelectCommand.Connection = ORACLE;
            OracleDataReader oraReader_1 = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader_1.Read())
            {
                object[] values = new object[oraReader_1.FieldCount];
                oraReader_1.GetValues(values);
                textBox_k.Add(values[0].ToString());
            }

           

            bool flag = false;
            for (int i = 0; i < textBox_k.Count; i++)
            {
                if (textBox_f[i] == TextBox1.Text & textBox_k[i] == TextBox2.Text) flag = true;
            }

            Class_FIO.Teachr_fio = TextBox1.Text.Trim();

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