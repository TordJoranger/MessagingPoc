using System.Text.Json;
using ConsoleApp3;
using ConsoleApp3.Interfaces;
using ConsoleApp3.SenderMessage;
using ConsoleApp3.ServiceBusMessage;

var acceptedAt = new DateTime(2022, 12, 22, 12, 13, 14, DateTimeKind.Utc);
var createdAt = new DateTime(2022, 12, 24, 13, 14, 15, DateTimeKind.Utc);

var acceptedCert = new CertificateAcceptedSender("PlantA", Guid.NewGuid(), "ProjX", "CertNo", "RFCC", 
    acceptedAt, Guid.NewGuid());
var serializedAcceptedCert = JsonSerializer.Serialize(acceptedCert);

ProcessMessage("certificate",serializedAcceptedCert);

var createdCert = new Certificate("PlantB", Guid.NewGuid(), "ProjY", "No2", "RFOC", createdAt, "jdalsb");
var message2 = JsonSerializer.Serialize(createdCert);

ProcessMessage("certificate", message2);

var createdChecklist = new Checklist("PlantC", Guid.NewGuid(), 1257432, "ProjZ", "Tag10", "X", "MCCR", "I", "1", "ABBS", "OS", createdAt, null, null);
var message3 = JsonSerializer.Serialize(createdChecklist);

ProcessMessage("checklist",message3);

var tagVoid = new TagVoid("PlantA", Guid.NewGuid());
var message5 = JsonSerializer.Serialize(tagVoid);

ProcessMessage("tag",message5);

try
{
    createdAt = DateTime.Now;
    new Checklist("PlantC", Guid.NewGuid(), 1257432, "ProjZ", "Tag10", "X", "MCCR", "I", "1", "ABBS", "OS", createdAt, null, null);
}
catch (Exception e)
{
    Console.WriteLine($"\n{e.Message}");
}

void ProcessMessage(string topic,string message)
{
    Console.WriteLine($"\nIncomming Message: {message}\n");

    var settings = new JsonSerializerOptions()
    {
        Converters = { new EventConverter() },
    };

    var msgBase = JsonSerializer.Deserialize<IMessageBase>(message,settings);
  
    if (msgBase == null)
    {
        throw new Exception("Not a valid message");
    }

    switch (msgBase)
    {
        case CertificateAccepted ca:
            ProcessAcceptedCertificated(ca);
            break;
        case CertificateAcceptedV2 ca:
            ProcessAcceptedCertificatedV2(ca); //only one version per consumer normally
            break;
        case CertificateAcceptedV3 ca:
            ProcessAcceptedCertificatedV3(ca); 
            break;
        case Certificate certificate:
            ProcessCreatedOrModifiedCertificated(certificate);
            break;
        case TagVoid:
            ProcessVoidedTag(JsonSerializer.Deserialize<TagVoid>(message));
            break;
        default:
            Console.WriteLine($"Client X do not support {msgBase.EventType}");
            break;
    }
}

void ProcessVoidedTag(TagVoid? tagVoid)
{
    if (tagVoid == null || tagVoid.ProCoSysGuid == Guid.Empty)
    {
        throw new Exception("Not a valid message for a voided certificate");
    }
    Console.WriteLine("TAGVOID");
    ShowBase(tagVoid);
}

void ProcessCreatedOrModifiedCertificated(Certificate? cert)
{
    if (cert == null || cert.ProCoSysGuid == Guid.Empty)
    {
        throw new Exception("Not a valid message for a created certificate");
    }
    Console.WriteLine("CERTIFICATE");
    ShowBase(cert);
    Console.WriteLine(cert.CertificateNo);
    Console.WriteLine(cert.ProjectName);
    Console.WriteLine(cert.CertificateType);
    Console.WriteLine(cert.CreatedBy);
    Console.WriteLine(cert.CreatedAtUtc);
    Console.WriteLine(cert.IsVoided);
}

void ProcessAcceptedCertificated(ICertificateAccepted? cert)
{
    if (cert == null || cert.ProCoSysGuid == Guid.Empty)
    {
        throw new Exception("Not a valid message for an accepted certificate");
    }
    Console.WriteLine("Certificate Accepted version 1");
    Console.WriteLine(cert.Plant);
    Console.WriteLine(cert.EventType);
    Console.WriteLine(cert.ProCoSysGuid);
    Console.WriteLine(cert.CertificateNo);
    Console.WriteLine(cert.ProjectName);
    Console.WriteLine(cert.CertificateType);
    Console.WriteLine(cert.AcceptedAtUtc);
}

void ProcessAcceptedCertificatedV3(ICertificateAcceptedV3? cert)
{
    if (cert == null || cert.ProCoSysGuid == Guid.Empty)
    {
        throw new Exception("Not a valid message for an accepted certificate");
    }
    Console.WriteLine("Certificate Accepted version 3");
    Console.WriteLine(cert.Plant);
    Console.WriteLine(cert.EventType);
    Console.WriteLine(cert.ProCoSysGuid);
    Console.WriteLine(cert.CertificateNoGuid);
    Console.WriteLine(cert.CertificateType);
    Console.WriteLine(cert.AcceptedAtUtc);
}


void ProcessAcceptedCertificatedV2(ICertificateAcceptedV2? cert)
{
    if (cert == null || cert.ProCoSysGuid == Guid.Empty)
    {
        throw new Exception("Not a valid message for an accepted certificate");
    }
    Console.WriteLine("Certificate Accepted version 2");
    Console.WriteLine(cert.Plant);
    Console.WriteLine(cert.EventType);
    Console.WriteLine(cert.ProCoSysGuid);
}

void ShowBase(MessageBase messageBase)
{
    Console.WriteLine(messageBase.Plant);
    Console.WriteLine(messageBase.ObjectType);
    Console.WriteLine(messageBase.EventType);
    Console.WriteLine(messageBase.ProCoSysGuid);
}