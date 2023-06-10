using System.ComponentModel;

namespace Dto.Message
{
    public class MessageDataDtoRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
        public MessageType MessageType { get; set; }
    }
    public enum MessageType
    {
        Text = 1,
        File = 2
    }
}