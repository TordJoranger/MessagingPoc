using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using ConsoleApp3.Interfaces;
using ConsoleApp3.ServiceBusMessage;

namespace ConsoleApp3;

public class EventConverter : JsonConverter<IMessageBase>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(IMessageBase);
    }

    public override IMessageBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jObject = JsonNode.Parse(ref reader);

        var type = jObject?["EventType"]?.GetValue<string>();
        IMessageBase? target = type switch
        {
            "certificate-accepted" => jObject.Deserialize<CertificateAcceptedV2>(), //current consumer uses v2
            "certificate" => jObject?.Deserialize<Certificate>(),
            "tag-void" => jObject?.Deserialize<TagVoid>(),
            "checklist-modify" => jObject.Deserialize<Checklist>(),
            _ => jObject.Deserialize<MessageBase>()
        };

        return target;
    }

    public override void Write(Utf8JsonWriter writer, IMessageBase value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}