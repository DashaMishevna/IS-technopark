using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace IS_technopark.Account
{
    public partial class Diagramm_Interests : System.Web.UI.Page
    {
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        List<string> List_x = new List<string>();
        List<string> List_y = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            oraConnection.Open();
            Chart1.Titles.Add("Диаграмма по интересам");
            Chart1.Titles[0].Font = new Font("Utopia", 16);

            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "select Count(ID_Learner), class from Learner WHERE INTERESTS Like '%Робототехника%' group by Class";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                List_x.Add(values[0].ToString());
                List_y.Add(values[1].ToString());
            }

            string[] x = new string[List_x.Count];
            int[] y = new int[List_y.Count];

            for (int i = 0; i < List_x.Count; i++)
            {
                x[i] = List_x[i].ToString();
            }

            for (int i = 0; i < List_y.Count; i++)
            {
                y[i] = Convert.ToInt32(List_y[i]);
            }

            Chart1.Series[0].Points.DataBindXY(List_y, List_x);
            Chart1.Series[0].ChartType = SeriesChartType.Column;
            Chart1.Legends[0].Enabled = true;
            //GridView1.DataSource = count1;
            //GridView1.DataBind();
            oraConnection.Close();
        }
    }
}