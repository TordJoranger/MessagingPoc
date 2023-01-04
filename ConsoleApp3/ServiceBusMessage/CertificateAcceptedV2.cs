using ConsoleApp3.Interfaces;

namespace ConsoleApp3.ServiceBusMessage
{
    public class CertificateAcceptedV2 : ICertificateAcceptedV2
    {
        public CertificateAcceptedV2(string plant, Guid proCoSysGuid)

        {
            Plant = plant;
            ProCoSysGuid = proCoSysGuid;
        }

        public string EventType => "certificate-accepted";
        public string Plant { get; }
        public Guid ProCoSysGuid { get; }
    }
}