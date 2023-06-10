using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ResponseDto<T>
    {
        public bool IsSuccess
        {
            get; set;
        }
        public string? Response
        {
            get; set;
        }
        public string? Message
        {
            get; set;
        }
        public T? Data
        {
            get; set;
        }

    }

    public class ResponseDtoList<T>
    {
        public bool IsSuccess
        {
            get; set;
        }
        public string? Response
        {
            get; set;
        }
        public string? Message
        {
            get; set;
        }
        public List<T>? Data
        {
            get; set;
        }

    }
}
