using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HttpExternalServices.Exceptions
{
    [Serializable]
    public class HttpServicesException : Exception, ISerializable
    {
        public HttpServicesException() : base() { }

        public HttpServicesException(string message) : base(message) { }

        public HttpServicesException(string message, Exception innerException) : base(message, innerException) { }

        protected HttpServicesException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            base.GetObjectData(info, context);
        }
    }
}
