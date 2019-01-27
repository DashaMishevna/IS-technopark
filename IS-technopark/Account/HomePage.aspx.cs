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

namespace IS_technopark
{
    public partial class HomePage : Page
    {
        OracleConnection ORACLE = new OracleConnection(constr);
        static string constr = "User Id=Technopark; Password=DIP1937;Data Source=127.0.0.1:1521/xe";
        OracleDataAdapter oraAdap = new OracleDataAdapter();


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ORACLE.Open();
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "Select KEY from EMPLOYEES ";
            oraAdap.SelectCommand.Connection = ORACLE;
            OracleDataReader oraReader1 = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader1.Read())
            {
                object[] values = new object[oraReader1.FieldCount];
                oraReader1.GetValues(values);
                ListBox1.Items.Add(values[0].ToString());
            }
        }
    
    }
}