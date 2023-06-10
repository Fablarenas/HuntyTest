using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IMessageRepository
    {
        Task SaveMessage(List<Message> message);
        Task<List<Message>> GetAllMessages();
    }
}
