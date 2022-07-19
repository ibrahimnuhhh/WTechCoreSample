using System;
using System.Threading.Tasks;
using WTechCoreSample.Models.Helper;

namespace WTechCoreSample.Service
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
