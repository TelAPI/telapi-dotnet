using System;
using System.Collections.Generic;

namespace TelAPI
{
    public class NotificationResult : TelAPIListBase
    {
        public List<Notification> Notifications { get; set; }
    }
}
