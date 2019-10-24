using System;
using System.Net.Mail;

namespace EmailSender.UI
{
	class Program
	{
		static void Main(string[] args)
		{
			//You have to enable less secure apps on your gmail account. https://www.google.com/settings/security/lesssecureapps
			Console.WriteLine("Sending email");
			MailMessage mail = new MailMessage();
			SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
			mail.From = new MailAddress("your-email-address@gmail.com");
			mail.To.Add("address-to@hotmail.com");
			mail.Subject = "Test email";
			mail.Body = "This is a test email.";

			SmtpServer.Port = 587;
			SmtpServer.Credentials = new System.Net.NetworkCredential("your-email-address@gmail.com", "password");
			SmtpServer.EnableSsl = true;

			SmtpServer.Send(mail);
			Console.WriteLine("Email send!");
			Console.ReadLine();
		}
	}
}
