using User.Management.Service.Models;

namespace User.Management.Service.Services
{
    public interface IEmailService
    {
        public void SendEmail(Message message);
    }
}
