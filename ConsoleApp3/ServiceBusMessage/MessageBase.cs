using ConsoleApp3.Interfaces;

namespace ConsoleApp3.ServiceBusMessage
{
    public class MessageBase : IMessageBase
    {
        public MessageBase(string objectType, string version, string eventType, string plant, Guid proCoSysGuid)
        {
            ObjectType = objectType;
            Version = version;
            EventType = eventType;
            Plant = plant;
            ProCoSysGuid = proCoSysGuid;
        }

        public string ObjectType { get; }
        public string Version { get; }
        public string EventType { get; }
        public string Plant { get; }
        public Guid ProCoSysGuid { get; }

        protected void ValidateAllDateTimesIsUtc()
        {
            foreach (var prop in GetType().GetProperties().Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?)))
            {
                if (prop.GetValue(this, null) is DateTime { Kind: not DateTimeKind.Utc })
                {
                    throw new Exception($"DateTime value {prop.Name} in a {GetType().Name} must be of kind UTC");
                }
            }
        }
    }
}
