using Dto;
using Dto.Message;
using Dto.ReceiveMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IMessageService
    {
        Task<ResponseDto<MessageDataDtoResponse>> Send(MessageDataDtoRequest message);
        Task<ResponseDto<MessageDataDtoResponse>> Receive(Root rootMessage);
        Task<ResponseDtoList<MessageDataDtoResponse>> GetMessages();
    }
}
