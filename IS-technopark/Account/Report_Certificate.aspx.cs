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
    public partial class Report_Certificate : System.Web.UI.Page
    {
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataSet ds = new DataSet();
        string id_lab = "";
        List<string> id_learner = new List<string>();
        List<string> d_conf = new List<string>();
        List<string> inf_learner = new List<string>();
        List<string> school_list = new List<string>();
        DataTable dt_button = new DataTable();
        int cont_repeat = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Text = " ";
            //if (!IsPostBack)
            //{
            //    DataTable dt2 = new DataTable();
            //    dt2 = labssss(dt2);
            //    ReportViewer1.LocalReport.DataSources.Clear();
            //    ReportDataSource rdts = new ReportDataSource("DataSet2", dt2);
            //    ReportViewer1.LocalReport.DataSources.Add(rdts);
            //    ReportViewer1.LocalReport.Refresh();
            //}

            int a = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                oraConnection.Open();
                CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
                if (cb != null && cb.Checked)
                {
                    oraAdap.SelectCommand = new OracleCommand();
                    oraAdap.SelectCommand.CommandText = "Select ID_LEARNER FROM TECHNOPARK.LEARNER where TECHNOPARK.LEARNER.ID_LEARNER = '" + GridView1.DataKeys[a].Values[0] + "'";
                    oraAdap.SelectCommand.Connection = oraConnection;
                    OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
                    while (oraReader.Read())
                    {
                        object[] values = new object[oraReader.FieldCount];
                        oraReader.GetValues(values);
                        id_learner.Add(values[0].ToString());
                    }

                    oraAdap.SelectCommand = new OracleCommand();
                    oraAdap.SelectCommand.CommandText = "Select D_CONFERENCE FROM TECHNOPARK.GROUPS where TECHNOPARK.GROUPS.TITLE = '" + GridView1.DataKeys[a].Values[1] + "'";
                    oraAdap.SelectCommand.Connection = oraConnection;
                    OracleDataReader oraReader1 = oraAdap.SelectCommand.ExecuteReader();
                    while (oraReader1.Read())
                    {
                        object[] values = new object[oraReader1.FieldCount];
                        oraReader1.GetValues(values);
                        d_conf.Add(values[0].ToString());

                    }
                }
                a += 1;
                // Response.Write(cb + "<b>tut</b><br

                oraConnection.Close();
            }
        }

        public void SelectGroupt()
        {
            SqlDataSource2.SelectCommand = "SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.LEARNER.FIO, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SCHOOL, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.EMPLOYEES.FIO AS EXPR1, TECHNOPARK.GROUPS.D_CONFERENCE, TECHNOPARK.LEARNER.ID_LEARNER FROM TECHNOPARK.EMPLOYEES INNER JOIN TECHNOPARK.GROUPS ON TECHNOPARK.EMPLOYEES.ID_EMPLOYEES = TECHNOPARK.GROUPS.ID_EMPLOYEES INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.GROUPS.TITLE = TECHNOPARK.QUEUE.TITLE_G INNER JOIN TECHNOPARK.LEARNER ON TECHNOPARK.QUEUE.ID_LEARNER_Q = TECHNOPARK.LEARNER.ID_LEARNER where TECHNOPARK.GROUPS.TITLE = '" + TextBox1.Text + "' and ID_GROUPT!=0";
            SqlDataSource2.DataBind();
            GridView1.DataBind();
            //SelectQLearner();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                SelectGroupt();
            }
            else
            {
                string command = SqlDataSource1.SelectCommand;
                SqlDataSource2.SelectCommand = "SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.LEARNER.FIO, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SCHOOL, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.EMPLOYEES.FIO AS EXPR1, TECHNOPARK.GROUPS.D_CONFERENCE, TECHNOPARK.LEARNER.ID_LEARNER FROM TECHNOPARK.EMPLOYEES INNER JOIN TECHNOPARK.GROUPS ON TECHNOPARK.EMPLOYEES.ID_EMPLOYEES = TECHNOPARK.GROUPS.ID_EMPLOYEES INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.GROUPS.TITLE = TECHNOPARK.QUEUE.TITLE_G INNER JOIN TECHNOPARK.LEARNER ON TECHNOPARK.QUEUE.ID_LEARNER_Q = TECHNOPARK.LEARNER.ID_LEARNER order by TECHNOPARK.GROUPS.TITLE";
                SqlDataSource2.DataBind();
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            LocalReport localReport = ReportViewer1.LocalReport;
            localReport.ReportPath = "Account/Certificate.rdlc";
            ReportParameter reportParam_FIO = new ReportParameter();
            reportParam_FIO.Name = "DIRDD";
            reportParam_FIO.Values.Add(Class_FIO.DirectorDD);
            //reportParam.Add(new ReportParameter("DCONF", d_conf[0].ToString()));
            localReport.SetParameters(new ReportParameter[] { reportParam_FIO });
        }
    }
}