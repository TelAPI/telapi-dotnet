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
        /// <param name="name">Conference name</param>
        /// <returns></returns>
        public Conference GetConference(string name)
        {
            return GetConference(name, null, null, null);
        }

        /// <summary>
        /// Return resource properties about conference call
        /// </summary>
        /// <param name="name">Conference name</param>
        /// <param name="memberId">Used to identify specific conference members you wish to view the information of.</param>
        /// <returns></returns>
        public Conference GetConference(string name, List<string> members)
        {
            return GetConference(name, members, null, null);
        }

        /// <summary>
        /// Return resource properties about conference call
        /// </summary>
        /// <param name="name">Conference name</param>
        /// <param name="memberId">Used to identify specific conference members you wish to view the information of.</param>
        /// <param name="muted">Specifies whether only muted conference members should be returned. Default value is false and all conference members are returned.</param>
        /// <param name="deafed">Specifies whether only deafed conference members should be returned. Default value is false and all conference members are returned.</param>
        /// <returns></returns>
        
        public Conference GetConference(string name, List<string> members, bool? muted, bool? deafed)
        {
            Require.Argument("ConferenceName", name);

            var request = new RestRequest();
            request.Resource = RequestUri.ConferenceUri;
            request.AddUrlSegment(RequestUriParams.ConferenceName, name);

            if (members.Count > 0)
            {
                request.AddParameter("MemberId", CreateMemberIds(members));
            }

            if (muted.HasValue) request.AddParameter("Muted", muted);
            if (deafed.HasValue) request.AddParameter("Deafed", deafed);

            return Execute<Conference>(request);
        }        

        /// <summary>
        /// Return list of all conference resources associated with a given account
        /// </summary>
        /// <returns></returns>
        public ConferenceResult GetConferences()
        {
            return GetConferences(null, null, null, null, null);
        }

        /// <summary>
        /// Return list of all conference resources associated with a given account
        /// </summary>
        /// <param name="memberId">Used to identify and return conferences only specific members were involved in.</param>
        /// <returns></returns>
        public ConferenceResult GetConferences(List<string> members)
        {
            return GetConferences(members, null, null, null, null);
        }

        /// <summary>
        /// Return list of all conference resources associated with a given account
        /// </summary>
        /// <param name="memberId">Used to identify and return conferences only specific members were involved in.</param>
        /// <param name="muted">Specifies whether only conferences with muted members should be returned.</param>
        /// <param name="deafed">Specifies whether only conferences with deafed members should be returned.</param>
        /// <returns></returns>
        public ConferenceResult GetConferences(List<string> members, bool? muted, bool? deafed)
        {
            return GetConferences(members, muted, deafed, null, null);
        }        

        /// <summary>
        /// Return list of all conference resources associated with a given account
        /// </summary>
        /// <param name="memberId">Used to identify and return conferences only specific members were involved in.</param>
        /// <param name="muted">Specifies whether only conferences with muted members should be returned.</param>
        /// <param name="deafed">Specifies whether only conferences with deafed members should be returned.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public ConferenceResult GetConferences(List<string> members, bool? muted, bool? deafed, int? page, int? pageSize)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.ConferencesUri;

            if (members.Count > 0)
            {
                request.AddParameter("MemberId", CreateMemberIds(members));
            }

            if (muted.HasValue) request.AddParameter("Muted", muted);
            if (deafed.HasValue) request.AddParameter("Deafed", deafed);
            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return Execute<ConferenceResult>(request);
        }

        /// <summary>
        /// Mute member of conference call
        /// </summary>
        /// <param name="conferenceName">Conference namce</param>
        /// <param name="memberId">Specifies the member to mute. If more than one member is to be muted, a comma is used to separate each memberID.</param>
        /// <returns></returns>
        public Conference MuteMember(string conferenceName, List<string> members)
        {
            Require.Argument("ConferenceName", conferenceName);
            Require.Argument("MemberId", members);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceMuteMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceName, conferenceName);

            if (members.Count > 0)
            {
                request.AddParameter("MemberId", CreateMemberIds(members));
            }

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Unmute member of conference call
        /// </summary>
        /// <param name="conferenceName">Conference call</param>
        /// <param name="memberId">Specifies the member to mute. If more than one member is to be muted, a comma is used to separate each memberID.</param>
        /// <returns></returns>
        public Conference UnmuteMember(string conferenceName, List<string> members)
        {
            Require.Argument("ConferenceName", conferenceName);
            Require.Argument("MemberId", members);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceUnmuteMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceName, conferenceName);

            if (members.Count > 0)
            {
                request.AddParameter("MemberId", CreateMemberIds(members));
            }

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Deaf member of conference call  
        /// </summary>
        /// <param name="conferenceName">Conference name</param>
        /// <param name="memberId">Specifies the member to mute. If more than one member is to be muted, a comma is used to separate each memberID.</param>
        /// <returns></returns>
        public Conference DeafMember(string conferenceName, List<string> members)
        {
            Require.Argument("ConferenceName", conferenceName);
            Require.Argument("MemberId", members);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceDeafMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceName, conferenceName);

            if (members.Count > 0)
            {
                request.AddParameter("MemberId", CreateMemberIds(members));
            }

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Undeaf member of conference call
        /// </summary>
        /// <param name="conferenceName">Conference name</param>
        /// <param name="memberId">Specifies the member to mute. If more than one member is to be muted, a comma is used to separate each memberID.</param>
        /// <returns></returns>
        public Conference UndeafMember(string conferenceName, List<string> members)
        {
            Require.Argument("ConferenceName", conferenceName);
            Require.Argument("MemberId", members);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceUndeafMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceName, conferenceName);

            if (members.Count > 0)
            {
                request.AddParameter("MemberId", CreateMemberIds(members));
            }

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Hangup member of conference call
        /// </summary>
        /// <param name="conferenceName">Conference name</param>
        /// <param name="memberId">Specifies the member to mute. If more than one member is to be muted, a comma is used to separate each memberID.</param>
        /// <returns></returns>
        public Conference HangupMember(string conferenceName, List<string> members)
        {
            Require.Argument("ConferenceName", conferenceName);
            Require.Argument("MemberId", members);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceHangupMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceName, conferenceName);

            if (members.Count > 0)
            {
                request.AddParameter("MemberId", CreateMemberIds(members));
            }

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Kick member from conference call
        /// </summary>
        /// <param name="conferenceName">Conference name</param>
        /// <param name="memberId">Specifies the member to mute. If more than one member is to be muted, a comma is used to separate each memberID.</param>
        /// <returns></returns>
        public Conference KickMember(string conferenceName, List<string> members)
        {
            Require.Argument("ConferenceName", conferenceName);
            Require.Argument("MemberId", members);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceKickMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceName, conferenceName);

            if (members.Count > 0)
            {
                request.AddParameter("MemberId", CreateMemberIds(members));
            }

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Speak text to member of conference call
        /// </summary>
        /// <param name="conferenceName">Conference name</param>
        /// <param name="memberId">Specifies the member to mute. If more than one member is to be muted, a comma is used to separate each memberID.</param>
        /// <param name="text">Text to speech</param>
        /// <returns></returns>
        public Response SpeakTextToMember(string conferenceName, List<string> members, string text)
        {
            Require.Argument("ConferenceName", conferenceName);
            Require.Argument("MemberId", members);
            Require.Argument("Text", text);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceSpeachTextToMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceName, conferenceName);

            if (members.Count > 0)
            {
                request.AddParameter("MemberId", CreateMemberIds(members));
            }
            
            request.AddParameter("Text", text);

            return Execute<Response>(request);
        }

        /// <summary>
        /// Play audio to member of conference call
        /// </summary>
        /// <param name="conferenceName">Conference name</param>
        /// <param name="memberId">Specifies the member to mute. If more than one member is to be muted, a comma is used to separate each memberID.</param>
        /// <param name="url">Url where audio is located</param>
        /// <returns></returns>
        public Response PlayAudioToMember(string conferenceName, List<string> members, string url)
        {
            Require.Argument("ConferenceName", conferenceName);
            Require.Argument("MemberId", members);
            Require.Argument("Url", url);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferencePlayAudioToMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceName, conferenceName);

            if (members.Count > 0)
            {
                request.AddParameter("MemberId", CreateMemberIds(members));
            }

            request.AddParameter("Url", url);

            return Execute<Response>(request);
        }

        /// <summary>
        /// Start recording conference call
        /// </summary>
        /// <param name="conferenceName">Conference name</param>
        /// <returns></returns>
        public Response StartRecordingConference(string conferenceName)
        {
            Require.Argument("ConferenceName", conferenceName);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceStartRecordingUri;
            request.AddUrlSegment(RequestUriParams.ConferenceName, conferenceName);

            return Execute<Response>(request);
        }

        /// <summary>
        /// Stop recording conference name
        /// </summary>
        /// <param name="conferenceName">Conference name</param>
        /// <returns></returns>
        public Response StopRecordingConference(string conferenceName)
        {
            Require.Argument("ConferenceName", conferenceName);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceStopRecording;
            request.AddUrlSegment(RequestUriParams.ConferenceName, conferenceName);

            return Execute<Response>(request);
        }

        #region Helper methods
        /// <summary>
        /// Return list of members id's in one string seperated by comma
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        private string CreateMemberIds(List<string> members)
        {
            string membersIds = string.Empty;

            for (int i = 1; i <= members.Count; i++)
            {
                if (i == members.Count)
                {
                    membersIds += members[i];
                }
                else
                {
                    membersIds += members[i] + ",";
                }
            }

            return membersIds;
        } 
        #endregion
    }
}
