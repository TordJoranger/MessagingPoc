namespace ConsoleApp3.ServiceBusMessage
{
    public class TagVoid : MessageBase
    {
        public TagVoid(string plant, Guid proCoSysGuid)
            : base("tag", "1.0", "tag-void", plant, proCoSysGuid)
        {
        }
    }
}