using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Threading.Tasks;

namespace IS_technopark.Account
{
    public partial class SendEMail : System.Web.UI.Page
    {
        OracleDataAdapter oraAdap = new OracleDataAdapter();
        OracleConnection oraConnection = new OracleConnection("Data Source =127.0.0.1:1521/xe; User ID =Technopark;  password = DIP1937;");
        DataTable table = new DataTable();
        DataSet ds = new DataSet();
        List<string> e_mail_to = new List<string>();
        int LabekMessag = 0;
        int email = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDropList();
            }

            if (txtTo.Text.Trim() != "" || DropDownList1.SelectedValue.ToString() != "-Выберите направление-")
            {
                Class_FIO.email_learner.Clear();
                Label8.Visible = false;
                Label1.Visible = false;
            }

            if (Class_FIO.email_learner.Count > 0)
            {
                Label8.Visible = true;
                Label1.Visible = true;
               // Label1.Text = "Количество почтовых ящиков: " + Class_FIO.email_learner.Count.ToString();
            }
 
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if ((sender as Button) == null)
                return;
            
                sendonemail();
                txtTo.Text = String.Empty;
            //if (email == 1)
            //{
            //    var t = Task.Run(async delegate
            //    {
            //        Response.Write("<script>alert('Сообщение успешно отправлено!')</script>");
            //        await Task.Delay(5000);
            //        return 42;
            //    });
            //    t.Wait();
            //    Response.Redirect("SendEMail");
            //}

