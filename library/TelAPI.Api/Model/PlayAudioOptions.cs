using System;

namespace TelAPI
{
    public class PlayAudioOptions
    {
        public string Sounds { get; set; }
        public int? Length { get; set; }
        public PlayAudioLeg? Leg { get; set; }
        public bool? Loop { get; set; }
        public bool? Mix { get; set; }
    }
}
