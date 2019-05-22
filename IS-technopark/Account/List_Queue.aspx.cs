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
        DataSet dss = new DataSet();
        List<string> id_learner = new List<string>();
        List<string> id_queue = new List<string>();
        List<string> Select_id_learner = new List<string>();
        List<string> id_learner_impossible = new List<string>();
        string id_lab = "";
        string id_project = "";
        string id_s_l = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDropList();
                DropDownList3.Items.Insert(0, new ListItem("-Выберите проект-"));
            }
            int a = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                oraConnection.Open();
                CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
                if (cb != null && cb.Checked)
                {
                    oraAdap.SelectCommand = new OracleCommand();
                    oraAdap.SelectCommand.CommandText = "Select DISTINCT ID_LEARNER_Q FROM TECHNOPARK.QUEUE where TECHNOPARK.QUEUE.ID_LEARNER_Q = '" + GridView1.DataKeys[a].Values[0] + "'";
                    oraAdap.SelectCommand.Connection = oraConnection;
                    OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
                    while (oraReader.Read())
                    {
                        object[] values = new object[oraReader.FieldCount];
                        oraReader.GetValues(values);
                        id_learner.Add(values[0].ToString());
                    }

                    oraAdap.SelectCommand = new OracleCommand();
                    oraAdap.SelectCommand.CommandText = "Select * FROM TECHNOPARK.QUEUE where TECHNOPARK.QUEUE.ID_QUEUE = '" + GridView1.DataKeys[a].Values[1] + "'";
                    oraAdap.SelectCommand.Connection = oraConnection;
                    OracleDataReader oraReader1 = oraAdap.SelectCommand.ExecuteReader();
                    while (oraReader1.Read())
                    {
                        object[] values = new object[oraReader1.FieldCount];
                        oraReader1.GetValues(values);
                        id_queue.Add(values[0].ToString());
                    }
                }
                a += 1;
                oraConnection.Close();
            }
            GetId();
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

        public void GetId()
        {
            oraConnection.Open();
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "Select id_Laboratories from DIR_LABORATORIES where LABORATORY = '" + DropDownList2.SelectedValue.ToString() + "'";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                id_lab = values[0].ToString();
            }

            if (id_lab != "")
            {
                oraAdap.SelectCommand.CommandText = "Select ID_DIR_PROJECTS from DIR_PROJECTS where TITLE = '" + DropDownList3.SelectedValue.ToString() + "'";
                oraAdap.SelectCommand.Connection = oraConnection;
                OracleDataReader oraReader_1 = oraAdap.SelectCommand.ExecuteReader();
                while (oraReader_1.Read())
                {
                    object[] values = new object[oraReader_1.FieldCount];
                    oraReader_1.GetValues(values);
                    id_project = values[0].ToString();
                }
            }
            oraConnection.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            oraConnection.Open();
            if (this.IsPostBack)
            {
                string command = SqlDataSource1.SelectCommand;
                SqlDataSource1.SelectCommand = "SELECT LEARNER.ID_LEARNER, QUEUE.ID_QUEUE,  TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.DIR_PROJECTS.TITLE, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_STATUS_LEARNER.STATUS_L, TECHNOPARK.QUEUE.D_T_RECORD, TECHNOPARK.LEARNER.INTERESTS FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER  WHERE TECHNOPARK.DIR_LABORATORIES.LABORATORY = '" + DropDownList1.Text + "' order by TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.FIO";
                SqlDataSource1.DataBind();
                GridView1.DataBind();
            }

            if (DropDownList1.SelectedValue.ToString() == "-Выберите направление-")
            {
                PrintAllLearners();
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
                DropDownList1.Items.Insert(0, new ListItem("-Выберите направление-"));
                DropDownList1.SelectedIndex = 0;

                DropDownList2.DataSource = ds;
                DropDownList2.DataTextField = "Laboratory";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("-Выберите направление-"));
                DropDownList2.SelectedIndex = 0;
            }
            string s2 = "Select STATUS_L from DIR_STATUS_LEARNER";
            OracleDataAdapter oraAdap2 = new OracleDataAdapter(s2, oraConnection);
            oraAdap2.Fill(dss);
            if (dss.Tables[0].Rows.Count > 0)
            {
                DropDownList4.DataSource = dss;
                DropDownList4.DataBind();
                DropDownList4.Items.Insert(0, new ListItem("-Выберите статус-"));
                DropDownList4.SelectedIndex = 0;

                DropDownList5.DataSource = dss;
                DropDownList5.DataBind();
                DropDownList5.Items.Insert(0, new ListItem("-Выберите статус-"));
                DropDownList5.SelectedIndex = 0;
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
                DropDownList3.Items.Insert(0, new ListItem("-Выберите проект-"));
                DropDownList3.SelectedIndex = 0;
                oraConnection.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {   //Проверка проектанта на то,Свободен ли он сейчас или проходит обучение.
            //Response.Write(id_learner[0] + "<b></b><br/>");
            if (id_learner.Count == 1)
            {
                oraConnection.Open();
                oraAdap.SelectCommand = new OracleCommand();
                oraAdap.SelectCommand.CommandText = "Select * FROM TECHNOPARK.QUEUE where TECHNOPARK.QUEUE.ID_LEARNER_Q = '" + id_learner[0] + "' AND (ID_STATUS_L=5 OR ID_STATUS_L=6 OR ID_STATUS_L=7 OR ID_STATUS_L=9) and TECHNOPARK.QUEUE.Date_Registration = (Select max(Date_Registration) from QUEUE Q where Q.ID_LEARNER_Q=TECHNOPARK.QUEUE.ID_LEARNER_Q)";
                oraAdap.SelectCommand.Connection = oraConnection;
                OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
                while (oraReader.Read())
                {
                    object[] values = new object[oraReader.FieldCount];
                    oraReader.GetValues(values);
                    Select_id_learner.Add(values[1].ToString());
                }
                oraAdap.SelectCommand = new OracleCommand();
                oraAdap.SelectCommand.CommandText = "Select * FROM TECHNOPARK.QUEUE where TECHNOPARK.QUEUE.ID_LEARNER_Q = '" + id_learner[0] + "' AND (ID_STATUS_L=1 OR ID_STATUS_L=2 OR ID_STATUS_L=3 OR ID_STATUS_L=4 OR ID_STATUS_L=10) and TECHNOPARK.QUEUE.Date_Registration = (Select max(Date_Registration) from QUEUE Q where Q.ID_LEARNER_Q=TECHNOPARK.QUEUE.ID_LEARNER_Q)";
                oraAdap.SelectCommand.Connection = oraConnection;
                OracleDataReader oraReader1 = oraAdap.SelectCommand.ExecuteReader();
                while (oraReader1.Read())
                {
                    object[] values = new object[oraReader1.FieldCount];
                    oraReader1.GetValues(values);
                    id_learner_impossible.Add(values[1].ToString());
                }
                oraConnection.Close();
            }

            if (Select_id_learner.Count == 1 && id_learner_impossible.Count==0)
            {
                try
                {
                    using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                    {
                        oraConnection.Open();
                        string query_queue = "INSERT INTO TECHNOPARK.QUEUE (ID_Learner_Q, DATE_REGISTRATION, ID_LABORATORIES, ID_PROJECT, ID_STATUS_L) VALUES('" + id_learner[0] + "','" + DateTime.Parse(TextBox2.Text).ToShortDateString() + "', '" + id_lab + "' , '" + id_project + "', 1)";
                        oraAdap.InsertCommand = new OracleCommand(query_queue, oraConnection);
                        oraAdap.InsertCommand.ExecuteNonQuery();
                        GridView1.DataBind();
                        oraConnection.Close();
                        Label13.Visible = true;
                        Label13.ForeColor = System.Drawing.Color.Green;
                        Label13.Text = "Данные успешно добавлены!";
                    }

                }
                catch
                {
                    Label13.Text = "Проверьте введенные данные!";
                    Label13.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                Label13.Text = "Проверьте данные проектанта!";
                Label13.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void PrintAllLearners()
        {
            SqlDataSource1.SelectCommand = "SELECT LEARNER.ID_LEARNER, QUEUE.ID_QUEUE,  TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.DIR_PROJECTS.TITLE, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_STATUS_LEARNER.STATUS_L, TECHNOPARK.QUEUE.D_T_RECORD, TECHNOPARK.LEARNER.INTERESTS FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER order by TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.FIO";
            SqlDataSource1.DataBind();
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            oraConnection.Open();
            if (this.IsPostBack)
            {
                string command = SqlDataSource1.SelectCommand;
                SqlDataSource1.SelectCommand = "SELECT LEARNER.ID_LEARNER, QUEUE.ID_QUEUE,  TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.DIR_PROJECTS.TITLE, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_STATUS_LEARNER.STATUS_L, TECHNOPARK.QUEUE.D_T_RECORD, TECHNOPARK.LEARNER.INTERESTS FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER  WHERE (TECHNOPARK.LEARNER.FIO LIKE '%" + TextBox1.Text + "%') order by TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.FIO";
                SqlDataSource1.DataBind();
                GridView1.DataBind();
            }
            oraConnection.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            oraConnection.Open();

            string command = SqlDataSource1.SelectCommand;
            SqlDataSource1.SelectCommand = "SELECT LEARNER.ID_LEARNER, QUEUE.ID_QUEUE,  TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.DIR_PROJECTS.TITLE, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_STATUS_LEARNER.STATUS_L, TECHNOPARK.QUEUE.D_T_RECORD, TECHNOPARK.LEARNER.INTERESTS FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER  WHERE TECHNOPARK.DIR_STATUS_LEARNER.STATUS_L = '" + DropDownList4.Text + "' order by TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.FIO";
            SqlDataSource1.DataBind();
            GridView1.DataBind();

            if (DropDownList4.SelectedValue.ToString() == "-Выберите статус-")
            {
                PrintAllLearners();
            }
            oraConnection.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            oraConnection.Open();
            PrintAllLearners();
            oraConnection.Close();
        }
        public void GetId_S_L()
        {
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "Select ID_DIR_STATUS_LEARNER from DIR_STATUS_LEARNER where STATUS_L = '" + DropDownList5.SelectedValue.ToString() + "'";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                id_s_l = values[0].ToString();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            oraConnection.Open();
            GetId_S_L();
            int s = 0;
            foreach (string i in id_queue)
            {
                try
                {
                    using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                    {
                        string query_update_q = "Update TECHNOPARK.QUEUE SET ID_STATUS_L = '" + id_s_l + "' WHERE ID_QUEUE = '" + id_queue[s] + "' ";
                        oraAdap.UpdateCommand = new OracleCommand(query_update_q, oraConnection);
                        oraAdap.UpdateCommand.ExecuteNonQuery();
                        GridView1.DataBind();
                    }
                    Label9.Visible = true;
                    Label9.ForeColor = System.Drawing.Color.Green;
                    Label9.Text = "Данные проектана успешно обновлены!";
                }
                catch
                {
                    Label9.Visible = true;
                    Label9.Text = "Проверьте введенные данные!";
                }
                s += 1;
            }
            oraConnection.Close();
        }
    }
}