using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace IS_technopark.Account
{
    public partial class Diagramm_repeat : System.Web.UI.Page
    {
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        List<string> List_x = new List<string>();
        List<string> List_y = new List<string>();
        List<string> List_percent = new List<string>();
        string All;

        protected void Page_Load(object sender, EventArgs e)
        {
            oraConnection.Open();
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "select c-b as a, b, c from (select count(a)b from (Select count (ID_LEARNER_Q) a from queue GROUP by ID_LEARNER_Q) where a>1), (Select count (ID_LEARNER)c from LEARNER)";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                List_x.Add(values[0].ToString());
                List_x.Add(values[1].ToString());
                List_y.Add(values[0].ToString());
                List_y.Add(values[1].ToString());
                All = values[2].ToString();
            }

            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "select (b*100)/c from (select count(a)b from (Select count (ID_LEARNER_Q) a from queue GROUP by ID_LEARNER_Q) where a>1), (Select count (ID_LEARNER)c from LEARNER)";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader1 = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader1.Read())
            {
                object[] values = new object[oraReader1.FieldCount];
                oraReader1.GetValues(values);
                List_percent.Add(values[0].ToString());
            }

            Chart1.Series[0].Points.DataBindXY(List_x, List_y);
            Chart1.Series[0].ChartType = SeriesChartType.Pie;
            //Chart1.Legends[0].Enabled = true;
            Label1.Text = List_percent[0].ToString() + "% из 100% повторно прошли обучение на разных или одинаковых направлениях";
            Label2.Text = "Всего проектантов: " + All;
            Label3.Text = "Повторно прошли обучение: " + List_x[1];
            oraConnection.Close();
        }

    }
}