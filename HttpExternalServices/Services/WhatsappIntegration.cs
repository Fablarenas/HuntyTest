using AutoMapper;
using Dto.Message;
using Entities;
using ExternalServicesInterfaces;
using HttpExternalServices.Interfaces;
using Microsoft.Extensions.Configuration;
using Persistence.Collections;
using Repositories;

namespace HttpExternalServices.Services
{
    public class WhatsappIntegration : IWhatsappIntegration
    {
        private readonly IHttpServices _httpServices;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        public WhatsappIntegration(IHttpServices httpServices, IConfiguration configuration , IMapper mapper, IMessageRepository messageRepository)
        {
            _httpServices = httpServices;
            _configuration = configuration;
            _mapper = mapper;
            _messageRepository = messageRepository;
        }
        public async Task<List<DomainEntities.Message>> SaveMessage(List<DomainEntities.Message> messageData)
        {
            await _messageRepository.SaveMessage(messageData);
            return messageData;
        }

        public async Task<DomainEntities.Message> SendMessage(DomainEntities.Message messageData)
        {
            var message = _mapper.Map<Message>(messageData);
            await _httpServices.PostRequest<Message, MessageDataDtoRequest>(message, _configuration["WhatsappBusinessUrl"], _configuration["WhatsappBusinessToken"]);
            return messageData;
        }
    }
}
