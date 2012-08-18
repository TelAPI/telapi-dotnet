using System;

namespace TelAPI
{
    public class VoiceEffectOptions
    {
        public AudioDirection? AudioDirection { get; set; }
        public double? Pitch { get; set; }
        public double? PitchSemiTones { get; set; }
        public double? PitchOctaves { get; set; }
        public double? Rate { get; set; }
    }
}
