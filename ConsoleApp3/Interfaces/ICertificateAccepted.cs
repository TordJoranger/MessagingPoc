namespace ConsoleApp3.Interfaces;

public interface ICertificateAccepted : IMessageBase
{
    public string Plant { get; }
    public Guid ProCoSysGuid { get; }
    public string ProjectName { get; }
    public string CertificateNo { get; }
    public string CertificateType { get; }

    public DateTime AcceptedAtUtc { get; }

}