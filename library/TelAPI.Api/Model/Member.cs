using System;

namespace TelAPI
{
    public class Member
    {
        public string Id { get; set; }
        public bool Muted { get; set; }
        public bool Deaf { get; set; }
        public string CallerName { get; set; }
        public string CallerNumber { get; set; }
        public int Duration { get; set; }
    }
}
