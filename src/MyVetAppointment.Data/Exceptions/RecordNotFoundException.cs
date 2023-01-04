using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyVetAppointment.Data.Exceptions
{
    [Serializable]
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string message) : base(message)
        {

        }

        protected RecordNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
