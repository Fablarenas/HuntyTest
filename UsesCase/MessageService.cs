using AutoMapper;
using DomainEntities;
using Dto;
using Dto.Message;
using Dto.ReceiveMessage;
using ExternalServicesInterfaces;
using Interfaces;
using Repositories;

namespace UsesCase
{
    public class MessageService : IMessageService
    {
        private readonly IWhatsappIntegration _whatsappIntegration;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        public MessageService(IWhatsappIntegration whatsappIntegration, IMapper mapper, IMessageRepository messageRepository)
        {
            _whatsappIntegration = whatsappIntegration;
            _mapper = mapper;
            _messageRepository = messageRepository;
        }

        public async Task<ResponseDtoList<MessageDataDtoResponse>> GetMessages()
        {
           var messages = await _messageRepository.GetAllMessages();
           var messagesDto = _mapper.Map<List<MessageDataDtoResponse>>(messages);
           return new ResponseDtoList<MessageDataDtoResponse>() { Data = messagesDto, IsSuccess = true, Response = "200" };
        }

        public async Task<ResponseDto<MessageDataDtoResponse>> Receive(Root rootMessage)
        {
            List<Dto.ReceiveMessage.Message> sourceMessages = rootMessage.entry
                .SelectMany(e => e.changes.SelectMany(c => c.value.messages)).ToList();

            var messages = _mapper.Map<List<DomainEntities.Message>>(sourceMessages);
            await _whatsappIntegration.SaveMessage(messages);
            return new ResponseDto<MessageDataDtoResponse>() { Data = new MessageDataDtoResponse(), IsSuccess = true, Response = "200" };
        }

        public async Task<ResponseDto<MessageDataDtoResponse>> Send(MessageDataDtoRequest messagedto)
        {
            var message = _mapper.Map<DomainEntities.Message>(messagedto);
            await _whatsappIntegration.SendMessage(message);
            return new ResponseDto<MessageDataDtoResponse>() { Data = new MessageDataDtoResponse(), IsSuccess = true, Response = "200" };
        }
    }
}
