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

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetDropList();
                DropDownList2.Items.Insert(0, new ListItem("-Выберете проект-"));
            }

            //if (!Page.IsPostBack)
            //{
            //    for (int i = 3; i <= 5; i++)
            //    {
            //        ListBox1.Items.Add("Option " + i.ToString());
            //    }
            //}
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
           // string interests_v = "";
           //// Response.Write("<b>Выбранные элементы в Listbox1:</b><br/>");
           // foreach (ListItem li in ListBox1.Items)
           // {
           //     if (li.Selected)
           //     {
           //         interests_v +=  li.Value + " ";
           //     }
           // }
           // //Response.Write("- " + msg + "<br/>");

           // try
           // {
           //     using (OracleConnection oraclelcon = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;"))
           //     {
           //         oraConnection.Open();
           //         string query = "INSERT INTO TECHNOPARK.LEARNER (FIO, CLASS, BIRTHDAY, SCHOOL, PHONE, SHIFT, E_MAIL, INTERESTS, COMMENTS)  VALUES('" + TextBoxFirst.Text + "', '" + DropDownList4.Text + "', '" + DateTime.Parse(TextBox4.Text).ToShortDateString() + "', '" + TextBox3.Text + "', '" + TextBox5.Text + "', '" + DropDownList5.Text + "', '" + TextBoxFirst.Text + "', '" + interests_v + "', '" + TextBoxFirst.Text + "')";
           //         oraAdap.InsertCommand = new OracleCommand(query, oraConnection);
           //         oraAdap.InsertCommand.ExecuteNonQuery();
           //         oraConnection.Close();
           //         Label1.Visible = true;
           //         Label1.ForeColor = System.Drawing.Color.Green;
           //         Label1.Text = "Данные успешно добавлены!";
           //     }
           // }
           // catch
           // {
           //     Label1.Visible = true;
           //     Label1.Text = "Проверьте введенные данные!";
           // }
        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {
            
            
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
                DropDownList2.Items.Insert(0, new ListItem("-Выберете проект-"));
                DropDownList2.SelectedIndex = 0;
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
                DropDownList1.Items.Insert(0, new ListItem("-Выберете направление-"));
                DropDownList1.SelectedIndex = 0;
            }
        }
    }
}

