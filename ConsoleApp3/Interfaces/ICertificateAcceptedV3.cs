namespace ConsoleApp3.Interfaces;

public interface ICertificateAcceptedV3 : IMessageBase
{
    public string Plant { get; }
    public Guid ProCoSysGuid { get; }
    public Guid CertificateNoGuid { get; }
    public string CertificateType { get; }

    public DateTime AcceptedAtUtc { get; }

}