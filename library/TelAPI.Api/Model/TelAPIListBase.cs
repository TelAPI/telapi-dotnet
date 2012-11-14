using System;
using Newtonsoft.Json;

namespace TelAPI
{
    public class TelAPIListBase : TelAPIBase
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "num_pages")]
        public int NumPages { get; set; }

        [JsonProperty(PropertyName = "page_size")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }

        [JsonProperty(PropertyName = "start")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "end")]
        public int End { get; set; }


        [JsonProperty(PropertyName = "first_page_uri")]
        public Uri FirstPageUri { get; set; }

        [JsonProperty(PropertyName = "next_page_uri")]
        public Uri NextPageUri { get; set; }

        [JsonProperty(PropertyName = "previous_page_uri")]
        public Uri PreviousPageUri { get; set; }

        [JsonProperty(PropertyName = "last_page_uri")]
        public Uri LastPageUri { get; set; }
    }
}
