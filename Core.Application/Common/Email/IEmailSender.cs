using Core.Application.Common.Models;

namespace Core.Application.Common.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}
