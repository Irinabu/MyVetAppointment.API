using System.Runtime.Serialization;

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
