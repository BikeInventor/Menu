using System.Runtime.Serialization;

namespace Menu.Contracts.DataContracts
{
    [DataContract]
    public class NotFoundException
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
