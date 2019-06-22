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
    public partial class View_Group : System.Web.UI.Page
    {
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataTable table = new DataTable();
        string id_s_g = "";
        string id_s_l = "";
        string id_G = "";
        List<string> id_status = new List<string>();
        List<string> list_gr = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Class_FIO.Employees_position=="2")
            {
                string command = SqlDataSource1.SelectCommand;
                SqlDataSource1.SelectCommand = "SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.EMPLOYEES.FIO, TECHNOPARK.DIR_PROJECTS.TITLE AS EXPR1, TECHNOPARK.GROUPS.D_START, TECHNOPARK.GROUPS.D_END, TECHNOPARK.GROUPS.D_CONFERENCE, TECHNOPARK.GROUPS.TIME_CLASS, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.DIR_STATUS_GROUP.STATUS_G, TECHNOPARK.GROUPS.ID_GROUPT FROM TECHNOPARK.GROUPS INNER JOIN TECHNOPARK.EMPLOYEES ON TECHNOPARK.GROUPS.ID_EMPLOYEES = TECHNOPARK.EMPLOYEES.ID_EMPLOYEES INNER JOIN TECHNOPARK.DIR_STATUS_GROUP ON TECHNOPARK.GROUPS.STATUS = TECHNOPARK.DIR_STATUS_GROUP.ID_DIR_STATUS_GROUP INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.GROUPS.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS WHERE ID_GROUPT!=0 and TECHNOPARK.EMPLOYEES.FIO= '"+ Class_FIO.Employees_fio +"' ";
                SqlDataSource1.DataBind();
                GridView1.DataBind();
            }
            if (Class_FIO.Employees_position=="1")
            {
                string command = SqlDataSource1.SelectCommand;
                SqlDataSource1.SelectCommand = "SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.EMPLOYEES.FIO, TECHNOPARK.DIR_PROJECTS.TITLE AS EXPR1, TECHNOPARK.GROUPS.D_START, TECHNOPARK.GROUPS.D_END, TECHNOPARK.GROUPS.D_CONFERENCE, TECHNOPARK.GROUPS.TIME_CLASS, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.DIR_STATUS_GROUP.STATUS_G, TECHNOPARK.GROUPS.ID_GROUPT FROM TECHNOPARK.GROUPS INNER JOIN TECHNOPARK.EMPLOYEES ON TECHNOPARK.GROUPS.ID_EMPLOYEES = TECHNOPARK.EMPLOYEES.ID_EMPLOYEES INNER JOIN TECHNOPARK.DIR_STATUS_GROUP ON TECHNOPARK.GROUPS.STATUS = TECHNOPARK.DIR_STATUS_GROUP.ID_DIR_STATUS_GROUP INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.GROUPS.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS WHERE ID_GROUPT!=0";
                SqlDataSource1.DataBind();
                GridView1.DataBind();
            }

            int a = 0;
            foreach (GridViewRow row in GridView2.Rows)
            {
                oraConnection.Open();
                CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
                if (cb != null && cb.Checked)
                {
                    oraAdap.SelectCommand = new OracleCommand();
                    oraAdap.SelectCommand.CommandText = "Select * FROM TECHNOPARK.QUEUE where TECHNOPARK.QUEUE.ID_QUEUE = '" + GridView2.DataKeys[a].Values[0] + "'";
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

            //int b = 0;
            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    oraConnection.Open();
            //    CheckBox cb = (CheckBox)row.FindControl("CheckBox_GR");
            //    if (cb != null && cb.Checked)
            //    {
            //        oraAdap.SelectCommand = new OracleCommand();
            //        oraAdap.SelectCommand.CommandText = "SELECT TECHNOPARK.GROUPS.TITLE FROM TECHNOPARK.GROUPS WHERE TECHNOPARK.GROUPS.TITLE = '" + GridView1.DataKeys[b].Values[1] + "'";
            //        oraAdap.SelectCommand.Connection = oraConnection;
            //        OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            //        while (oraReader.Read())
            //        {
            //            object[] values = new object[oraReader.FieldCount];
            //            oraReader.GetValues(values);
            //            list_gr.Add(values[0].ToString());
            //        }
            //    }
            //    b += 1;
            //    // Response.Write(cb + "<b>tut</b><br/>");
            //    oraConnection.Close();
            //}

        }

        public void GetId_l()
        {
            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataBind();
            if (this.IsPostBack)
            {
                string command = SqlDataSource1.SelectCommand;
                SqlDataSource1.SelectCommand = "SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.EMPLOYEES.FIO, TECHNOPARK.DIR_PROJECTS.TITLE AS EXPR1, TECHNOPARK.GROUPS.D_START, TECHNOPARK.GROUPS.D_END, TECHNOPARK.GROUPS.D_CONFERENCE, TECHNOPARK.GROUPS.TIME_CLASS, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.DIR_STATUS_GROUP.STATUS_G, TECHNOPARK.GROUPS.ID_GROUPT FROM TECHNOPARK.GROUPS INNER JOIN TECHNOPARK.EMPLOYEES ON TECHNOPARK.GROUPS.ID_EMPLOYEES = TECHNOPARK.EMPLOYEES.ID_EMPLOYEES INNER JOIN TECHNOPARK.DIR_STATUS_GROUP ON TECHNOPARK.GROUPS.STATUS = TECHNOPARK.DIR_STATUS_GROUP.ID_DIR_STATUS_GROUP INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.GROUPS.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS WHERE ID_GROUPT!=0 order by TECHNOPARK.GROUPS.TITLE";
                SqlDataSource1.DataBind();
                GridView1.DataBind();                
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                {
                    GridViewRow row = GridView1.Rows[e.RowIndex];
                    string query = "UPDATE TECHNOPARK.GROUPS SET D_START=:D_START, D_END=:D_END, D_CONFERENCE=:D_CONFERENCE, TIME_CLASS=:TIME_CLASS, PROJECT_THEME=:PROJECT_THEME WHERE ID_GROUPT=:ID_GROUPT";
                    OracleCommand oraclecmd = new OracleCommand(query, oraConnection);
                    oraclelcon.Open();
                    oraclecmd.Connection.Open();
                    oraclecmd.Parameters.Add("D_START", Convert.ToDateTime(e.NewValues["D_START"]));
                    oraclecmd.Parameters.Add("D_END", Convert.ToDateTime(e.NewValues["D_END"]));
                    oraclecmd.Parameters.Add("D_CONFERENCE", Convert.ToDateTime(e.NewValues["D_CONFERENCE"]));
                    oraclecmd.Parameters.Add("TIME_CLASS", e.NewValues["TIME_CLASS"]);
                    oraclecmd.Parameters.Add("PROJECT_THEME", e.NewValues["PROJECT_THEME"]);
                    oraclecmd.Parameters.Add("ID_GROUPT", GridView1.DataKeys[e.RowIndex].Value);
                    oraclecmd.ExecuteNonQuery();
                    GridView1.EditIndex = -1;
                    oraclelcon.Close();
                }
            }
            catch
            {
                Label1.Visible = true;
                Label1.Text = "Проверьте введенные данные!";
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
        public void GetId_S_G()
        {
            //oraConnection.Open();
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "Select ID_DIR_STATUS_GROUP from DIR_STATUS_GROUP where STATUS_G = '" + DropDownList2.SelectedValue.ToString() + "'";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                id_s_g = values[0].ToString();
            }
            //oraConnection.Close();
        }

        public void GetId_S_L()
        {
            //oraConnection.Open();
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "Select ID_DIR_STATUS_LEARNER from DIR_STATUS_LEARNER where STATUS_L = '" + DropDownList1.SelectedValue.ToString() + "'";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                id_s_l = values[0].ToString();
            }
            //oraConnection.Close();
        }

        public void GetId_G()
        {
            //oraConnection.Open();
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "SELECT ID_GROUPT from GROUPS WHERE TITLE = '" + TextBox1.Text + "' and ID_GROUPT!=0";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                id_G = values[0].ToString();
            }
            //oraConnection.Close();
        }

        public void SelectQLearner()
        {
            SqlDataSource2.SelectCommand = "SELECT TECHNOPARK.LEARNER.FIO, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.DIR_STATUS_LEARNER.STATUS_L, TECHNOPARK.QUEUE.ID_QUEUE, TECHNOPARK.LEARNER.PHONE, TECHNOPARK.LEARNER.E_MAIL FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.GROUPS ON TECHNOPARK.QUEUE.TITLE_G = TECHNOPARK.GROUPS.TITLE INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE TECHNOPARK.GROUPS.TITLE = '" + TextBox1.Text + "' and ID_GROUPT!=0 and ID_QUEUE!=0";
            SqlDataSource2.DataBind();
            GridView2.DataBind();
            Label3.Text = "Проектанты по выбранной группе";
        }


        public void SelectGroupt()
        {
            SqlDataSource1.SelectCommand = "SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.EMPLOYEES.FIO, TECHNOPARK.DIR_PROJECTS.TITLE AS EXPR1, TECHNOPARK.GROUPS.D_START, TECHNOPARK.GROUPS.D_END, TECHNOPARK.GROUPS.D_CONFERENCE, TECHNOPARK.GROUPS.TIME_CLASS, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.DIR_STATUS_GROUP.STATUS_G, TECHNOPARK.GROUPS.ID_GROUPT FROM TECHNOPARK.GROUPS INNER JOIN TECHNOPARK.EMPLOYEES ON TECHNOPARK.GROUPS.ID_EMPLOYEES = TECHNOPARK.EMPLOYEES.ID_EMPLOYEES INNER JOIN TECHNOPARK.DIR_STATUS_GROUP ON TECHNOPARK.GROUPS.STATUS = TECHNOPARK.DIR_STATUS_GROUP.ID_DIR_STATUS_GROUP INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.GROUPS.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS WHERE TECHNOPARK.GROUPS.TITLE = '" + TextBox1.Text + "' and ID_GROUPT!=0";
            SqlDataSource1.DataBind();
            GridView1.DataBind();
            SelectQLearner();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                //string command = SqlDataSource1.SelectCommand;
                SelectGroupt();
                Label2.Visible = true;
                Label4.Visible = true;
                DropDownList1.Visible = true;
                Button3.Visible = true;
            }
            else
            {
                string command = SqlDataSource1.SelectCommand;
                SqlDataSource1.SelectCommand = "SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.EMPLOYEES.FIO, TECHNOPARK.DIR_PROJECTS.TITLE AS EXPR1, TECHNOPARK.GROUPS.D_START, TECHNOPARK.GROUPS.D_END, TECHNOPARK.GROUPS.D_CONFERENCE, TECHNOPARK.GROUPS.TIME_CLASS, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.DIR_STATUS_GROUP.STATUS_G, TECHNOPARK.GROUPS.ID_GROUPT FROM TECHNOPARK.GROUPS INNER JOIN TECHNOPARK.EMPLOYEES ON TECHNOPARK.GROUPS.ID_EMPLOYEES = TECHNOPARK.EMPLOYEES.ID_EMPLOYEES INNER JOIN TECHNOPARK.DIR_STATUS_GROUP ON TECHNOPARK.GROUPS.STATUS = TECHNOPARK.DIR_STATUS_GROUP.ID_DIR_STATUS_GROUP INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.GROUPS.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS WHERE ID_GROUPT!=0";
                SqlDataSource1.DataBind();
                GridView1.DataBind();
                SqlDataSource2.DataBind();
                GridView2.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            oraConnection.Open();
            GetId_S_G();
            GetId_G();
            int i;
            try
            {
                if (id_G != "")
                {
                    using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                    {
                        //string query_update_g = "Update GROUPS SET D_START='"+ DateTime.Parse(TextBox2.Text).ToShortDateString() + "', D_END='" + DateTime.Parse(TextBox3.Text).ToShortDateString() + "', D_CONFERENCE='" + DateTime.Parse(TextBox4.Text).ToShortDateString() + "', TIME_CLASS='" + TextBox5.Text + "', PROJECT_THEME='" + TextBox6.Text + "' WHERE ID_GROUPT = '" + id_G + "' ";
                        string query_update_g = "Update GROUPS SET STATUS = '" + id_s_g + "'  WHERE ID_GROUPT = '" + id_G + "'";
                        oraAdap.UpdateCommand = new OracleCommand(query_update_g, oraConnection);
                        oraAdap.UpdateCommand.ExecuteNonQuery();
                        Label12.Visible = true;
                        Label12.ForeColor = System.Drawing.Color.Green;
                        Label12.Text = "Данные группы успешно обновлены!";
                        SelectGroupt();
                    }
                }
            }
            catch
            {
                Label12.Visible = true;
                Label12.Text = "Проверьте введенные данные!";
            }
            oraConnection.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            oraConnection.Open();
            GetId_S_L();
            int s = 0;
            foreach (string i in id_status)
            {
                try
                {
                    using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                    {
                        string query_update_q = "Update TECHNOPARK.QUEUE SET ID_STATUS_L = '" + id_s_l + "' WHERE ID_QUEUE = '" + id_status[s] + "' ";
                        oraAdap.UpdateCommand = new OracleCommand(query_update_q, oraConnection);
                        oraAdap.UpdateCommand.ExecuteNonQuery();
                        //GridView2.DataBind();
                        SelectQLearner();
                        //SelectQLearnerCHEC();
                    }
                    //Label13.Visible = true;
                    //Label13.ForeColor = System.Drawing.Color.Green;
                    //Label13.Text = "Данные проектанов успешно обновлены!";
                    Response.Write("<script>alert('Данные проектанов успешно обновлены!')</script>");
                }
                catch
                {
                    //Label13.Visible = true;
                    //Label13.Text = "Проверьте введенные данные!";
                    Response.Write("<script>alert('Проверьте введенные данные!')</script>");
                }
                s += 1;
            }
            oraConnection.Close();
        }

        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    oraConnection.Open();
        //    if (list_gr.Count == 1)
        //    {
        //        SqlDataSource1.SelectCommand = "SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.EMPLOYEES.FIO, TECHNOPARK.DIR_PROJECTS.TITLE AS EXPR1, TECHNOPARK.GROUPS.D_START, TECHNOPARK.GROUPS.D_END, TECHNOPARK.GROUPS.D_CONFERENCE, TECHNOPARK.GROUPS.TIME_CLASS, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.DIR_STATUS_GROUP.STATUS_G, TECHNOPARK.GROUPS.ID_GROUPT FROM TECHNOPARK.GROUPS INNER JOIN TECHNOPARK.EMPLOYEES ON TECHNOPARK.GROUPS.ID_EMPLOYEES = TECHNOPARK.EMPLOYEES.ID_EMPLOYEES INNER JOIN TECHNOPARK.DIR_STATUS_GROUP ON TECHNOPARK.GROUPS.STATUS = TECHNOPARK.DIR_STATUS_GROUP.ID_DIR_STATUS_GROUP INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.GROUPS.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS WHERE TECHNOPARK.GROUPS.TITLE = '" + list_gr[0] + "' and ID_GROUPT!=0";
        //        SqlDataSource1.DataBind();
        //        GridView1.DataBind();

        //        SqlDataSource2.SelectCommand = "SELECT TECHNOPARK.LEARNER.FIO, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.DIR_STATUS_LEARNER.STATUS_L, TECHNOPARK.QUEUE.ID_QUEUE, TECHNOPARK.LEARNER.PHONE, TECHNOPARK.LEARNER.E_MAIL FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.GROUPS ON TECHNOPARK.QUEUE.TITLE_G = TECHNOPARK.GROUPS.TITLE INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE TECHNOPARK.GROUPS.TITLE = '" + list_gr[0] + "' and ID_GROUPT!=0 and ID_QUEUE!=0";
        //        SqlDataSource2.DataBind();
        //        GridView2.DataBind();
        //        Label3.Text = "Проектанты по выбранной группе";

        //        Label2.Visible = true;
        //        Label4.Visible = true;
        //        DropDownList1.Visible = true;
        //        Button3.Visible = true;
        //    }

        //    else
        //    {

        //    }
        //    oraConnection.Close();
        //}
    }
}