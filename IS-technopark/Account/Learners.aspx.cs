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
    public partial class Learners : System.Web.UI.Page
    {
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataSet ds = new DataSet();
        string id_lab = "";
        string id_project = "";
        string max_id_learner = "";
        int error = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetDropList();
                DropDownList2.Items.Insert(0, new ListItem("-Выберите проект-"));
            }
            ID();
        }
        public void ID()
        {
            oraConnection.Open();
            oraAdap.SelectCommand = new OracleCommand();
            oraAdap.SelectCommand.CommandText = "Select id_Laboratories from DIR_LABORATORIES where LABORATORY = '" + DropDownList1.SelectedValue.ToString() + "'";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader.Read())
            {
                object[] values = new object[oraReader.FieldCount];
                oraReader.GetValues(values);
                id_lab = values[0].ToString();
            }

            oraAdap.SelectCommand.CommandText = "Select ID_DIR_PROJECTS from DIR_PROJECTS where TITLE = '" + DropDownList2.SelectedValue.ToString() + "'";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader_1 = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader_1.Read())
            {
                object[] values = new object[oraReader_1.FieldCount];
                oraReader_1.GetValues(values);
                id_project = values[0].ToString();
            }

            oraAdap.SelectCommand.CommandText = "select max(id_learner) from LEARNER";
            oraAdap.SelectCommand.Connection = oraConnection;
            OracleDataReader oraReader_2 = oraAdap.SelectCommand.ExecuteReader();
            while (oraReader_2.Read())
            {
                object[] values = new object[oraReader_2.FieldCount];
                oraReader_2.GetValues(values);
                max_id_learner = values[0].ToString();
            }

            oraConnection.Close();
            //Response.Write("- " + id_lab + "<br/>" + id_project);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string interests_v = "";
            // Response.Write("<b>Выбранные элементы в Listbox1:</b><br/>");
            foreach (ListItem li in ListBox1.Items)
            {
                if (li.Selected)
                {
                    interests_v += li.Value + " ";
                }
            }
            //Response.Write("- " + msg + "<br/>");
            try
            {
                using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                {
                    oraConnection.Open();
                    string query = "INSERT INTO TECHNOPARK.LEARNER (FIO, BIRTHDAY, CLASS, SCHOOL, SHIFT, PHONE, E_MAIL, INTERESTS, COMMENTS) VALUES('" + TextBoxFirst.Text + "', '" + DateTime.Parse(TextBox4.Text).ToShortDateString() + "' , '" + DropDownList4.Text + "','" + TextBox3.Text + "', '" + DropDownList5.Text + "', '" + TextBox5.Text + "', '" + TextBox6.Text + "', '" + interests_v + "', '" + TextBox16.Text + "')";
                    // string query_queue = "INSERT INTO TECHNOPARK.QUEUE (DATE_REGISTRATION, ID_LABORATORIES, ID_PROJECT, STATUS) VALUES('" + TextBox7.Text + "', '" + id_lab + "' , '" + id_project + "','" + DropDownList3.Text + "')";
                    // string query_parent = "INSERT INTO TECHNOPARK.PARENT (FIO, PHONE, PHONE_WORK, E_MAIL, PLACE_WORK, POSITION) VALUES('" + TextBox8.Text + "', '" + TextBox11.Text + "' , '" + TextBox12.Text + "','" + TextBox13.Text + "', '" + TextBox14.Text + "', '" + TextBox15.Text + "')";
                    oraAdap.InsertCommand = new OracleCommand(query, oraConnection);
                    // oraAdap.InsertCommand = new OracleCommand(query_parent, oraConnection);
                    //oraAdap.InsertCommand = new OracleCommand(query_queue, oraConnection);
                    oraAdap.InsertCommand.ExecuteNonQuery();
                    oraConnection.Close();
                    //Label1.Visible = true;
                    //Label1.ForeColor = System.Drawing.Color.Green;
                    //Label1.Text = "Данные успешно добавлены!";
                }
                ID();
                using (OracleConnection oraclelcon1 = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                {
                    oraConnection.Open();
                    //string query = "INSERT INTO TECHNOPARK.LEARNER (FIO, BIRTHDAY, CLASS, SCHOOL, SHIFT, PHONE, E_MAIL, INTERESTS, COMMENTS) VALUES('" + TextBoxFirst.Text + "', '" + DateTime.Parse(TextBox4.Text).ToShortDateString() + "' , '" + DropDownList4.Text + "','" + TextBox3.Text + "', '" + DropDownList5.Text + "', '" + TextBox5.Text + "', '" + TextBox6.Text + "', '" + interests_v + "', '" + TextBox16.Text + "')";
                    // string query_queue = "INSERT INTO TECHNOPARK.QUEUE (DATE_REGISTRATION, ID_LABORATORIES, ID_PROJECT, STATUS) VALUES('" + TextBox7.Text + "', '" + id_lab + "' , '" + id_project + "','" + DropDownList3.Text + "')";
                    string query_parent = "INSERT INTO TECHNOPARK.PARENT (ID_Learner_p, FIO, PHONE, PHONE_WORK, E_MAIL, PLACE_WORK, POSITION) VALUES('" + max_id_learner + "','" + TextBox8.Text + "', '" + TextBox11.Text + "' , '" + TextBox12.Text + "','" + TextBox13.Text + "', '" + TextBox14.Text + "', '" + TextBox15.Text + "')";
                    //oraAdap.InsertCommand = new OracleCommand(query, oraConnection);
                    oraAdap.InsertCommand = new OracleCommand(query_parent, oraConnection);
                    oraAdap.InsertCommand.ExecuteNonQuery();
                    oraConnection.Close();
                    //Label1.Visible = true;
                    //Label1.ForeColor = System.Drawing.Color.Green;                DropDownList1.Items.Insert(0, new ListItem("-
                    //Label1.Text = "Данные успешно добавлены!";
                }

                using (OracleConnection oraclelcon2 = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
                {
                    oraConnection.Open();
                    //string query = "INSERT INTO TECHNOPARK.LEARNER (FIO, BIRTHDAY, CLASS, SCHOOL, SHIFT, PHONE, E_MAIL, INTERESTS, COMMENTS) VALUES('" + TextBoxFirst.Text + "', '" + DateTime.Parse(TextBox4.Text).ToShortDateString() + "' , '" + DropDownList4.Text + "','" + TextBox3.Text + "', '" + DropDownList5.Text + "', '" + TextBox5.Text + "', '" + TextBox6.Text + "', '" + interests_v + "', '" + TextBox16.Text + "')";
                    string query_queue = "INSERT INTO TECHNOPARK.QUEUE (ID_Learner_Q, DATE_REGISTRATION, ID_LABORATORIES, ID_PROJECT, ID_STATUS_L) VALUES('" + max_id_learner + "','" + DateTime.Parse(TextBox7.Text).ToShortDateString() + "', '" + id_lab + "' , '" + id_project + "', 1)";
                    // string query_parent = "INSERT INTO TECHNOPARK.PARENT (FIO, PHONE, PHONE_WORK, E_MAIL, PLACE_WORK, POSITION) VALUES('" + TextBox8.Text + "', '" + TextBox11.Text + "' , '" + TextBox12.Text + "','" + TextBox13.Text + "', '" + TextBox14.Text + "', '" + TextBox15.Text + "')";
                    //oraAdap.InsertCommand = new OracleCommand(query, oraConnection);
                    oraAdap.InsertCommand = new OracleCommand(query_queue, oraConnection);
                    oraAdap.InsertCommand.ExecuteNonQuery();
                    oraConnection.Close();
                }
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Green;
                Label1.Text = "Данные успешно добавлены!";
            }
            catch
            {

                Label1.Visible = true;
                Label1.Text = "Проверьте введенные данные!";
            }
            
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.ToString() != "0")
            {
                oraConnection.Open();
                string s1 = "Select Title from DIR_PROJECTS WHERE id_Laboratory = ( Select id_Laboratories from DIR_LABORATORIES where LABORATORY = '" + DropDownList1.SelectedValue.ToString() + "')";
                OracleDataAdapter oraAdap = new OracleDataAdapter(s1, oraConnection);
                oraAdap.Fill(ds);
                DropDownList2.DataSource = ds;
                DropDownList2.DataTextField = "Title";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("-Выберите проект-"));
                DropDownList2.SelectedIndex = 0;
                oraConnection.Close();
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
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "Laboratory";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("-Выберите направление-"));
                DropDownList1.SelectedIndex = 0;
            }
            oraConnection.Close();
        }
    }
}

