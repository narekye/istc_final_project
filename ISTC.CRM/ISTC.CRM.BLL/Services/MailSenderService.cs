using System.Linq;

namespace ISTC.CRM.BLL.Services
{
    public class GmailSender
    {
        private readonly System.Net.Mail.MailMessage message;
        private readonly System.Net.Mail.SmtpClient client;

        #region Constructors
       
        public GmailSender()
        {
            client = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            message = new System.Net.Mail.MailMessage
            {
                IsBodyHtml = false
            };
        }

        public GmailSender(System.Net.Mail.MailAddress from, System.Net.Mail.MailAddress to) : this()
        {
            message.From = from;
            message.To.Add(to);
        }

        public GmailSender(string from, string to) : this(new System.Net.Mail.MailAddress(from), new
            System.Net.Mail.MailAddress(to))
        { }

        #endregion

        public GmailSender AddToMailingList(System.Collections.Generic.IEnumerable<System.Net.Mail.MailAddress> addresses)
        {
            foreach (var mailAddress in addresses)
            {
                message.To.Add(mailAddress);
            }
            return this;
        }

        public GmailSender AddToMailingList(System.Collections.Generic.IEnumerable<string> addresses)
        {
            var listMailAddresses = new System.Collections.Generic.List<System.Net.Mail.MailAddress>();

            foreach (var address in addresses)
                listMailAddresses.Add(new System.Net.Mail.MailAddress(address));
            return AddToMailingList(listMailAddresses);
        }

        public void Send()
        {
            if (!message.To.Any())
                throw new System.Exception("Mail message to is not set.");
            client.Send(message);
        }

        public GmailSender SetBodyHtml(bool isBodyHtml = false)
        {
            message.IsBodyHtml = isBodyHtml;
            return this;
        }

        public GmailSender SetBodyString(string body)
        {
            message.Body = body;
            return this;
        }

        public GmailSender SetCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new System.Security.Authentication.InvalidCredentialException();
            client.Credentials = new System.Net.NetworkCredential(username, password);
            return this;
        }

        public GmailSender SetCredentials(System.Net.NetworkCredential credential)
        {
            if (credential == null)
                throw new System.Security.Authentication.InvalidCredentialException();
            client.Credentials = credential;
            return this;
        }

        public GmailSender SetSubject(string subject)
        {
            if (subject == null)
                subject = "Empty subject";
            message.Subject = subject;
            return this;
        }
    }
}
