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
        /// Return transcription
        /// </summary>
        /// <param name="transcriptionSid">An alphanumeric string used for identification of transcriptions.</param>
        /// <returns></returns>
        public Transcription GetTranscription(string transcriptionSid)
        {
            Require.Argument("TranscriptionSid", transcriptionSid);

            var request = new RestRequest();
            request.Resource = RequestUri.TranscriptionUri;
            request.AddUrlSegment(RequestUriParams.TranscriptionSid, transcriptionSid);

            return Execute<Transcription>(request);
        }

        /// <summary>
        /// Return transcription content in textual format
        /// </summary>
        /// <param name="transcriptionSid">An alphanumeric string used for identification of transcriptions.</param>
        /// <returns></returns>
        public string GetTranscriptionText(string transcriptionSid)
        {
            Require.Argument("TranscriptionSid", transcriptionSid);

            var request = new RestRequest();
            request.Resource = RequestUri.TranscriptionUri;
            request.AddUrlSegment(RequestUriParams.TranscriptionSid, transcriptionSid);

            return Execute(request).Content;
        }

        /// <summary>
        /// Return list of transcriptions
        /// </summary>
        /// <returns></returns>
        public TranscriptionResult GetAccountTranscriptions()
        {
            return GetAccountTranscriptions(null, null);
        }

        /// <summary>
        /// Return list of transcriptions
        /// </summary>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public TranscriptionResult GetAccountTranscriptions(int? page, int? pageSize)
        {
            var request = new RestRequest();
            request.Resource = RequestUri.AccountTranscriptionsUri;

            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return Execute<TranscriptionResult>(request);
        }

        /// <summary>
        /// Return list of recording transcriptions
        /// </summary>
        /// <param name="recordingSid">An alphanumeric string used for identification of recording.</param>
        /// <returns></returns>
        public TranscriptionResult GetRecordingTranscriptions(string recordingSid)
        {
            return GetRecordingTranscriptions(recordingSid, null, null);
        }

        /// <summary>
        /// Return list of recording transcriptions
        /// </summary>
        /// <param name="recordingSid">An alphanumeric string used for identification of recording.</param>
        /// <param name="page">Used to return a particular page withing the list.</param>
        /// <param name="pageSize">Used to specify the amount of list items to return per page.</param>
        /// <returns></returns>
        public TranscriptionResult GetRecordingTranscriptions(string recordingSid, int? page, int? pageSize)
        {
            Require.Argument("RecordingSid", recordingSid);

            var request = new RestRequest();
            request.Resource = RequestUri.RecordingTranscriptionsUri;
            request.AddUrlSegment("RecordingSid", RequestUriParams.RecordingSid);

            if (page.HasValue) request.AddParameter("Page", page);
            if (pageSize.HasValue) request.AddParameter("PageSize", pageSize);

            return Execute<TranscriptionResult>(request);
        }

        /// <summary>
        /// Start transcribe of recording
        /// </summary>
        /// <param name="recordingSid">An alphanumeric string used for identification of recording.</param>
        /// <returns></returns>
        public Transcription TranscribeRecording(string recordingSid)
        {
            return TranscribeRecording(recordingSid, null, null, null);
        }

        /// <summary>
        /// Start transcribe of recording
        /// </summary>
        /// <param name="recordingSid">An alphanumeric string used for identification of recording.</param>
        /// <param name="quality">Specifies the transcription quality. </param>
        /// <returns></returns>
        public Transcription TranscribeRecording(string recordingSid, TranscriptionType quality)
        {
            return TranscribeRecording(recordingSid, quality, null, null);
        }

        /// <summary>
        /// Start transcribe of recording
        /// </summary>
        /// <param name="recordingSid">An alphanumeric string used for identification of recording.</param>
        /// <param name="quality">Specifies the transcription quality.</param>
        /// <param name="transcribeCallback">URL that will be requested when the transcription has finished processing.</param>
        /// <param name="callbackMethod">Specifies the HTTP method to use when requesting the TranscribeCallback URL.</param>
        /// <returns></returns>
        public Transcription TranscribeRecording(string recordingSid, TranscriptionType? quality, string transcribeCallback, string callbackMethod)
        {
            Require.Argument("RecordingSid", recordingSid);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.TranscribeRecordingUri;
            request.AddUrlSegment("RecordingSid", recordingSid);

            if(quality.HasValue) request.AddParameter("Quality", quality.ToString().ToLower());
            if(transcribeCallback.HasValue()) request.AddParameter("TranscribeCallback", transcribeCallback);
            if(callbackMethod.HasValue()) request.AddParameter("CallbackMethod", callbackMethod);

            return Execute<Transcription>(request);
        }

        /// <summary>
        /// Start transcribe of external audio
        /// </summary>
        /// <param name="audioUrl">URL where the audio to be transcribed is located.</param>
        /// <returns></returns>
        public Transcription TranscribeAudio(string audioUrl)
        {
            return TranscribeAudio(audioUrl, null, null, null);
        }

        /// <summary>
        /// Start transcribe of external audio
        /// </summary>
        /// <param name="audioUrl">URL where the audio to be transcribed is located.</param>
        /// <param name="quality">Specifies the transcription quality. </param>
        /// <returns></returns>
        public Transcription TranscribeAudio(string audioUrl, TranscriptionType quality)
        {
            return TranscribeAudio(audioUrl, quality, null, null);
        }

        /// <summary>
        /// Start transcribe of external audio
        /// </summary>
        /// <param name="audioUrl">URL where the audio to be transcribed is located.</param>
        /// <param name="quality">Specifies the transcription quality.</param>
        /// <param name="transcribeCallback">URL that will be requested when the transcription has finished processing.</param>
        /// <param name="callbackMethod">Specifies the HTTP method to use when requesting the TranscribeCallback URL.</param>
        /// <returns></returns>
        public Transcription TranscribeAudio(string audioUrl, TranscriptionType? quality, string transcribeCallback, string callbackMethod)
        {
            Require.Argument("AudioUrl", audioUrl);

            var request = new RestRequest(Method.POST);
            request.Resource = RequestUri.TranscribeAudioUri;
            request.AddUrlSegment("AudioUrl", audioUrl);

            if (quality.HasValue) request.AddParameter("Quality", quality.ToString().ToLower());
            if (transcribeCallback.HasValue()) request.AddParameter("TranscribeCallback", transcribeCallback);
            if (callbackMethod.HasValue()) request.AddParameter("CallbackMethod", callbackMethod);

            return Execute<Transcription>(request);
        }

    }
}
