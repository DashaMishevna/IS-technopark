﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IS_technopark.Account
{
    public partial class Groups : System.Web.UI.Page
    {
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataSet ds = new DataSet();
        string id_lab = "";
        string id_project = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDropList();
                DropDownList3.Items.Insert(0, new ListItem("-Выберете проект-"));
            }
            if (!IsPostBack || DropDownList2.SelectedValue.ToString() == "0")
            {
                string command = SqlDataSource2.SelectCommand;
                SqlDataSource2.SelectCommand = "SELECT TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL, TECHNOPARK.DIR_PROJECTS.TITLE FROM TECHNOPARK.LEARNER INNER JOIN  TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES ";
            }

        }

        private void GetDropList()
        {
            oraConnection.Open();
            string s1 = "Select Laboratory from DIR_LABORATORIES";
            OracleDataAdapter oraAdap = new OracleDataAdapter(s1, oraConnection);
            oraAdap.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList2.DataSource = ds;
                DropDownList2.DataTextField = "Laboratory";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("-Выберете направление-"));
                DropDownList2.SelectedIndex = 0;
            }
            oraConnection.Close();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue.ToString() != "0")
            {
                oraConnection.Open();
                string s1 = "Select Title from DIR_PROJECTS WHERE id_Laboratory = ( Select id_Laboratories from DIR_LABORATORIES where LABORATORY = '" + DropDownList2.SelectedValue.ToString() + "')";
                OracleDataAdapter oraAdap = new OracleDataAdapter(s1, oraConnection);
                oraAdap.Fill(ds);
                DropDownList3.DataSource = ds;
                DropDownList3.DataTextField = "Title";
                DropDownList3.DataBind();
                DropDownList3.Items.Insert(0, new ListItem("-Выберете проект-"));
                DropDownList3.SelectedIndex = 0;
                 string command = SqlDataSource2.SelectCommand;
                 SqlDataSource2.SelectCommand = "SELECT TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL, TECHNOPARK.DIR_PROJECTS.TITLE FROM TECHNOPARK.LEARNER INNER JOIN  TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES WHERE TECHNOPARK.DIR_LABORATORIES.LABORATORY = '" + DropDownList2.Text + "'";
                 SqlDataSource2.DataBind();
                 GridView1.DataBind();

                oraConnection.Close();
            }
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
                oraConnection.Open();
                string command = SqlDataSource2.SelectCommand;
                SqlDataSource2.SelectCommand = "SELECT TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL, TECHNOPARK.DIR_PROJECTS.TITLE FROM TECHNOPARK.LEARNER INNER JOIN  TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES WHERE TECHNOPARK.LEARNER.INTERESTS LIKE '%" + DropDownList4.Text + "%'";
                SqlDataSource2.DataBind();
                GridView1.DataBind();

                oraConnection.Close();
        }
    }
}