            // Response.Redirect("SendEMail.aspx"); //Перенаправлять или чистить

        }

        private void sendonemail()
        {
            
            string to = "";
            string from = "schooltechn.yourname@gmail.com";
            to = txtTo.Text.Trim();
            string subject = txtSubject.Text.Trim();
            string message = txtMessage.Text.Trim();
            try
            {
                if (DropDownList1.SelectedValue.ToString() == "-Выберите направление-" && to != "")
                {
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetCred = new NetworkCredential("schooltechn.yourname@gmail.com", "SchoolTechn1");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetCred;
                        smtp.Port = 587;
                        smtp.Send(from, to, subject, message);
                        Response.Write("<script>alert('Сообщение успешно отправлено!')</script>");
                        //lblStatus.Text = "<b style='color:green'>Сообщение успешно отправлено!</b>";
                        to = "";
                        smtp.Dispose();
                    }
                    email = 1;
                }
                EmailLaboratory();
                if (e_mail_to.Count != 0)
                {

                    int s = 0;
                    foreach (string i in e_mail_to)
                    {
                        using (SmtpClient smtp = new SmtpClient())
                        {
                            smtp.Host = "smtp.gmail.com";
                            smtp.EnableSsl = true;
                            NetworkCredential NetCred = new NetworkCredential("schooltechn.yourname@gmail.com", "SchoolTechn1");
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = NetCred;
                            smtp.Port = 587;
                            smtp.Send(from, e_mail_to[s], subject, message);
                            Response.Write("<script>alert('Сообщение успешно отправлено!')</script>");
                            //lblStatus.Text = "<b style='color:green'>Сообщение успешно отправлено!</b>";
                            //smtp.Dispose();
                        }
                        s += 1;
                    }
                    email = 1;
                }
                    LabekMessag = 1;
                if (Class_FIO.email_learner.Count>0)
                {
                    int s = 0;
                    foreach (string i in Class_FIO.email_learner)
                    {
                        using (SmtpClient smtp = new SmtpClient())
                        {
                            smtp.Host = "smtp.gmail.com";
                            smtp.EnableSsl = true;
                            NetworkCredential NetCred = new NetworkCredential("schooltechn.yourname@gmail.com", "SchoolTechn1");
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = NetCred;
                            smtp.Port = 587;
                            smtp.Send(from, Class_FIO.email_learner[s], subject, message);
                            Response.Write("<script>alert('Сообщение успешно отправлено!')</script>");
                            // lblStatus.Text = "<b style='color:green'>Сообщение успешно отправлено!</b>";
                            //smtp.Dispose();
                        }
                        s += 1;
                    }
                    email = 1;
                }
               
            }
            catch (SmtpException ex) { lblStatus.Text = "<b style='color:red'>" + ex.Message + "</b>"; }
            txtMessage.Text = "";
            txtSubject.Text = "";
            txtTo.Text = "";
            to = "";
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

        private void EmailLaboratory()
        {
            if (DropDownList1.SelectedValue.ToString() != "-Выберите направление-")
            {
                oraConnection.Open();
                oraAdap.SelectCommand = new OracleCommand();
                oraAdap.SelectCommand.CommandText = "select Parent.e_mail, LEARNER.E_MAIL from parent, queue, DIR_LABORATORIES, LEARNER where parent.ID_LEARNER_P=LEARNER.ID_LEARNER and parent.ID_LEARNER_P=queue.ID_LEARNER_Q  AND DIR_LABORATORIES.ID_LABORATORIES = queue.ID_LABORATORIES and (parent.E_MAIL is not null or Learner.E_MAIL is not null) and DIR_LABORATORIES.LABORATORY = '" + DropDownList1.SelectedValue.ToString() + "'";
                oraAdap.SelectCommand.Connection = oraConnection;
                OracleDataReader oraReader = oraAdap.SelectCommand.ExecuteReader();
                while (oraReader.Read())
                {
                    object[] values = new object[oraReader.FieldCount];
                    oraReader.GetValues(values);
                    if (values[0].ToString() != "")
                    {
                        e_mail_to.Add(values[0].ToString());
                    }
                }

                int s = 0;
                for (int y = 0; y < e_mail_to.Count ; y++)
                {
                    for (int i = 0; i < e_mail_to.Count-1; i++)
                    {
                        oraAdap.SelectCommand = new OracleCommand();
                        oraAdap.SelectCommand.CommandText = "select Parent.e_mail, LEARNER.E_MAIL from parent, queue, DIR_LABORATORIES, LEARNER where parent.ID_LEARNER_P=LEARNER.ID_LEARNER and parent.ID_LEARNER_P=queue.ID_LEARNER_Q  AND DIR_LABORATORIES.ID_LABORATORIES = queue.ID_LABORATORIES and (parent.E_MAIL is not null or Learner.E_MAIL is not null) and DIR_LABORATORIES.LABORATORY = '" + DropDownList1.SelectedValue.ToString() + "'";
                        oraAdap.SelectCommand.Connection = oraConnection;
                        OracleDataReader oraReader1 = oraAdap.SelectCommand.ExecuteReader();
                        while (oraReader1.Read())
                        {
                            object[] values = new object[oraReader1.FieldCount];
                            oraReader1.GetValues(values);
                            if (e_mail_to[s] != values[1].ToString() && values[1].ToString()!="")
                            {
                                e_mail_to.Add(values[1].ToString());
                            }
                        }
                    }
                }
                if (e_mail_to.Count == 0)
                {
                    oraAdap.SelectCommand = new OracleCommand();
                    oraAdap.SelectCommand.CommandText = "select Parent.e_mail, LEARNER.E_MAIL from parent, queue, DIR_LABORATORIES, LEARNER where parent.ID_LEARNER_P=LEARNER.ID_LEARNER and parent.ID_LEARNER_P=queue.ID_LEARNER_Q  AND DIR_LABORATORIES.ID_LABORATORIES = queue.ID_LABORATORIES and (parent.E_MAIL is not null or Learner.E_MAIL is not null) and DIR_LABORATORIES.LABORATORY = '" + DropDownList1.SelectedValue.ToString() + "'";
                    oraAdap.SelectCommand.Connection = oraConnection;
                    OracleDataReader oraReader1 = oraAdap.SelectCommand.ExecuteReader();
                    while (oraReader1.Read())
                    {
                        object[] values = new object[oraReader1.FieldCount];
                        oraReader1.GetValues(values);
                        if (values[1].ToString() != "")
                        {
                            e_mail_to.Add(values[1].ToString());
                        }
                    }
                }
                s += 1;
                //txtTo.Text = e_mail_to.ToString();
                oraConnection.Close();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmailLaboratory();
            if (DropDownList1.SelectedValue.ToString() != "0")
            {
                Label7.Text = "Количество почтовых ящиков: " + e_mail_to.Count;
            }
        }
    }
}