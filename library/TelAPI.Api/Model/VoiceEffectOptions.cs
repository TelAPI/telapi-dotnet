using System;

namespace TelAPI
{
    public class VoiceEffectOptions
    {
        public AudioDirection? AudioDirection { get; set; }
        public int? Pitch { get; set; }
        public int? PitchSemiTones { get; set; }
        public int? PitchOctaves { get; set; }
        public int? Rate { get; set; }
    }
}
