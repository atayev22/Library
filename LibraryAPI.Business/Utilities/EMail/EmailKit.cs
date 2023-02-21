
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
    public class EmailKit
    {
        public ResultInfo SendMailToReader(string to,int readerId)
        {
            string htmlBody = "";                               
            MimeMessage mail = new MimeMessage();
            mail.From.Add(MailboxAddress.Parse("atayev222@bk.ru"));
            mail.To.Add(MailboxAddress.Parse($"{to}"));
            mail.Subject = "Книги которые вы взяли";
            htmlBody += @$"<!DOCTYPE html>
                        <html>
                        <head>
                        	<meta charset=""utf-8"">
                        	<meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                        	<title></title>
                        </head>
                        <body>
                        <div style=""border: 3px solid darkorange;margin: 10px 10px 10px 10px;padding: 10px 10px 10px 10px;"">
	<table width=""100%"">
		<tr>
			<th>
				<img width=""100px"" height=""100px"" src=""https://sun6-22.userapi.com/s/v1/ig2/fzFMJC2Zy12BCRru7n0L7Sne7lWDSPaWPX5Ou0BAVMhIsTMyn6O65AhpgNvYwq1KbhCh_MDjRBHlTgPgFOWb2z1A.jpg?size=1218x1220&quality=95&crop=0,0,1218,1220&ava=1"">
			</th>
			<th>
				<p>Спасибо что выбрали нашу Библиотеку</p>
			</th>
		</tr>
	</table>
	<table id = ""materiasId"" class=""table table-striped"" style=""font-size:14px; width: 100%;"">
                <thead style = ""border:2px solid darkorange;"" >
              <tr>
                <th width = ""15%"" style=""background-color: darkorange; color: black;border:1px solid darkorange;"">Book Name</th>
                <th width = ""15%"" style= ""background-color: darkorange; color: black;border:1px solid darkorange;"" >Lend Date </th>           
                  <th width= ""15%"" style= ""background-color: darkorange; color: black;border:1px solid darkorange;"" >Return Date</th>      
                </tr>            
              </thead>  
                <tbody style= ""border:2px solid darkorange;"" >";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParam(nameof(readerId), readerId);

            var data = DbTools.ExecuteProcedure<SP_BorrowedBookForEMail>("dbo.SP_BorrowedBookForEMail", parameters);
            foreach (var book in data)
            {
                htmlBody += $@"<tr>
                <th width = ""15%"" style="" color: black;border:1px solid darkorange;"">{book.BookName}</th>
                <th width = ""15%"" style= "" color: black;border:1px solid darkorange;"" >{book.LendDate.ToString("dd-MM-yyyy")}</th>           
                <th width= ""15%"" style= "" color: black;border:1px solid darkorange;"" >{book.ReturnDate.ToString("dd-MM-yyyy")}</th>      
                </tr>";
            }
            htmlBody += $@"</tbody>		
	                        </table>
                           </div>
                        </body>
                    </html>";
            mail.Body = new TextPart(TextFormat.Html) { Text = htmlBody };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.mail.ru", 465, true);
            smtp.Authenticate("atayev222@bk.ru", "r6njtjQyhEFVFPEh0jGJ");
            if (smtp.Send(mail) is null)
            {
                return ResultInfo.CouldNotSendMail;
            }
            smtp.Disconnect(true);
            return ResultInfo.Success;
        }
    }
}
