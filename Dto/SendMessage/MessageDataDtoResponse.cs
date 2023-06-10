using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Message
{
    public class MessageDataDtoResponse
    {
        public string? Text
        {
            get; set;
        }
        public DateTime Date
        {
            get; set;
        }
        public string? From
        {
            get; set;
        }
    }
}
