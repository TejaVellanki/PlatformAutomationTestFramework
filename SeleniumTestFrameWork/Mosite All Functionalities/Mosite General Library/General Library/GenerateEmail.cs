﻿using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MoBankUI
{
    internal class GenerateEmail
    {
        public void SendEMail(string ReportName, string emails)
        {
            try
            {
                //Mail Message
                var mM = new MailMessage();
                //Mail Address
                mM.From = new MailAddress("admin@mobankgroup.com");
                //receiver email id
                //  mM.To.Add("tvellanki@gmail.com");
                try
                {
                    string[] email = emails.Split(',');
                    foreach (string emal in email)
                    {
                        mM.To.Add(emal);
                    }
                }
                catch (Exception ex)
                {
                }
                // mM.To.Add("ben.west@mobankgroup.com");  
                mM.To.Add("teja.vellanki@mobankgroup.com");
                //subject of the email
                mM.Subject = "Test Report";
                //deciding for the attachment
                mM.Attachments.Add(new Attachment(@"C:\\Input Data\" + ReportName + ".xlsx"));
                //add the body of the email

                var mailBody = new StringBuilder();

                mailBody.AppendFormat("<h1>MoPowered</h1>");
                mailBody.AppendFormat("Dear Sir/Madam,");
                mailBody.AppendFormat("<br />");
                mailBody.AppendFormat(
                    "<p>An Automation Test has been processed.Please find the Excel workbook attached for the Test Results</p>");
                mailBody.AppendFormat("<br />");
                mailBody.AppendFormat("<p>Thank You</p>");
                mailBody.AppendFormat("<br />");
                mailBody.AppendFormat("<p></p>");

                mM.Body = mailBody.ToString();
                //mM.Body = mailBody.ToString();
                mM.IsBodyHtml = true;
                //SMTP client
                var sC = new SmtpClient("smtp.gmail.com");
                //port number for Gmail mail
                sC.Port = 587;
                //credentials to login in to Gmail account
                sC.Credentials = new NetworkCredential("teja.vellanki@mobankgroup.com", "Apple12345");
                //enabled SSL
                sC.EnableSsl = true;
                //Send an email
                sC.Send(mM);

                //Mail Message
            } //end of try block

            catch (Exception ex)
            {
                Console.Write(ex);
            } //end of catch
        }
    }
}