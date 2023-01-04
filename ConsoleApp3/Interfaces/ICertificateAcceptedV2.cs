namespace ConsoleApp3.Interfaces;

public interface ICertificateAcceptedV2 : IMessageBase
{
    public string Plant { get; }
    public Guid ProCoSysGuid { get; }

}
 