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
        string id_teacher = "";
        string id_gr_title = "";
        string Title_Group;
        //string List_L_proj = "";
        List<string> textBox_f = new List<string>();
        List<string> List_pr = new List<string>();
        List<string> List_npr = new List<string>();
        List<string> List_L_proj = new List<string>();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            int a = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                oraConnection.Open();
                CheckBox cb = (CheckBox)row.FindControl("SelectLearner");
                if (cb != null && cb.Checked)
                {
                    Label1.Visible = false;
                    
                    //string query = " Select TECHNOPARK.LEARNER.ID_LEARNER  FROM   TECHNOPARK.LEARNER INNER JOIN  TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN  TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 2) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 6) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 7) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 8) ID_LEARNER=:ID_LEARNER and FIO = '" + row.Cells[2].Text +"' ";
                    //OracleCommand oraclecmd = new OracleCommand(query, oraConnection);
                    //Response.Write(row.Cells[1].Text + "<b>qwqwq</b><br/>");  
                    oraAdap.SelectCommand = new OracleCommand();
                    oraAdap.SelectCommand.CommandText = "Select * FROM  TECHNOPARK.LEARNER where TECHNOPARK.Learner.ID_LEARNER = '"+ GridView1.DataKeys[a].Values[0] +"'";
                    oraAdap.SelectCommand.Connection = oraConnection;
                    OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
                    while (oraReader.Read())
                    {
                        object[] values = new object[oraReader.FieldCount];
                        oraReader.GetValues(values);
                        textBox_f.Add(values[0].ToString());
                    }
                           
                }
                a += 1;
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
            GetId();
            GetTitleGroup();
        }

        private void GetInfLearner()
        {
            //oraAdap.SelectCommand = new OracleCommand();
            //oraAdap.SelectCommand.CommandText = "SELECT * FROM TECHNOPARK.queue WHERE ID_STATUS_L = 2";
            //oraAdap.SelectCommand.Connection = oraConnection;
            //OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            //while (oraReader.Read())
            //{
            //    object[] values = new object[oraReader.FieldCount];
            //    oraReader.GetValues(values);
            //    List_L_proj.Add(values[1].ToString());
            //}
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
            SqlDataSource2.SelectCommand = "SELECT TECHNOPARK.LEARNER.ID_LEARNER, TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL,  TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_PROJECTS.TITLE FROM     TECHNOPARK.LEARNER INNER JOIN  TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN  TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 2) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 6) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 7) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 8) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 10) and ID_LEARNER!=0";
            SqlDataSource2.DataBind();
            GridView1.DataBind();
            //oraConnection.Close();
            Label9.Visible = true;
            Label9.Text = "Весь список обучающихся";
        }

        private void LearnerLab ()
        {
            string command = SqlDataSource2.SelectCommand;
            SqlDataSource2.SelectCommand = "SELECT TECHNOPARK.LEARNER.ID_LEARNER, TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL,  TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_PROJECTS.TITLE FROM     TECHNOPARK.LEARNER INNER JOIN  TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN  TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 2) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 6) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 7) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 8) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 10) and TECHNOPARK.DIR_LABORATORIES.LABORATORY = '" + DropDownList2.Text + "' and ID_LEARNER!=0";
            SqlDataSource2.DataBind();
            GridView1.DataBind();
            //oraConnection.Close();
            Label9.Visible = true;
            Label9.Text = "Список обучающихся по выбранному проекту";
        }

        private void LearnerLabInteres ()
        {
            string command = SqlDataSource2.SelectCommand;
            SqlDataSource2.SelectCommand = "SELECT TECHNOPARK.LEARNER.ID_LEARNER, TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL,  TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_PROJECTS.TITLE FROM     TECHNOPARK.LEARNER INNER JOIN  TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN  TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN  TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 2) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 6) AND(TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 7) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 8) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER <> 10) and ID_LEARNER !=0 and TECHNOPARK.LEARNER.INTERESTS LIKE '%" + DropDownList2.Text + "%' or TECHNOPARK.DIR_LABORATORIES.LABORATORY = '" + DropDownList2.Text + "' ";
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

            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "SELECT ID_EMPLOYEES FROM TECHNOPARK.EMPLOYEES WHERE (POSITION = 2) and fio = '" + DropDownList1.SelectedValue.ToString() + "'";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader_2 = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader_2.Read())
            {
                object[] values = new object[oraReader_2.FieldCount];
                oraReader_2.GetValues(values);
                id_teacher = values[0].ToString();
            }
            oraConnection.Close();
        }

        public void GetTitleGroup()
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            oraConnection.Open();
            //Response.Write(i + "<b>tut</b><br/>");
            //Label1.Visible = true;
            int s = 0;
            int c_p = 0;
            int c_np = 0;
            int error = 0;

            if (DropDownList2.Text != "-Выберете направление-" && DropDownList3.Text != "-Выберете проект-")
            {
              
                foreach (string i in textBox_f)
                {
                   
                    oraAdap.SelectCommand = new OracleCommand();
                    //Response.Write(textBox_f[s] + "<b></b><br/>");
                    oraAdap.SelectCommand.CommandText = "SELECT TECHNOPARK.LEARNER.ID_LEARNER, TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_PROJECTS.TITLE FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER = 1) AND TECHNOPARK.DIR_LABORATORIES.LABORATORY = '" + DropDownList2.Text + "' and TECHNOPARK.Learner.ID_LEARNER = '" + textBox_f[s] + "'";
                    oraAdap.SelectCommand.Connection = oraConnection;
                    OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
                    while (oraReader.Read())
                    {
                        object[] values = new object[oraReader.FieldCount];
                        oraReader.GetValues(values);
                        List_pr.Add(values[0].ToString());
                       // Response.Write("1 -" + values[0] + "<b></b><br/>");
                    }

                    oraAdap.SelectCommand = new OracleCommand();
                    oraAdap.SelectCommand.CommandText = "SELECT TECHNOPARK.LEARNER.ID_LEARNER, TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_PROJECTS.TITLE FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER = 1) AND TECHNOPARK.DIR_LABORATORIES.LABORATORY <> '" + DropDownList2.Text + "' AND TECHNOPARK.Learner.ID_LEARNER = '" + textBox_f[s] + "'";
                    oraAdap.SelectCommand.Connection = oraConnection;
                    OracleDataReader oraReader_1 = oraAdap.SelectCommand.ExecuteReader();
                    while (oraReader_1.Read())
                    {
                        object[] values = new object[oraReader_1.FieldCount];
                        oraReader_1.GetValues(values);
                        List_npr.Add(values[0].ToString());
                        //Response.Write("2 -" + values[0] + "<b></b><br/>");
                    }
                    s += 1;
                }
            }

            else
            {
                error += 1;
            }

            if (List_pr.Count == 0 && List_npr.Count == 0)
            {
                error += 1;
            }

                if (List_pr.Count != 0 || List_npr.Count != 0)
            {
                oraAdap.SelectCommand = new OracleCommand();
                oraAdap.SelectCommand.CommandText = "Select SEQ_GR.NEXTVAL from dual";
                oraAdap.SelectCommand.Connection = oraConnection;
                OracleDataReader oraReader_3 = oraAdap.SelectCommand.ExecuteReader();
                while (oraReader_3.Read())
                {
                    object[] values = new object[oraReader_3.FieldCount];
                    oraReader_3.GetValues(values);
                    id_gr_title = values[0].ToString();
                }
                if (id_lab != "")
                {
                    //Response.Write(id_lab + "<b> проект</b><br/>" + id_project);
                    Title_Group = id_lab + "_" + DateTime.Today.ToString("dd.MM") + "_" + id_project + "." + id_gr_title;
                }
            }

            foreach (string i in List_pr)
            {
                if (List_pr.Count != 0)
                {
                    //Response.Write(List_pr[c_p] + "<b>butЗаписан на тот же прокет</b><br/>");
                    try
                    {
                        using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                        {
                            //oraConnection.Open();
                            string query_update = "Update TECHNOPARK.QUEUE SET ID_STATUS_L = 2, TITLE_G= '" + Title_Group + "' WHERE ID_LEARNER_Q = '" + List_pr[c_p] + "'";
                            oraAdap.UpdateCommand = new OracleCommand(query_update, oraConnection);
                            oraAdap.UpdateCommand.ExecuteNonQuery();
                            //oraConnection.Close();
                           // Response.Write( "<b>Обновили</b><br/>");
                        }
                    }
                    catch
                    {
                        error += 1;
                    }

                }
                c_p += 1;
            }

            foreach (string i in List_npr)
            {
                if (List_npr.Count != 0)
                {
                    Response.Write(List_npr[c_np] + "<b>Записан на другой проект</b><br/>");
                    try
                    {
                        using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                        {
                            
                           // oraConnection.Open();
                            string query_insert = "INSERT INTO TECHNOPARK.QUEUE (ID_LEARNER_Q, DATE_REGISTRATION, ID_LABORATORIES, ID_PROJECT, ID_STATUS_L, TITLE_G) VALUES('" + List_npr[c_np] + "' , '" + DateTime.Today.ToShortDateString() + "', '" + id_lab + "', '" + id_project + "', 2 , '" + Title_Group + "' )";
                            oraAdap.InsertCommand = new OracleCommand(query_insert, oraConnection);
                            oraAdap.InsertCommand.ExecuteNonQuery();
                            string query_update_q = "Update TECHNOPARK.QUEUE SET ID_STATUS_L = 10 WHERE ID_LEARNER_Q = '" + List_npr[c_np] + "' and  ID_STATUS_L=1";
                            oraAdap.UpdateCommand = new OracleCommand(query_update_q, oraConnection);
                            oraAdap.UpdateCommand.ExecuteNonQuery();
                           // Response.Write("<b>Добавили</b><br/>");
                            // oraConnection.Close();
                        }
                    }
                    catch
                    {
                        error += 1;
                    }

                }
                c_np += 1; 
            }

            if (error>0)
            {
                Label1.Visible = true;
                Label1.Text = "Проверьте введенные данные!";
            }
            if (error == 0)
            {
                try
                {
                    using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                    {

                        // oraConnection.Open();
                        string query_insert = "INSERT INTO TECHNOPARK.GROUPS (ID_EMPLOYEES, ID_PROJECT, TITLE, PROJECT_THEME, TIME_CLASS, STATUS) VALUES('" + id_teacher + "', + '" + id_project + "' , '" + Title_Group + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', 1 )";
                        oraAdap.InsertCommand = new OracleCommand(query_insert, oraConnection);
                        oraAdap.InsertCommand.ExecuteNonQuery();
                        // oraConnection.Close();
                    }
                    Label1.Visible = true;
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "Данные успешно добавлены! Шифр группы-" + Title_Group;
                    GridView1.DataBind();
                }
                catch
                {
                    Label1.Visible = true;
                    Label1.Text = "Проверьте введенные данные!";
                }
               
            }

            //Response.Write(Title_Group + "<b>- Шифр</b><br/>");
            oraConnection.Close();

        }

    }
}