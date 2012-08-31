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
            return GetConference(conferenceSid, null, null, null);
        }

        /// <summary>
        /// Return resource properties about conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="members">Used to identify specific conference members you wish to view the information of.</param>
        /// <returns></returns>
        public Conference GetConference(string conferenceSid, List<Member> members)
        {
            return GetConference(conferenceSid, members, null, null);
        }

        /// <summary>
        /// Return resource properties about conference call
        /// </summary>
        /// <param name="conferenceSid">>Conference sid</param>
        /// <param name="member">Used to identify specific conference member you wish to view the information of</param>
        /// <returns></returns>
        public Conference GetConference(string conferenceSid, Member member)
        {
            var list = new List<Member>();
            list.Add(member);

            return GetConference(conferenceSid, list);
        }

        /// <summary>
        /// Return resource properties about conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="members">Used to identify specific conference members you wish to view the information of.</param>
        /// <param name="muted">Specifies whether only muted conference members should be returned. Default value is false and all conference members are returned.</param>
        /// <param name="deafed">Specifies whether only deafed conference members should be returned. Default value is false and all conference members are returned.</param>
        /// <returns></returns>

        public Conference GetConference(string conferenceSid, List<Member> members, bool? muted, bool? deafed)
        {
            Require.Argument("ConferenceSid", conferenceSid);

            var request = new RestRequest();
            request.Resource = RequestUri.ConferenceUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);

            if (members != null)
            {
                if (members.Count > 0)
                {
                    request.AddParameter("MemberID", CreateMemberIDs(members));
                }
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
        /// <param name="members">Used to identify and return conferences only specific members were involved in.</param>
        /// <returns></returns>
        public ConferenceResult GetConferences(List<Member> members)
        {
            return GetConferences(members, null, null, null, null);
        }

        /// <summary>
        /// Return list of all conference resources associated with a given account
        /// </summary>
        /// <param name="members">Used to identify and return conferences only specific members were involved in.</param>
        /// <param name="muted">Specifies whether only conferences with muted members should be returned.</param>
        /// <param name="deafed">Specifies whether only conferences with deafed members should be returned.</param>
        /// <returns></returns>
        public ConferenceResult GetConferences(List<Member> members, bool? muted, bool? deafed)
        {
            return GetConferences(members, muted, deafed, null, null);
        } 
       
        /// <summary>
        /// Return list of all conference resources associated with a given account
        /// </summary>
        /// <param name="member">Used to identify and return conferences only specific member were involved in.</param>
        /// <returns></returns>
        public ConferenceResult GetConferences(Member member)
        {
            var list = new List<Member>();
            list.Add(member);

            return GetConferences(list);
        }

        /// <summary>
        /// Return list of all conference resources associated with a given account
        /// </summary>
        /// <param name="members">Used to identify and return conferences only specific members were involved in.</param>
        /// <param name="muted">Specifies whether only conferences with muted members should be returned.</param>
        /// <param name="deafed">Specifies whether only conferences with deafed members should be returned.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public ConferenceResult GetConferences(List<Member> members, bool? muted, bool? deafed, int? page, int? pageSize)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.ConferencesUri;

            if (members != null)
            {
                if (members.Count > 0)
                {
                    request.AddParameter("MemberID", CreateMemberIDs(members));
                }
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
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="members">Specifies the members to mute.</param>
        /// <returns></returns>
        public Conference MuteMember(string conferenceSid, List<Member> members)
        {
            Require.Argument("ConferenceSid", conferenceSid);
            Require.Argument("MemberID", members);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceMuteMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);

            if (members != null)
            {
                if (members.Count > 0)
                {
                    request.AddParameter("MemberID", CreateMemberIDs(members));
                }
            }

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Mute member of conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="member">Specifies the member to mute.</param>
        /// <returns></returns>
        public Conference MuteMember(string conferenceSid, Member member)
        {
            var list = new List<Member>();
            list.Add(member);

            return MuteMember(conferenceSid, list);
        }

        /// <summary>
        /// Unmute member of conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="members">Specifies the members to unmute.</param>
        /// <returns></returns>
        public Conference UnmuteMember(string conferenceSid, List<Member> members)
        {
            Require.Argument("ConferenceSid", conferenceSid);
            Require.Argument("MemberID", members);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceUnmuteMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);

            if (members != null)
            {
                if (members.Count > 0)
                {
                    request.AddParameter("MemberID", CreateMemberIDs(members));
                }
            }

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Unmute member of conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="member">Specifies the member to unmute.</param>
        /// <returns></returns>
        public Conference UnmuteMember(string conferenceSid, Member member)
        {
            var list = new List<Member>();
            list.Add(member);

            return UnmuteMember(conferenceSid, list);
        }

        /// <summary>
        /// Deaf member of conference call  
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="members">Specifies the members to deaf.</param>
        /// <returns></returns>
        public Conference DeafMember(string conferenceSid, List<Member> members)
        {
            Require.Argument("ConferenceSid", conferenceSid);
            Require.Argument("MemberID", members);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceDeafMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);

            if (members != null)
            {
                if (members.Count > 0)
                {
                    request.AddParameter("MemberID", CreateMemberIDs(members));
                }
            }

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Deaf member of conference call  
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="member">Specifies the member to deaf.</param>
        /// <returns></returns>
        public Conference DeafMember(string conferenceSid, Member member)
        {
            var list = new List<Member>();
            list.Add(member);

            return DeafMember(conferenceSid, list);
        }

        /// <summary>
        /// Undeaf member of conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="members">Specifies the members to undeaf.</param>
        /// <returns></returns>
        public Conference UndeafMember(string conferenceSid, List<Member> members)
        {
            Require.Argument("ConferenceSid", conferenceSid);
            Require.Argument("MemberID", members);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceUndeafMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);

            if (members != null)
            {
                if (members.Count > 0)
                {
                    request.AddParameter("MemberID", CreateMemberIDs(members));
                }
            }

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Undeaf member of conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="member">Specifies the member to undeaf.</param>
        /// <returns></returns>
        public Conference UndeafMember(string conferenceSid, Member member)
        {
            var list = new List<Member>();
            list.Add(member);

            return UndeafMember(conferenceSid, list);
        }
        /// <summary>
        /// Hangup member of conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="members">Specifies the members to hangup.</param>
        /// <returns></returns>
        public Conference HangupMember(string conferenceSid, List<Member> members)
        {
            Require.Argument("ConferenceSid", conferenceSid);
            Require.Argument("MemberID", members);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceHangupMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);

            if (members != null)
            {
                if (members.Count > 0)
                {
                    request.AddParameter("MemberID", CreateMemberIDs(members));
                }
            }

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Hangup member of conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="member">Specifies the member to hangup.</param>
        /// <returns></returns>
        public Conference HangupMember(string conferenceSid, Member member)
        {
            var list = new List<Member>();
            list.Add(member);

            return HangupMember(conferenceSid, list);
        }

        /// <summary>
        /// Kick member from conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="members">Specifies the members to kick.</param>
        /// <returns></returns>
        public Conference KickMember(string conferenceSid, List<Member> members)
        {
            Require.Argument("ConferenceSid", conferenceSid);
            Require.Argument("MemberID", members);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceKickMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);

            if (members != null)
            {
                if (members.Count > 0)
                {
                    request.AddParameter("MemberID", CreateMemberIDs(members));
                }
            }

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Kick member from conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="member">Specifies the member to kick.</param>
        /// <returns></returns>
        public Conference KickMember(string conferenceSid, Member member)
        {
            var list = new List<Member>();
            list.Add(member);

            return KickMember(conferenceSid, list);
        }

        /// <summary>
        /// Play audio to member of conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="members">Specifies the members to play audio.</param>
        /// <param name="url">Url where audio is located</param>
        /// <returns></returns>
        public Conference PlayAudioToMember(string conferenceSid, List<Member> members, string url)
        {
            Require.Argument("ConferenceSid", conferenceSid);
            Require.Argument("MemberID", members);
            Require.Argument("Url", url);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferencePlayAudioToMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceSid, conferenceSid);

            if (members != null)
            {
                if (members.Count > 0)
                {
                    request.AddParameter("MemberID", CreateMemberIDs(members));
                }
            }

            request.AddParameter("Url", url);

            return Execute<Conference>(request);
        }

        /// <summary>
        /// Play audio to member of conference call
        /// </summary>
        /// <param name="conferenceSid">Conference sid</param>
        /// <param name="member">Specifies the member to play audio.</param>
        /// <param name="url">Url where audio is located</param>
        /// <returns></returns>
        public Conference PlayAudioToMember(string conferenceSid, Member member, string url)
        {
            var list = new List<Member>();
            list.Add(member);

            return PlayAudioToMember(conferenceSid, list, url);
        }

        #region Unsupported?
        /* Removed from documentation??

        /// <summary>
        /// Speak text to member of conference call
        /// </summary>
        /// <param name="conferenceName">Conference name</param>
        /// <param name="MemberID">Specifies the member to mute. If more than one member is to be muted, a comma is used to separate each MemberID.</param>
        /// <param name="text">Text to speech</param>
        /// <returns></returns>
        public ConferenceResponse SpeakTextToMember(string conferenceSid, List<Member> members, string text)
        {
            Require.Argument("ConferenceSid", conferenceSid);
            Require.Argument("MemberID", members);
            Require.Argument("Text", text);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceSpeachTextToMemberUri;
            request.AddUrlSegment(RequestUriParams.ConferenceName, conferenceSid);

            if (members != null)
            {
                if (members.Count > 0)
                {
                    request.AddParameter("MemberID", CreateMemberIDs(members));
                }
            }
            
            request.AddParameter("Text", text);

            return Execute<ConferenceResponse>(request);
        }

        public ConferenceResponse SpeakTextToMember(string conferenceName, Member member, string text)
        {
            var list = new List<Member>();
            list.Add(member);

            return SpeakTextToMember(conferenceName, list, text);
        }
        
        /// <summary>
        /// Start recording conference call
        /// </summary>
        /// <param name="conferenceName">Conference name</param>
        /// <returns></returns>
        public ConferenceResponse StartRecordingConference(string conferenceName)
        {
            Require.Argument("ConferenceName", conferenceName);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceStartRecordingUri;
            request.AddUrlSegment(RequestUriParams.ConferenceName, conferenceName);

            return Execute<ConferenceResponse>(request);
        }

        /// <summary>
        /// Stop recording conference name
        /// </summary>
        /// <param name="conferenceName">Conference name</param>
        /// <returns></returns>
        public ConferenceResponse StopRecordingConference(string conferenceName)
        {
            Require.Argument("ConferenceName", conferenceName);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.ConferenceStopRecording;
            request.AddUrlSegment(RequestUriParams.ConferenceName, conferenceName);

            return Execute<ConferenceResponse>(request);
        }        
        
        */
        #endregion

        #region Helper methods
        /// <summary>
        /// Return list of members id's in one string seperated by comma
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        private string CreateMemberIDs(List<Member> members)
        {
            string membersIds = string.Empty;

            for (int i = 1; i <= members.Count; i++)
            {
                if (i == members.Count)
                {
                    membersIds += members[i-1].Id;
                }
                else
                {
                    membersIds += members[i-1].Id + ",";
                }
            }

            return membersIds;
        } 
        #endregion
    }
}
