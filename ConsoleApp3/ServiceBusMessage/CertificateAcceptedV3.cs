using ConsoleApp3.Interfaces;

namespace ConsoleApp3.ServiceBusMessage
{
    public class CertificateAcceptedV3 : ICertificateAcceptedV3
    {
        public CertificateAcceptedV3(
            string plant,
            Guid proCoSysGuid,
            string certificateType,
            DateTime acceptedAtUtc, Guid certificateNoGuid)

        {
            Plant = plant;
            ProCoSysGuid = proCoSysGuid;
            
            CertificateType = certificateType;
            AcceptedAtUtc = acceptedAtUtc;
            CertificateNoGuid = certificateNoGuid;
        }

        public string Plant { get; }
        public Guid ProCoSysGuid { get; }
        public Guid CertificateNoGuid { get; }
     
        public string CertificateType { get; }
        public DateTime AcceptedAtUtc { get; }
        public string EventType => "certificate-accepted";
    }
}