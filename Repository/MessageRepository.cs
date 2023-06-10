using AutoMapper;
using DomainEntities;
using MongoDB.Driver;
using Persistence.Collections;
using Repositories;

namespace Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IMongoCollection<MessageCollection> _messages;
        private readonly IMapper _mapper;


        public MessageRepository(IMongoClient client, string databaseName, string collectionName , IMapper mapper)
        {
            _messages = client.GetDatabase(databaseName).GetCollection<MessageCollection>(collectionName);
            _mapper = mapper;
        }

        public async Task SaveMessage(List<Message> message)
        {
            var collectionMessages = _mapper.Map<List<MessageCollection>>(message);
            await _messages.InsertManyAsync(collectionMessages);
        }

        public async Task<List<Message>> GetAllMessages()
        {
            try
            {
                var collectionMessages = await _messages.Find(message => true).ToListAsync();
                var messages = _mapper.Map<List<Message>>(collectionMessages);
                return messages;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}