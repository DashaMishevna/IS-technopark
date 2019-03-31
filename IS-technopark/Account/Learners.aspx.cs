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
    public partial class Learners : System.Web.UI.Page
    {
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            oraConnection.Open();
            string s1 = "Select Title from DIR_PROJECTS WHERE id_Laboratory = ( Select id_Laboratories from DIR_LABORATORIES where LABORATORY = '" + DropDownList1.SelectedValue.ToString() + "')";
            OracleDataAdapter oraAdap = new OracleDataAdapter(s1, oraConnection);
            oraAdap.Fill(ds);
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "Title";
            DropDownList2.DataBind();
            DropDownList2.SelectedIndex = 0;
        }
    }
}