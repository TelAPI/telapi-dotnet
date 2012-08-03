using System;

namespace TelAPI
{
    public class TelAPIListBase : TelAPIBase
    {
        public int Page { get; set; }
        public int NumPages { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public Uri FirstPageUri { get; set; }
        public Uri NextPageUri { get; set; }
        public Uri PreviousPageUri { get; set; }
        public Uri LastPageUri { get; set; }
    }
}
