
using DomainEntities;

namespace ExternalServicesInterfaces
{
    public interface IWhatsappIntegration
    {
        Task<Message> SendMessage(Message messageData);
        Task<List<Message>> SaveMessage(List<Message> messageData);
    }
}
