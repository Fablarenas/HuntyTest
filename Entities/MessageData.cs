using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Message
    {
        public string? messaging_product
        {
            get; set;
        }
        public string? to
        {
            get; set;
        }
        public string? type
        {
            get; set;
        }
        public Template? template
        {
            get; set;
        }
    }

    public class Template
    {
        public string? name
        {
            get; set;
        }
        public Language? language
        {
            get; set;
        }
    }

    public class Language
    {
        public string? code
        {
            get; set;
        }
    }
}
