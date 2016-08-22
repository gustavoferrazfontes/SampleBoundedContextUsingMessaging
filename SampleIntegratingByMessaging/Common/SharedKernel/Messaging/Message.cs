using SharedKernel.Events.Interfaces;
using System;

namespace SharedKernel.Messaging
{
    public class Message : IDomainEvent
    {
        public DateTime DateOccurred { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

    }
}
