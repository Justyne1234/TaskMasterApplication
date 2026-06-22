using System.Text.Json.Serialization;

namespace TaskMaster.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
    ToDo,
    InProgress,
    Completed,
    Cancelled
}

