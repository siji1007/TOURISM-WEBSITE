using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;



namespace TOURISM_WEBSITE.Pages
{
    public class ContactModel : PageModel
    {
        public class ClientInfo
        {
            public string fullname { get; set; }
            public string email { get; set; }
            public string message { get; set; }
        }

        [BindProperty]
        public ClientInfo clientInfo { get; set; }
        public bool IsSubmissionSuccessful { get; private set; } = false;

        public String errorMessage = "";

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Console.WriteLine("Data Inserted Successfully!");
                    Console.WriteLine($"FullName: {clientInfo.fullname}");
                    Console.WriteLine($"Email: {clientInfo.email}");
                    Console.WriteLine($"Message: {clientInfo.message}");


                    Console.Out.Flush();
                    IsSubmissionSuccessful = true;



                    InsertDataIntoDatabase();
                    SendEmail();


                    ModelState.Clear();


                    return Page();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.ToString());
                    errorMessage = ex.Message;
                    IsSubmissionSuccessful = false;
                }
            }


            return Page();

        }

        private void SendEmail()
        {
            try
            {
                // Email configuration
                string emailSender = "smartcook23@gmail.com";
                string emailPassword = "asflajdmsabuomwh";
                string emailReceiver = clientInfo.email.ToLower();
                string subject = "FEEDBACK FROM USER!";
                string body = $"Hello {clientInfo.fullname.ToUpper()} , thank you for getting in touch. We truly appreciate your feedback.";



                // Create and configure the email message
                using (MailMessage mailMessage = new MailMessage(emailSender, emailReceiver))
                {
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;

                    // Create and configure the SMTP client
                    using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                    {
                        smtpClient.Port = 587;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(emailSender, emailPassword);
                        smtpClient.EnableSsl = true;

                        // Send the email
                        smtpClient.Send(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error sending email.", ex);
            }
        }





        private void InsertDataIntoDatabase()
        {
            String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=Forms;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "INSERT INTO [dbo].[Request] (FullName, Email, Mes) VALUES (@fullname, @email, @message)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@fullname", clientInfo.fullname);
                    command.Parameters.AddWithValue("@email", clientInfo.email);
                    command.Parameters.AddWithValue("@message", clientInfo.message);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
