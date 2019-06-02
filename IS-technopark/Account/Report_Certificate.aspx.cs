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
            SqlDataSource1.SelectCommand = "SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.EMPLOYEES.FIO, TECHNOPARK.DIR_PROJECTS.TITLE AS EXPR1, TECHNOPARK.GROUPS.D_START, TECHNOPARK.GROUPS.D_END, TECHNOPARK.GROUPS.D_CONFERENCE, TECHNOPARK.GROUPS.TIME_CLASS, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.DIR_STATUS_GROUP.STATUS_G, TECHNOPARK.GROUPS.ID_GROUPT FROM TECHNOPARK.GROUPS INNER JOIN TECHNOPARK.EMPLOYEES ON TECHNOPARK.GROUPS.ID_EMPLOYEES = TECHNOPARK.EMPLOYEES.ID_EMPLOYEES INNER JOIN TECHNOPARK.DIR_STATUS_GROUP ON TECHNOPARK.GROUPS.STATUS = TECHNOPARK.DIR_STATUS_GROUP.ID_DIR_STATUS_GROUP INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.GROUPS.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS WHERE TECHNOPARK.GROUPS.TITLE = '" + TextBox1.Text + "' and ID_GROUPT!=0";
            SqlDataSource1.DataBind();
            GridView1.DataBind();
            //SelectQLearner();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                //string command = SqlDataSource1.SelectCommand;
                SelectGroupt();
            }
            else
            {
                string command = SqlDataSource1.SelectCommand;
                SqlDataSource1.SelectCommand = "SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.EMPLOYEES.FIO, TECHNOPARK.DIR_PROJECTS.TITLE AS EXPR1, TECHNOPARK.GROUPS.D_START, TECHNOPARK.GROUPS.D_END, TECHNOPARK.GROUPS.D_CONFERENCE, TECHNOPARK.GROUPS.TIME_CLASS, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.DIR_STATUS_GROUP.STATUS_G, TECHNOPARK.GROUPS.ID_GROUPT FROM TECHNOPARK.GROUPS INNER JOIN TECHNOPARK.EMPLOYEES ON TECHNOPARK.GROUPS.ID_EMPLOYEES = TECHNOPARK.EMPLOYEES.ID_EMPLOYEES INNER JOIN TECHNOPARK.DIR_STATUS_GROUP ON TECHNOPARK.GROUPS.STATUS = TECHNOPARK.DIR_STATUS_GROUP.ID_DIR_STATUS_GROUP INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.GROUPS.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS WHERE ID_GROUPT!=0";
                SqlDataSource1.DataBind();
                GridView1.DataBind();
            }
        }

    }
}