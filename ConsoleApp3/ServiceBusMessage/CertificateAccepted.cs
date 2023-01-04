using ConsoleApp3.Interfaces;

namespace ConsoleApp3.ServiceBusMessage
{
    public class CertificateAccepted : ICertificateAccepted
    {
        public CertificateAccepted(
            string plant,
            Guid proCoSysGuid,
            string projectName,
            string certificateNo,
            string certificateType,
            DateTime acceptedAtUtc)
           
        {
            Plant = plant;
            ProCoSysGuid = proCoSysGuid;
            ProjectName = projectName;
            CertificateNo = certificateNo;
            CertificateType = certificateType;
            AcceptedAtUtc = acceptedAtUtc;
        }

        public string Plant { get; }
        public Guid ProCoSysGuid { get; }
        public string ProjectName { get; }
        public string CertificateNo { get; }
        public string CertificateType { get; }
        public DateTime AcceptedAtUtc { get; }
        public string EventType => "certificate-accepted";
    }
}