namespace ConsoleApp3.ServiceBusMessage
{
    public class Certificate : MessageBase
    {
        public Certificate(
            string plant,
            Guid proCoSysGuid,
            string projectName,
            string certificateNo,
            string certificateType,
            DateTime createdAtUtc,
            string createdBy)
            : base("certificate", "1.0", "certificate", plant, proCoSysGuid)
        {
            ProjectName = projectName;
            CertificateNo = certificateNo;
            CertificateType = certificateType;

            CreatedAtUtc = createdAtUtc;
            CreatedBy = createdBy;

            ValidateAllDateTimesIsUtc();
        }

        public string ProjectName { get; }
        public string CertificateNo { get; }
        public string CertificateType { get; }
        public DateTime CreatedAtUtc { get; }
        public string CreatedBy { get; }
        public bool IsVoided { get; } = false;
    }
}