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
    public partial class List_Queue : System.Web.UI.Page
    {
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataTable table = new DataTable();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDropList();
            }
            if (DropDownList1.SelectedIndex == 0)
            {
                string command = SqlDataSource1.SelectCommand;
                SqlDataSource1.SelectCommand = "SELECT TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.DIR_PROJECTS.TITLE, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.QUEUE.STATUS, TECHNOPARK.QUEUE.D_T_RECORD, TECHNOPARK.LEARNER.INTERESTS FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS";
                SqlDataSource1.DataBind();
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            oraConnection.Open();
                if (this.IsPostBack)
                {
                    string command = SqlDataSource1.SelectCommand;
                    SqlDataSource1.SelectCommand = "SELECT TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.DIR_PROJECTS.TITLE, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.QUEUE.STATUS, TECHNOPARK.QUEUE.D_T_RECORD, TECHNOPARK.LEARNER.INTERESTS FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS WHERE TECHNOPARK.DIR_LABORATORIES.LABORATORY = '" + DropDownList1.Text + "'";
                    SqlDataSource1.DataBind();
                    GridView1.DataBind();
                }
            oraConnection.Close();
        }

        private void GetDropList()
        {
            oraConnection.Open();
            string s1 = "Select Laboratory from DIR_LABORATORIES";
            OracleDataAdapter oraAdap = new OracleDataAdapter(s1, oraConnection);
            oraAdap.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "Laboratory";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("-Выберете направление-"));
                DropDownList1.SelectedIndex = 0;
            }
            oraConnection.Close();
        }
    }
}