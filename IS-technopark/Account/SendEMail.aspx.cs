using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace IS_technopark.Account
{
    public partial class SendEMail : System.Web.UI.Page
    {
        List<string> e_mail_to = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                e_mail_to.Add("Dasytka--0912@mail.ru");
                e_mail_to.Add("seer.92@mail.ru");
                string from = txtFrom.Text.Trim();
                string to = txtTo.Text.Trim();
                string subject = txtSubject.Text.Trim();
                string message = txtMessage.Text.Trim();

                //SmtpClient objSmtpClient = new SmtpClient();
                //objSmtpClient.Host = "localhost";
                //objSmtpClient.Port = 465;
                //objSmtpClient.Send(from, to, subject, message);

                //lblStatus.Text = "<b style='color:green'>Email has been sent successfully!!!</b>";
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
                        lblStatus.Text = "<b style='color:green'>Email has been sent successfully!!!</b>";
                    }
                    s += 1;
                }
                
            }
            catch (SmtpException ex) { lblStatus.Text = "<b style='color:red'>" + ex.Message + "</b>"; }
        }
    }
}