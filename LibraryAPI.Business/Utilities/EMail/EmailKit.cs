
using LibraryAPI.Core.Entities.FnModels;
using LibraryAPI.Core.Entities.SpModels;
using LibraryAPI.DataAccess.Infrastructure.Tools.EfCore;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Data.SqlClient;
using MimeKit;
using MimeKit.Text;

namespace LibraryAPI.DataAccess.Utilities.EMail
{
    public static class EmailKit
    {      
        public static ResultInfo SendMail(string email, string subject, string message)
        {
            MimeMessage mail = new MimeMessage();
            mail.From.Add(MailboxAddress.Parse("atayev222@bk.ru"));
            mail.To.Add(MailboxAddress.Parse($"{email}"));
            mail.Subject = subject;
            mail.Body = new TextPart(TextFormat.Html) { Text = message };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.mail.ru", 465, true);
            smtp.Authenticate("atayev222@bk.ru", "gSu5fyDXeqrxECtuMA70");
            if (smtp.Send(mail) is null)
            {
                return ResultInfo.CouldNotSendMail;
            }
            smtp.Disconnect(true);
            return ResultInfo.Success;
        }
    }
}
