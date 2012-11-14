using System.Globalization;
using System.Threading.Tasks;

using SimpleRtRest.RestClient;
using SimpleRtRest.RestClient.Validation;

namespace TelAPI
{
    public partial class TelAPIRestClient
    {
        /// <summary>
        /// Retrive Call details. Make GET request
        /// </summary>
        /// <param name="callSid"></param>
        /// <returns></returns>
        public async Task<Call> GetCall(string callSid)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.GetCallUri;
            request.AddUrlSegment(RequestUriParams.CallSid, callSid);

            return await Execute<Call>(request);
        }

        /// <summary>
        /// Retrive all calls. Make GET request
        /// </summary>
        /// <returns></returns>
        public async Task<CallResult> GetCalls()
        {
            var request = new RestRequest();
            request.Resource = RequestUri.GetCallsUri;

            return await Execute<CallResult>(request);
        }

        /// <summary>
        /// Retrive all calls which satisfy CallOptions criteria. Make GET request
        /// </summary>
        /// <param name="callOptions">Call options to narrow search of calls</param>
        /// <returns></returns>
        public async Task<CallResult> GetCalls(CallListOptions callOptions)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.GetCallsUri;

            CreateCallListOptions(callOptions, request);

            return await Execute<CallResult>(request);
        }

        /// <summary>
        /// Initiate outbound call. Make POST request
        /// </summary>
        /// <param name="from">The number to call.</param>
        /// <param name="to">The number to display as calling.</param>
        /// <param name="url">The URL requested once the call connects.</param>
        /// <returns></returns>
        public async Task<Call> MakeCall(string from, string to, string url)
        {
            return await MakeCall(new CallOptions
            {
                From = from,
                To = to,
                Url = url
            });
        }

        /// <summary>
        /// Initiate outbound call with options. Make POST request
        /// </summary>
        /// <param name="callOptions">Call options</param>
        /// <returns></returns>
        public async Task<Call> MakeCall(CallOptions callOptions)
        {
            Require.Argument("To", callOptions.To);
            Require.Argument("From", callOptions.From);
            Require.Argument("Url", callOptions.Url);

            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.MakeCallUri;

            CreateCallOptions(callOptions, request);

            return await Execute<Call>(request);
        }

        /// <summary>
        /// Hangup up current active call. Make POST request
        /// </summary>
        /// <param name="callSid">An alphanumeric string used for identification of calls.</param>
        /// <returns></returns>
        public async Task<Call> HangupCall(string callSid)
        {
            Require.Argument("CallSid", callSid);

            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.HangupCallUri;
            request.AddUrlSegment(RequestUriParams.CallSid, callSid);
            request.AddParameter("Status", HangupCallStatus.Completed.ToString().ToLower());

            return await Execute<Call>(request);
        }

        /// <summary>
        /// To change the behavior of live calls, TelAPI provides the ability to interrupt calls in real time and end or redirect them to InboundXML for execution.
        /// </summary>
        /// <param name="callSid">An alphanumeric string used for identification of calls</param>
        /// <param name="url">The URL in-progress calls can be forwarded to.</param>
        /// <param name="httpMethod">Specifies the HTTP method used to request forwarding URL. Allowed Value: POST or GET. Default Value: POST</param>
        /// <param name="status">The status used to end the call. canceled only ends queued/ringing calls while completed ends in-progress calls as well as queued/ringing calls. Allowed Value: canceled or completed</param>
        /// <returns></returns>
        public async Task<Call> InterruptLiveCall(string callSid, string url, HttpMethod httpMethod, HangupCallStatus status)
        {
            Require.Argument("CallSid", callSid);
            Require.Argument("Url", url);
            Require.Argument("Method", httpMethod);
            Require.Argument("Status", status);

            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.InterruptLiveCallUri;
            request.AddUrlSegment(RequestUriParams.CallSid, callSid);
            request.AddParameter("Url", url);
            request.AddParameter("Method", httpMethod.ToString().ToLower());
            request.AddParameter("Status", status.ToString().ToLower());

            return await Execute<Call>(request);
        }

        /// <summary>
        /// DTMFs, aka touch tone signals, can be sent to a call
        /// </summary>
        /// <param name="callSid">An alphanumeric string used for identification of calls</param>
        /// <param name="playDtmf">Specifies which touch tone signals to send to a call. W or w can be used to include half second pauses within the digit transmission. For example: wwww1234 waits two seconds before sending the digits and 12wwww34 waits two seconds in between the sending of 12 and 34. Allowed Value: the digits 0-9, W, or w</param>
        /// <param name="dtmfLeg">Specifies which leg of the call digits will be sent to. 'aleg' leg is the originator of the call, 'bleg' is the recipient of the call.</param>
        /// <returns></returns>
        public async Task<Call> SendDigits(string callSid, string playDtmf, PlayDtmfLeg? dtmfLeg)
        {
            Require.Argument("CallSid", callSid);
            Require.Argument("PlayDtmf", playDtmf);

            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.SendDigitsUri;
            request.AddUrlSegment(RequestUriParams.CallSid, callSid);
            request.AddParameter("PlayDtmf", playDtmf);
            if (dtmfLeg.HasValue) request.AddParameter("PlayDtmfLeg", dtmfLeg.ToString().ToLower());

            return await Execute<Call>(request);
        }

        public async Task<Call> PlayAudio(string callSid, string audioUrl)
        {
            return await PlayAudio(callSid, new PlayAudioOptions
            {
                AudioUrl = audioUrl
            });
        }

        /// <summary>
        /// TelAPI allows you to play an audio file during a call. This is useful for playing hold music, providing IVR prompts, etc.
        /// </summary>
        /// <param name="callSid">An alphanumeric string used for identification of calls</param>
        /// <param name="audioOptions">Audio options</param>
        /// <returns></returns>
        public async Task<Call> PlayAudio(string callSid, PlayAudioOptions audioOptions)
        {
            Require.Argument("CallSid", callSid);
            Require.Argument("AudioUrl", audioOptions.AudioUrl);

            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.PlayAudioUri;
            request.AddUrlSegment(RequestUriParams.CallSid, callSid);

            CreatePlayAudioOptions(audioOptions, request);

            return await Execute<Call>(request);
        }

        /// <summary>
        /// With TelAPI you can modify the way a callers voice sounds by changing things such as speed and pitch of the audio.
        /// </summary>
        /// <param name="callSid">An alphanumeric string used for identification of calls</param>
        /// <param name="effectOptions">Voice effect options</param>
        /// <returns></returns>
        public async Task<Call> VoiceEffects(string callSid, VoiceEffectOptions effectOptions)
        {
            Require.Argument("CallSid", callSid);

            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.VoiceEffectsUri;
            request.AddUrlSegment(RequestUriParams.CallSid, callSid);

            CreateVoiceEffectsOptions(effectOptions, request);

            return await Execute<Call>(request);
        }

        /// <summary>
        /// TelAPI offers a way to both initiate or end a call recording
        /// </summary>
        /// <param name="callSid">An alphanumeric string used for identification of calls</param>
        /// <param name="isRecording">Specifies if call recording should beging or end. To start recording a call, value must be true. To stop recording a call, value must be false.</param>
        /// <returns></returns>
        public async Task<RecordingResult> RecordCall(string callSid, bool isRecording)
        {
            return await RecordCall(callSid, isRecording, null, null);
        }

        /// <summary>
        /// TelAPI offers a way to both initiate or end a call recording
        /// </summary>
        /// <param name="callSid">An alphanumeric string used for identification of calls</param>
        /// <param name="isRecording">Specifies if call recording should beging or end. To start recording a call, value must be true. To stop recording a call, value must be false.</param>
        /// <param name="timeLimit">The time in seconds the duration a call recording should not exceed. If no value specified, recordings are 60 seconds by default.</param>
        /// <param name="callbackUrl">URL where recording information will be relayed to after it has completed.</param>
        /// <returns></returns>
        public async Task<RecordingResult> RecordCall(string callSid, bool isRecording, int? timeLimit, string callbackUrl)
        {
            Require.Argument("CallSid", callSid);
            Require.Argument("Record", isRecording);

            var request = new RestRequest(System.Net.Http.HttpMethod.Post);
            request.Resource = RequestUri.RecordCallUri;
            request.AddUrlSegment(RequestUriParams.CallSid, callSid);
            request.AddParameter("Record", isRecording);

            if (timeLimit.HasValue) request.AddParameter("TimeLimit", timeLimit);
            if (callbackUrl != null) request.AddParameter("CallbackUrl", callbackUrl);

            return await Execute<RecordingResult>(request);
        }

        #region Options helpers

        /// <summary>
        /// Helper method to populate Rest params
        /// </summary>
        /// <param name="callOptions">Call options</param>
        /// <param name="request">Rest Request</param>
        private void CreateCallOptions(CallOptions callOptions, RestRequest request)
        {
            request.AddParameter("To", callOptions.To);
            request.AddParameter("From", callOptions.From);
            request.AddParameter("Url", callOptions.Url);

            if (callOptions.ForwardedFrom != null) request.AddParameter("ForwardedFrom", callOptions.ForwardedFrom);
            if (callOptions.Method != null) request.AddParameter("Method", callOptions.Method);
            if (callOptions.FallbackUrl != null) request.AddParameter("FallbackUrl", callOptions.FallbackUrl);
            if (callOptions.FallbackMethod != null) request.AddParameter("FallbackMethod", callOptions.FallbackMethod);
            if (callOptions.StatusCallback != null) request.AddParameter("StatusCallback", callOptions.StatusCallback);
            if (callOptions.StatusCallbackMethod != null) request.AddParameter("StatusCallbackMethod", callOptions.StatusCallbackMethod);
            if (callOptions.SendDigits != null) request.AddParameter("SendDigits", callOptions.SendDigits);
            if (callOptions.Timeout.HasValue) request.AddParameter("Timeout", callOptions.Timeout);
            if (callOptions.HideCallerId.HasValue) request.AddParameter("HideCallerId", callOptions.HideCallerId);
            if (callOptions.HeartbeatUrl != null) request.AddParameter("HeartbeartUrl", callOptions.HeartbeatUrl);
            if (callOptions.HeartbeatMethod.HasValue) request.AddParameter("HeartbeatMethod", callOptions.HeartbeatMethod.ToString());
            if (callOptions.Record.HasValue) request.AddParameter("Record", callOptions.Record);
            if (callOptions.RecordCallback != null) request.AddParameter("RecordCallback", callOptions.RecordCallback);
            if (callOptions.RecordCallbackMethod.HasValue) request.AddParameter("RecordCallbackMethod", callOptions.RecordCallbackMethod.ToString());
            if (callOptions.Transcribe.HasValue) request.AddParameter("Transcribe", callOptions.Transcribe);
            if (callOptions.TranscribeCallback != null) request.AddParameter("TranscribeCallback", callOptions.TranscribeCallback);
        }

        /// <summary>
        /// Helper method to populate Rest params
        /// </summary>
        /// <param name="callListOptions">Call options</param>
        /// <param name="request">Rest Request</param>
        private void CreateCallListOptions(CallListOptions callListOptions, RestRequest request)
        {
            var startDateParameterName = GetParameterNameWithEquality(callListOptions.StartTimeComaparasion, "StartTime");

            if (callListOptions.To != null) request.AddParameter("To", callListOptions.To);
            if (callListOptions.From != null) request.AddParameter("From", callListOptions.From);
            if (callListOptions.Status != null) request.AddParameter("Status", callListOptions.Status);
            if (callListOptions.StartTime.HasValue) request.AddParameter(startDateParameterName, callListOptions.StartTime.Value.ToString("yyyy-MM-dd"));
            if (callListOptions.Page.HasValue) request.AddParameter("Page", callListOptions.Page);
            if (callListOptions.PageSize.HasValue) request.AddParameter("PageSize", callListOptions.PageSize);
        }

        /// <summary>
        /// Helper method to populate Rest params
        /// </summary>
        /// <param name="audioOptions">Audio options</param>
        /// <param name="request">Rest Request</param>
        private void CreatePlayAudioOptions(PlayAudioOptions audioOptions, RestRequest request)
        {
            request.AddParameter("AudioUrl", audioOptions.AudioUrl);

            if (audioOptions.Length.HasValue) request.AddParameter("Length", audioOptions.Length);
            if (audioOptions.Leg.HasValue) request.AddParameter("Legs", audioOptions.Leg.ToString().ToLower());
            if (audioOptions.Loop.HasValue) request.AddParameter("Loop", audioOptions.Loop);
            if (audioOptions.Mix.HasValue) request.AddParameter("Mix", audioOptions.Mix);
        }

        /// <summary>
        /// Helper method to populate Rest params
        /// </summary>
        /// <param name="voiceOptions">Voice effect options</param>
        /// <param name="request">Rest Request</param>
        private void CreateVoiceEffectsOptions(VoiceEffectOptions voiceOptions, RestRequest request)
        {
            if (voiceOptions.AudioDirection.HasValue) request.AddParameter("AudioDirection", voiceOptions.AudioDirection.ToString().ToLower());
            if (voiceOptions.Pitch.HasValue) request.AddParameter("Pitch", voiceOptions.Pitch.Value.ToString(CultureInfo.InvariantCulture));
            if (voiceOptions.PitchSemiTones.HasValue) request.AddParameter("PitchSemiTones", voiceOptions.PitchSemiTones.Value.ToString(CultureInfo.InvariantCulture));
            if (voiceOptions.PitchOctaves.HasValue) request.AddParameter("PitchOctaves", voiceOptions.PitchOctaves.Value.ToString(CultureInfo.InvariantCulture));
            if (voiceOptions.Rate.HasValue) request.AddParameter("Rate", voiceOptions.Rate.Value.ToString(CultureInfo.InvariantCulture));
            if (voiceOptions.Tempo.HasValue) request.AddParameter("Tempo", voiceOptions.Tempo.Value.ToString(CultureInfo.InvariantCulture));
        }

        #endregion
    }
}
