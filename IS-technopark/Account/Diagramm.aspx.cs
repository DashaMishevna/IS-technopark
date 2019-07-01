using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace IS_technopark.Account
{
    public partial class Diagramm : System.Web.UI.Page
    {
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataTable table = new DataTable();
        DataSet ds = new DataSet();
        List<string> count = new List<string>();
        List<string> count1 = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            oraConnection.Open();
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "select Count(ID_queue), DIR_LABORATORIES.LABORATORY from QUEUE, DIR_LABORATORIES,groups WHERE groups.TITLE=queue.TITLE_G and EXTRACT(YEAR FROM groups.D_CONFERENCE)='"+ DropDownList1.SelectedValue+"' and QUEUE.ID_LABORATORIES = DIR_LABORATORIES.ID_LABORATORIES and Queue.id_status_l=5 group by DIR_LABORATORIES.LABORATORY";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                count.Add(values[1].ToString());
                count1.Add(values[0].ToString());
            }

            //oraAdap.SelectCommand = new OracleCommand();
            //oraAdap.SelectCommand.CommandText = "select Count(ID_queue), DIR_LABORATORIES.LABORATORY from QUEUE, DIR_LABORATORIES,groups WHERE groups.TITLE=queue.TITLE_G and QUEUE.ID_LABORATORIES = DIR_LABORATORIES.ID_LABORATORIES and EXTRACT(MONTH FROM DATE_REGISTRATION)=4 and Queue.id_status_l=5 group by DIR_LABORATORIES.LABORATORY";
            //oraAdap.SelectCommand.Connection = oraConnection;
            //OracleDataReader oraReader1 = oraAdap.SelectCommand.ExecuteReader();
            //while (oraReader1.Read())
            //{
            //    object[] values = new object[oraReader1.FieldCount];
            //    oraReader1.GetValues(values);
            //    count1.Add(values[0].ToString());
            //}

            string[] x = new string[count.Count];
            int[] y = new int[count1.Count];

            for (int i = 0; i < count.Count; i++)
            {
                x[i] = count[i].ToString();
            }

            for (int i = 0; i < count1.Count; i++)
            {
                y[i] = Convert.ToInt32(count1[i]);
            }

            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.Funnel;
            Chart1.Legends[0].Enabled = true;
            //GridView1.DataSource = count1;
            //GridView1.DataBind();
            oraConnection.Close();
        }
    }
}