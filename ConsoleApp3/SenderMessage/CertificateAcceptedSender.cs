using ConsoleApp3.Interfaces;

namespace ConsoleApp3.SenderMessage;

public class CertificateAcceptedSender : ICertificateAccepted , ICertificateAcceptedV2, ICertificateAcceptedV3 //not called sender usually
{
    public CertificateAcceptedSender(string plant, Guid proCoSysGuid, string projectName, string certificateNo, string certificateType, 
        DateTime acceptedAtUtc, Guid certificateNoGuid)
    {
        Plant = plant;
        ProCoSysGuid = proCoSysGuid;
        ProjectName = projectName;
        CertificateNo = certificateNo;
        CertificateType = certificateType;
       
        AcceptedAtUtc = acceptedAtUtc;
        CertificateNoGuid = certificateNoGuid;
    }

    public string Plant { get; }
    public Guid ProCoSysGuid { get; }

    public Guid CertificateNoGuid { get; }

    public string ProjectName { get; }
    public string CertificateNo { get; }
    public string CertificateType { get; }
    public DateTime AcceptedAtUtc { get; }

    public string EventType => "certificate-accepted";
}