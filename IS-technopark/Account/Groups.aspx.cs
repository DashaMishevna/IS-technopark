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
    public partial class Groups : System.Web.UI.Page
    {
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataSet ds = new DataSet();
        string id_lab = "";
        string id_project = "";
        int i = 0;
        List<string> textBox_f = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                oraConnection.Open();
                CheckBox cb = (CheckBox)row.FindControl("SelectLearner");
                if (cb != null && cb.Checked)
                {
                    
                    Label1.Visible = false;
                    //Label1.Text = Label1.Text + " " + row.Cells[1].Text;
                    string query = " Select TECHNOPARK.LEARNER.ID_LEARNER  FROM   TECHNOPARK.LEARNER INNER JOIN  TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN  TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 2) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 6) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 7) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 8) ID_LEARNER=:ID_LEARNER and FIO = '" + row.Cells[2].Text +"' ";
                    OracleCommand oraclecmd = new OracleCommand(query, oraConnection);


                    Response.Write(row.Cells[1].Text + "<b>tut</b><br/>");  
                    oraAdap.SelectCommand = new OracleCommand();
                    oraAdap.SelectCommand.CommandText = "Select TECHNOPARK.LEARNER.ID_LEARNER  FROM   TECHNOPARK.LEARNER INNER JOIN  TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN  TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 2) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 6) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 7) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 8) AND TECHNOPARK.Learner.ID_LEARNER=:ID_LEARNER";
                    oraAdap.SelectCommand.Connection = oraConnection;
                    OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
                    while (oraReader.Read())
                    {
                        object[] values = new object[oraReader.FieldCount];
                        oraReader.GetValues(values);
                        textBox_f.Add(values[0].ToString());
                        Response.Write(values[0].ToString() + "<b>tut</b><br/>");
                    }
                    Label1.Text = textBox_f.ToString();
                }
                // Response.Write(cb + "<b>tut</b><br/>");
                oraConnection.Close();
            }
            
            //AllLearner();
            if (!IsPostBack)
            {
                GetDropList();
                DropDownList3.Items.Insert(0, new ListItem("-Выберете проект-"));
            }

            if (CheckBox1.Checked)
            {
                LearnerLabInteres();
            }

            if (CheckBox1.Checked == false && DropDownList2.SelectedValue.ToString() != "0")
            {
                LearnerLab();
            }

            if (CheckBox1.Checked == false && DropDownList2.SelectedValue.ToString() == "-Выберете направление-")
            {
                AllLearner();
            }
        }

        private void GetInfLearner()
        {
           
            //oraclelcon.Open();
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

        private void AllLearner ()
        {
            string command = SqlDataSource2.SelectCommand;
            SqlDataSource2.SelectCommand = "SELECT TECHNOPARK.LEARNER.ID_LEARNER, TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL,  TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_PROJECTS.TITLE FROM     TECHNOPARK.LEARNER INNER JOIN  TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN  TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 2) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 6) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 7) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 8) and ID_LEARNER!=0";
            SqlDataSource2.DataBind();
            GridView1.DataBind();
            //oraConnection.Close();
            Label9.Visible = true;
            Label9.Text = "Весь список обучающихся";
        }

        private void LearnerLab ()
        {
            string command = SqlDataSource2.SelectCommand;
            SqlDataSource2.SelectCommand = "SELECT TECHNOPARK.LEARNER.ID_LEARNER, TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL,  TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_PROJECTS.TITLE FROM     TECHNOPARK.LEARNER INNER JOIN  TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN  TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 2) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 6) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 7) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 8) and TECHNOPARK.DIR_LABORATORIES.LABORATORY = '" + DropDownList2.Text + "' and ID_LEARNER!=0";
            SqlDataSource2.DataBind();
            GridView1.DataBind();
            //oraConnection.Close();
            Label9.Visible = true;
            Label9.Text = "Список обучающихся по выбранному проекту";
        }

        private void LearnerLabInteres ()
        {
            string command = SqlDataSource2.SelectCommand;
            SqlDataSource2.SelectCommand = "SELECT TECHNOPARK.LEARNER.ID_LEARNER, TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL,  TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_PROJECTS.TITLE FROM     TECHNOPARK.LEARNER INNER JOIN  TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN  TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN  TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 2) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 6) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 7) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 8) and ID_LEARNER !=0 and TECHNOPARK.LEARNER.INTERESTS LIKE '%" + DropDownList2.Text + "%' or TECHNOPARK.DIR_LABORATORIES.LABORATORY = '" + DropDownList2.Text + "' ";
            SqlDataSource2.DataBind();
            CheckBox1.DataBind();
            GridView1.DataBind();
            Label9.Visible = true;
            Label9.Text = "Список обучающихся по выбранному проекту, с учетом интересов";
        }


        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue.ToString() != "0" && CheckBox1.Checked==false)
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
                LearnerLab();
                oraConnection.Close();
                
            }
            

            if (DropDownList2.SelectedValue.ToString() != "0" && CheckBox1.Checked)
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
                LearnerLabInteres();
                oraConnection.Close();
                
            }

            if (CheckBox1.Checked == false && DropDownList2.SelectedValue.ToString() == "-Выберете направление-")
            {
                AllLearner();
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            i = 1;
            //Response.Write(i + "<b>tut</b><br/>");
            Label1.Visible = true;
            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    CheckBox cb = (CheckBox)row.FindControl("SelectLearner");
            //    if (cb != null && cb.Checked)
            //    {
            //        Label1.Text = Label1.Text + " " + row.Cells[2].Text;
            //    }
            //}

        }

    }
}