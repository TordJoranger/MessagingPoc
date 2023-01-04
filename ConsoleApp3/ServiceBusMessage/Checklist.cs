namespace ConsoleApp3.ServiceBusMessage
{
    public class Checklist : MessageBase
    {
        public Checklist(string plant,
            Guid proCoSysGuid,
            long checklistId,
            string projectName,
            string tagNo,
            string tagCategory,
            string formularGroup,
            string formularDiscipline,
            string revision,
            string responsible,
            string status, 
            DateTime? updatedAtUtc, 
            DateTime? signedAtUtc, 
            DateTime? verifiedAtUtc)
            : base("checklist", "1.0", "checklist-modify", plant, proCoSysGuid)
        {
            ChecklistId = checklistId;
            ProjectName = projectName;
            TagNo = tagNo;
            TagCategory = tagCategory;
            FormularGroup = formularGroup;
            FormularDiscipline = formularDiscipline;
            Revision = revision;
            Responsible = responsible;
            Status = status;

            UpdatedAtUtc = updatedAtUtc;
            SignedAtUtc = signedAtUtc;
            VerifiedAtUtc = verifiedAtUtc;

            ValidateAllDateTimesIsUtc();
        }

        public long ChecklistId { get; }
        public string ProjectName { get; }
        public string TagNo { get; }
        public string TagCategory { get; }
        public string FormularGroup { get; }
        public string FormularDiscipline { get; }
        public string Revision { get; }
        public string Responsible { get; }
        public string Status { get; }
        public DateTime? UpdatedAtUtc { get;  }
        public DateTime? SignedAtUtc { get;  }
        public DateTime? VerifiedAtUtc { get; }
    }
}