using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Get a single recording resource
        /// </summary>
        /// <param name="recordingSid">An alphanumeric string used to identify each recording.</param>
        /// <returns></returns>
        public Recording GetRecording(string recordingSid)
        {
            Require.Argument("RecordingSid", recordingSid);

            var request = new RestRequest();
            request.Resource = RequestUri.RecordingUri;
            request.AddUrlSegment(RequestUriParams.RecordingSid, recordingSid);

            return Execute<Recording>(request);
        }

        /// <summary>
        /// Get account recordings
        /// </summary>
        /// <returns></returns>
        public RecordingResult GetAccountRecordings()
        {
            return GetAccountRecordings(null, null, null, null);
        }

        /// <summary>
        /// Get account recordings
        /// </summary>
        /// <param name="dateCreated">Lists all recordings created on or after a certain date. </param>
        /// <returns></returns>
        public RecordingResult GetAccountRecordings(DateTime dateCreated)
        {
            return GetAccountRecordings(dateCreated, null, null, null);
        }

        /// <summary>
        /// Get account recordings
        /// </summary>
        /// <param name="dateCreated">Lists all recordings created on or after a certain date. </param>
        /// <param name="dateCreatedComparasion">Date created comparasion</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public RecordingResult GetAccountRecordings(DateTime? dateCreated, ComparisonType? dateCreatedComparasion, int? page, int? pageSize)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.AccountRecordingsUri;

            var dateCreatedParameterName = GetParameterNameWithEquality(dateCreatedComparasion, "DateCreated");

            if (dateCreated.HasValue) request.AddParameter(dateCreatedParameterName, dateCreated.Value.ToString("yyyy-MM-dd"));
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return Execute<RecordingResult>(request);
        }

        /// <summary>
        /// Get call recordings
        /// </summary>
        /// <param name="callSid">An alphanumeric string used to identify each call.</param>
        /// <returns></returns>
        public RecordingResult GetCallRecordings(string callSid)
        {
            return GetCallRecordings(callSid, null, null, null, null);
        }

        /// <summary>
        /// Get call recordings
        /// </summary>
        /// <param name="callSid">An alphanumeric string used to identify each call.</param>
        /// <param name="dateCreated">Lists all recordings created on or after a certain date</param>
        /// <returns></returns>
        public RecordingResult GetCallRecordings(string callSid, DateTime dateCreated)
        {
            return GetCallRecordings(callSid, dateCreated, null, null, null);
        }

        /// <summary>
        /// Get call recordings
        /// </summary>
        /// <param name="callSid">An alphanumeric string used to identify each call</param>
        /// <param name="dateCreated">Lists all recordings created on or after a certain date</param>
        /// <param name="dateCreatedComparasion">Date created comparasion</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public RecordingResult GetCallRecordings(string callSid, DateTime? dateCreated, ComparisonType? dateCreatedComparasion, int? page, int? pageSize)
        {
            Require.Argument("CallSid", callSid);

            var request = new RestRequest();
            request.Resource = RequestUri.CallRecordingsUri;
            request.AddUrlSegment(RequestUriParams.CallSid, callSid);

            var dateCreatedParameterName = GetParameterNameWithEquality(dateCreatedComparasion, "DateCreated");

            if (dateCreated.HasValue) request.AddParameter(dateCreatedParameterName, dateCreated.Value.ToString("yyyy-MM-dd"));
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return Execute<RecordingResult>(request);
        }
    }
}
