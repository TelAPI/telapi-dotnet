using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TelAPI
{
    public class NotificationResult : TelAPIListBase
    {
        [JsonProperty(PropertyName = "notifications")]
        public List<Notification> Notifications { get; set; }
    }
}
