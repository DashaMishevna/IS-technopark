﻿using Microsoft.Reporting.WebForms;
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
        List<string> id_learner = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt2 = new DataTable();
                dt2 = labssss(dt2);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rdts = new ReportDataSource("DataSet2", dt2);
                ReportViewer1.LocalReport.DataSources.Add(rdts);
                ReportViewer1.LocalReport.Refresh();
            }

            int a = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                oraConnection.Open();
                CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
                if (cb != null && cb.Checked)
                {
                    oraAdap.SelectCommand = new OracleCommand();
                    oraAdap.SelectCommand.CommandText = "Select * FROM TECHNOPARK.QUEUE where TECHNOPARK.QUEUE.ID_QUEUE = '" + GridView1.DataKeys[a].Values[0] + "'";
                    oraAdap.SelectCommand.Connection = oraConnection;
                    OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
                    while (oraReader.Read())
                    {
                        object[] values = new object[oraReader.FieldCount];
                        oraReader.GetValues(values);
                        id_status.Add(values[0].ToString());
                    }

                }
                a += 1;
                // Response.Write(cb + "<b>tut</b><br/>");
                oraConnection.Close();
            }

        }

        public DataTable labssss(DataTable dt)
        {
            oraConnection.Open();
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "Select FIO, CLASS, SCHOOL from LEARNER";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            oraAdap.Fill(dt);
            return dt;
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

        public void SelectGroupt()
        {
            SqlDataSource1.SelectCommand = "SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.EMPLOYEES.FIO, TECHNOPARK.DIR_PROJECTS.TITLE AS EXPR1, TECHNOPARK.GROUPS.D_START, TECHNOPARK.GROUPS.D_END, TECHNOPARK.GROUPS.D_CONFERENCE, TECHNOPARK.GROUPS.TIME_CLASS, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.DIR_STATUS_GROUP.STATUS_G, TECHNOPARK.GROUPS.ID_GROUPT FROM TECHNOPARK.GROUPS INNER JOIN TECHNOPARK.EMPLOYEES ON TECHNOPARK.GROUPS.ID_EMPLOYEES = TECHNOPARK.EMPLOYEES.ID_EMPLOYEES INNER JOIN TECHNOPARK.DIR_STATUS_GROUP ON TECHNOPARK.GROUPS.STATUS = TECHNOPARK.DIR_STATUS_GROUP.ID_DIR_STATUS_GROUP INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.GROUPS.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS WHERE TECHNOPARK.GROUPS.TITLE = '" + TextBox1.Text + "' and ID_GROUPT!=0";
            SqlDataSource1.DataBind();
            GridView1.DataBind();
            SelectQLearner();
        }

        protected void Button2_Click(object sender, EventArgs e)
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
                SqlDataSource2.DataBind();
                GridView1.DataBind();
            }
        }
    }
}