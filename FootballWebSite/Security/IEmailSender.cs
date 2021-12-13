using System.Threading.Tasks;

namespace SportWebSite.Security
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message);
    }
}
