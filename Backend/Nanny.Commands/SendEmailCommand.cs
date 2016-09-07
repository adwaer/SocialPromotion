using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Nanny.Cqrs;
using Nanny.Domain.Entities;

namespace Nanny.Commands
{
    public class SendEmailCommand : ICommand<EmailPublish>
    {
        private readonly SaveCommand _saveCommand;

        public SendEmailCommand(SaveCommand saveCommand)
        {
            _saveCommand = saveCommand;
        }

        public async Task Execute(EmailPublish args)
        {
            var message = new MailMessage
            {
                Subject = args.Subject,
                Body = args.Body,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(args.Email));
            if (!string.IsNullOrEmpty(args.CcList))
            {
                foreach (var cc in args.CcList.Split(','))
                {
                    message.CC.Add(cc);
                }
            }

            if (!string.IsNullOrEmpty(args.BccList))
            {
                foreach (var bcc in args.BccList.Split(','))
                {
                    message.Bcc.Add(bcc);
                }
            }

            using (var smtp = new SmtpClient())
            {
                try
                {
                    await smtp.SendMailAsync(message);
                    args.Socceed = true;
                }
                catch (Exception ex)
                {
                    args.Socceed = false;
                    args.Error = ex.ToString();
                    //_logger.Error("Email not sent", ex);
                    throw;
                }
                finally
                {
                    await _saveCommand.Execute(args);
                }
            }
        }
    }
}
