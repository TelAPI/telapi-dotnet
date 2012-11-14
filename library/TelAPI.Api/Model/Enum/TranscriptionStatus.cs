using System.Runtime.Serialization;

namespace TelAPI
{
    public enum TranscriptionStatus
    {
        [EnumMember(Value = "in-progress")]
        InProgress,

        [EnumMember(Value = "completed")]
        Completed,

        [EnumMember(Value = "failed")]
        Failed
    }
}
