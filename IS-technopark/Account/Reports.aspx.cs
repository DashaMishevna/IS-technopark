using Microsoft.Reporting.WebForms;
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
    public partial class Reports : System.Web.UI.Page
    {
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataSet ds = new DataSet();
        string id_lab = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            oraConnection.Open();
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "Select * from DIR_LABORATORIES where id_Laboratories = 1";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            List<labs> lab = new List<labs>();
            while (oraReader.Read())
            {
                labs lab1 = new labs();
                //object[] values = new object[oraReader.FieldCount];
                //oraReader.GetValues(values);
                //id_lab = values[0].ToString();
                lab1.id = "kek1";
                lab1.name = "kek";
                lab1.cab = "kek2";

                lab.Add(lab1);

            }
            //DataSet lab = new DataSet();
            //oraAdap.Fill(lab);

            reportForming("2015", lab);  
        }

        public struct labs
        {
            public string id { get; set; }
            public string name { get; set; }
            public string cab { get; set; }
        }

        public static List<labs> SelectList()
        {
            List<labs> Listlabs = new List<labs>();
            labs lab1 = new labs();
            lab1.id = "one";
            lab1.name = "two";
            lab1.cab = "three";
            Listlabs.Add(lab1);
            return Listlabs;


        }

    public void reportForming(string chislo1, List<labs> dataset)
        {
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = "Account/Report1.rdlc";
            
            localReport.DataSources.Add(new ReportDataSource("DataSet2", dataset));

            //List<ReportParameter> reportParametrs = new List<ReportParameter>();
            //reportParametrs.Add(new ReportParameter("chislo", chislo));
            //localReport.SetParameters(reportParametrs);
            ReportParameter rpParametr = new ReportParameter();
            rpParametr.Name = "chislo";
            rpParametr.Values.Add(chislo1);
            localReport.SetParameters(new ReportParameter[] { rpParametr });
        }

        protected void ReportViewer1_Init(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    DataSet ds = new DataSet();
            //    reportForming("2016", ds);
            //}
        }
    }
}