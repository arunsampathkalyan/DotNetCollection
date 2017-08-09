using System;
using System.Runtime.Serialization;

namespace WcfService.Model
{
    [DataContract]
    public class UserServiceModel
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public string Name;

        [DataMember]
        public string Password;
    }
}