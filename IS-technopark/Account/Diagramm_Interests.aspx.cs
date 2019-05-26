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
    public partial class Diagramm_Interests : System.Web.UI.Page
    {
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        List<string> List_x = new List<string>();
        List<string> List_y = new List<string>();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            oraConnection.Open();
            if (!IsPostBack)
            {
                GetDropList();
            }
        }

        private void Diagramm_GridView()
        {
            //oraConnection.Open();
            //GetDropList();
            //Chart1.Titles.Add("Диаграмма по интересам");
            //Chart1.Titles[0].Font = new Font("Utopia", 16);

            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "select Count(ID_Learner), class from Learner WHERE INTERESTS Like '%" + DropDownList1.Text + "%' group by Class";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                List_x.Add(values[0].ToString());
                List_y.Add(values[1].ToString());
            }

            string command = SqlDataSource1.SelectCommand;
            SqlDataSource1.SelectCommand = "select Count(ID_Learner) as Количество, class as Класс from Learner WHERE INTERESTS Like '%" + DropDownList1.Text + "%' group by Class";
            SqlDataSource1.DataBind();
            GridView1.DataBind();

            Chart1.Series[0].Name = DropDownList1.Text;
            Chart1.Series[0].Points.DataBindXY(List_y, List_x);
            Chart1.Series[0].ChartType = SeriesChartType.Column;
            Chart1.Legends[0].Enabled = true;
            oraConnection.Close();
        }

        private void GetDropList()
        {
            string s1 = "Select Laboratory from DIR_LABORATORIES";
            OracleDataAdapter oraAdap = new OracleDataAdapter(s1, oraConnection);
            oraAdap.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "Laboratory";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("-Выберите направление-"));
                DropDownList1.SelectedIndex = 0;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Diagramm_GridView();
        }
    }
}