using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Validation;
using RestSharp.Extensions;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Return resource properties about conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <returns></returns>
        public Conference GetConference(string conferenceSid)
        {
            Require.Argument("ConferenceSid", conferenceSid);

            var request = new RestRequest();
            request.Resource = RequestUri.ConferenceUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Return list of all conference resources associated with a given account
        /// </summary>
        /// <returns></returns>
        public ConferenceResult GetConferences()
        {
            return GetConferences(null, null, null, null, null, null, null, null);
        }

        /// <summary>
        /// Return list of all conference resources associated with a given account
        /// </summary>
        /// <param name="friendlyName">List conferences with the given FriendlyName.</param>
        /// <returns></returns>
        public ConferenceResult GetConferences(string friendlyName)
        {
            return GetConferences(friendlyName, null, null, null, null, null, null, null);
        }

        /// <summary>
        /// Return list of all conference resources associated with a given account
        /// </summary>
        /// <param name="status">List conferences with the given status.</param>
        /// <param name="dateCreated">List conferences created on, after, or before a given date. </param>
        /// <param name="dateCreatedComaparasion">Date range can be specified using inequalities</param>
        /// <returns></returns>
        public ConferenceResult GetConferences(ConferenceStatus status, DateTime dateCreated, ComparisonType dateCreatedComaparasion)
        {
            return GetConferences(null, status, dateCreated, dateCreatedComaparasion, null, null, null, null);
        } 
       
        /// <summary>
        /// Return list of all conference resources associated with a given account
        /// </summary>
        /// <param name="friendlyName">List conferences with the given FriendlyName.</param>
        /// <param name="status">List conferences with the given status.</param>
        /// <param name="dateCreated">List conferences created on, after, or before a given date.</param>
        /// <param name="dateCreatedComparasion">Date range can be specified using inequalities.</param>
        /// <param name="dateUpdated">List conferences updated on, after, or before a given date.</param>
        /// <param name="dateUpdatedComparasion">Date range can be specified using inequalities.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public ConferenceResult GetConferences(string friendlyName, ConferenceStatus? status, DateTime? dateCreated, ComparisonType? dateCreatedComparasion,
            DateTime? dateUpdated, ComparisonType? dateUpdatedComparasion, int? page, int?pageSize)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.ConferencesUri;

            var dateCreatedParameterName = GetParameterNameWithEquality(dateCreatedComparasion, "DateCreated");
            var dateUpdatedParemeterName = GetParameterNameWithEquality(dateUpdatedComparasion, "DateUpdated");

            if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);
            if (status.HasValue) request.AddParameter("Status", status.ToString().ToLower());
            if (dateCreated.HasValue) request.AddParameter(dateCreatedParameterName, dateCreated.Value.ToString("yyyy-MM-dd"));
            if (dateUpdated.HasValue) request.AddParameter(dateUpdatedParemeterName, dateUpdated.Value.ToString("yyyy-MM-dd"));
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return Execute<ConferenceResult>(request);
        }

        /// <summary>
        /// Participants of a conference are identified by the CallSid created when they dial into the conference.
        /// </summary>
        /// <param name="conferenceSid"></param>
        /// <param name="callSid">The CallSid identifying this participant.</param>
        /// <returns></returns>
        public Participant GetConferenceParticipant(string conferenceSid, string callSid)
        {
            Require.Argument("ConferenceSid", conferenceSid);
            Require.Argument("CallSid", callSid);

            var request = new RestRequest();
            request.Resource = RequestUri.ConferenceParticipantActionUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);
            request.AddUrlSegment(RequestUriParams.CallSid, callSid);

            return Execute<Participant>(request);
        }

        /// <summary>
        /// Return list of all conference participants
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <returns></returns>
        public List<Participant> GetConferenceParticipants(string conferenceSid)
        {
            return GetConferenceParticipants(conferenceSid, null, null, null, null);
        }

        /// <summary>
        /// Return list of all conference participants
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="muted">Only list participants that are muted.</param>
        /// <param name="deafed">Only list participants that are deaf.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public List<Participant> GetConferenceParticipants(string conferenceSid, bool? muted, bool? deafed, int? page, int? pageSize)
        {
            Require.Argument("ConferenceSid", conferenceSid);

            var request = new RestRequest();
            request.Resource = RequestUri.ConferenceParticipantsUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);

            if (muted.HasValue) request.AddParameter("Muted", muted);
            if (deafed.HasValue) request.AddParameter("Deafed", deafed);
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return Execute<List<Participant>>(request);
        }
        
        /// <summary>
        /// Mute participant of conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="participant">Specifies the participant to mute.</param>
        /// <param name="mute">Mute participant?</param>
        /// <returns></returns>
        public Participant MuteParticipant(string conferenceSid, Participant participant, bool mute)
        {
            Require.Argument("ConferenceSid", conferenceSid);
            Require.Argument("CallSid", participant.CallSid);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceParticipantActionUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);
            request.AddUrlSegment(RequestUriParams.CallSid, participant.CallSid);

            request.AddParameter("Muted", mute);

            return Execute<Participant>(request);
        }

        /// <summary>
        /// Deaf participant of conference call  
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="participant">Specifies the participant to deaf.</param>
        /// <param name="deaf">Deaf participant?</param>
        /// <returns></returns>
        public Participant DeafParticipant(string conferenceSid, Participant participant, bool deaf)
        {
            Require.Argument("ConferenceSid", conferenceSid);
            Require.Argument("CallSid", participant.CallSid);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceParticipantActionUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);
            request.AddUrlSegment(RequestUriParams.CallSid, participant.CallSid);

            request.AddParameter("Deaf", deaf);

            return Execute<Participant>(request);
        }
        
        /// <summary>
        /// Hangup participant of conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="participant">Specifies the participant to hangup.</param>
        /// <returns></returns>
        public Participant HangupParticipant(string conferenceSid, Participant participant)
        {
            Require.Argument("ConferenceSid", conferenceSid);
            Require.Argument("CallSid", participant.CallSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = RequestUri.ConferenceParticipantActionUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);
            request.AddUrlSegment(RequestUriParams.CallSid, participant.CallSid);

            return Execute<Participant>(request);
        }

        /// <summary>
        /// Play audio to participant of conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="participant">Specifies the participant to play audio.</param>
        /// <param name="url">Url where audio is located</param>
        /// <returns></returns>
        public Participant PlayAudioToParticipant(string conferenceSid, Participant participant, string url)
        {
            Require.Argument("ConferenceSid", conferenceSid);
            Require.Argument("CallSid", participant.CallSid);
            Require.Argument("Url", url);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferencePlayAudioToParticipantUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);
            request.AddUrlSegment(RequestUriParams.CallSid, participant.CallSid);

            request.AddParameter("AudioUrl", url);

            return Execute<Participant>(request);
        }
    }
}
