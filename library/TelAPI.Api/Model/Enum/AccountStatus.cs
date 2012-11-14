using System.Runtime.Serialization;

namespace TelAPI
{
    /// <summary>
    /// Acount statuses
    /// </summary>
    public enum AccountStatus
    {
        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "suspended")]
        Suspended,

        [EnumMember(Value = "closed")]
        Closed
    }
}
