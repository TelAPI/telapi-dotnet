using System;

namespace TelAPI
{
    /// <summary>
    /// List of all Request Uri's for TelAPI
    /// </summary>
    public static class RequestUri
    {
        /// <summary>
        /// Uri to get account information
        /// </summary>
        public const string GetAccoutUri = "Accounts/{AccountSid}.json";
        
        /// <summary>
        /// Uri to get Sms message
        /// </summary>
        public const string GetSmsMessageUri = "Accounts/{AccountSid}/SMS/Messages/{SMSMessageSid}.json";
        
        /// <summary>
        /// Uri to get list of sms messages
        /// </summary>
        public const string GetSmsMessagesUri = "Accounts/{AccountSid}/SMS/Messages.json";
        
        /// <summary>
        /// Uri to send sms message
        /// </summary>
        public const string SendSmsMessageUri = "Accounts/{AccountSid}/SMS/Messages.json";

        /// <summary>
        /// Uri to get call information
        /// </summary>
        public const string GetCallUri = "Accounts/{AccountSid}//Calls/{CallSid}.json";
        
        /// <summary>
        /// Uri to get list of call
        /// </summary>
        public const string GetCallsUri = "Accounts/{AccountSid}/Calls.json";
        
        /// <summary>
        /// Uri to initiate outbound call
        /// </summary>
        public const string MakeCallUri = "Accounts/{AccountSid}/Calls.json";
        
        /// <summary>
        /// Uri to finish current call
        /// </summary>
        public const string HangupCallUri = "Accounts/{AccountSid}/Calls/{CallSid}.json";

        /// <summary>
        /// Uri to interrupt live call
        /// </summary>
        public const string InterruptLiveCallUri = "Accounts/{AccountSid}/Calls/{CallSid}.json";

        /// <summary>
        /// Uri to send digits to call
        /// </summary>
        public const string SendDigitsUri = "Accounts/{AccountSid}/Calls/{CallSid}.json";

        /// <summary>
        /// Uri to play audio on call
        /// </summary>
        public const string PlayAudioUri = "Accounts/{AccountSid}/Calls/{CallSid}.json";

        /// <summary>
        /// Uri to add voice effects
        /// </summary>
        public const string VoiceEffectsUri = "Accounts/{AccountSid}/Calls/{CallSid}.json";

        /// <summary>
        /// Uri to start/stop recording call
        /// </summary>
        public const string RecordCallUri = "Accounts/{AccountSid}/Calls/{CallSid}.json";

        /// <summary>
        /// Uri to get notification
        /// </summary>
        public const string NotificationUri = "Accounts/{AccountSid}/Notifications.json";

        /// <summary>
        /// Uri to get call notifications
        /// </summary>
        public const string CallNotificationUri = "Accounts/{AccountSid}/Calls/{CallSid}/Notifications.json";

        /// <summary>
        /// Uri to get avaliable phone numbers
        /// </summary>
        public const string AvailablePhoneNumbersUri = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/Local.json";

        /// <summary>
        /// Uri to get incoming phone number
        /// </summary>
        public const string IncomingPhoneNumberUri = "Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json";

       /// <summary>
       /// Uri to get incoming phone numbers
       /// </summary>
        public const string IncomingPhoneNumbersUri = "Accounts/{AccountSid}/IncomingPhoneNumbers.json";

        /// <summary>
        /// Uri to create Incoming phone number
        /// </summary>
        public const string CreateIncomingPhoneNumber = "Accounts/{AccountSid}/IncomingPhoneNumbers.json";

        /// <summary>
        /// Uri to delete Incoming phone number
        /// </summary>
        public const string DeleteIncomingPhoneNumberUri = "Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json";

        /// <summary>
        /// Uri to update Incoming phone number
        /// </summary>
        public const string UpdateIncomingPhoneNumberUri = "Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}.json";

        /// <summary>
        /// Uri to get application data
        /// </summary>
        public const string ApplicationUri = "Accounts/{AccountSid}/Applications/{ApplicationSid}.json";

        /// <summary>
        /// Uri to get list of applications
        /// </summary>
        public const string ApplicationsUri = "Accounts/{AccountSid}/Applications.json";

        /// <summary>
        /// Uri to create new application
        /// </summary>
        public const string CreateApplicationUri = "Accounts/{AccountSid}/Applications.json";

        /// <summary>
        /// Uri to update application data
        /// </summary>
        public const string UpdateApplicationUri = "Accounts/{AccountSid}/Applications/{ApplicationSid}.json";

        /// <summary>
        /// Uri to delete application
        /// </summary>
        public const string DeleteApplicationUri = "Accounts/{AccountSid}/Applications/{ApplicationSid}.json";

        /// <summary>
        /// Uri to recording
        /// </summary>
        public const string RecordingUri = "Accounts/{AccountSid}/Recordings/{RecordingSid}.json";

        /// <summary>
        /// Uri to account recordings
        /// </summary>
        public const string AccountRecordingsUri = "Accounts/{AccountSid}/Recordings.json";

        /// <summary>
        /// Uri to call recordings
        /// </summary>
        public const string CallRecordingsUri = "Accounts/{AccountSid}/Calls/{CallSid}/Recordings.json";

        /// <summary>
        /// Uri to transcription
        /// </summary>
        public const string TranscriptionUri = "Accounts/{AccountSid}/Transcriptions/{TranscriptionSid}.json";

        /// <summary>
        /// Uri to transcription text
        /// </summary>
        public const string TranscriptionTextUri = "Accounts/{AccountSid}/Transcriptions/{TranscriptionSid}.txt";

        /// <summary>
        /// Uri to account transcriptions
        /// </summary>
        public const string AccountTranscriptionsUri = "Accounts/{AccountSid}/Transcriptions.json";

        /// <summary>
        /// Uri to recording transcriptions
        /// </summary>
        public const string RecordingTranscriptionsUri = "Accounts/{AccountSid}/{RecordingSid}/Transcriptions.json";

        /// <summary>
        /// Uri to start transcribe of recording
        /// </summary>
        public const string TranscribeRecordingUri = "Accounts/{AccountSid}/Recordings/{RecordingSid}/Transcriptions.json";

        /// <summary>
        /// Uri to start transcribe of external audio url
        /// </summary>
        public const string TranscribeAudioUri = "Accounts/{AccountSid}/Transcriptions.json";

        /// <summary>
        /// Uri to carrier lookup   
        /// </summary>
        public const string CarrierLookupUri = "Accounts/{AccountSid}/Carrier.json";

        /// <summary>
        /// Uri to CNAM lookup
        /// </summary>
        public const string CNAMLookupUri = "Accounts/{AccountSid}/CNAM.json";
    }

    /// <summary>
    /// List of all required Request Uri params
    /// </summary>
    public static class RequestUriParams
    {
        /// <summary>
        /// Sms message Sid
        /// </summary>
        public const string SmsMessageSid = "SmsMessageSid";
        
        /// <summary>
        /// Call Sid
        /// </summary>
        public const string CallSid = "CallSid";

        /// <summary>
        /// Notification Sid
        /// </summary>
        public const string NotificationSid = "NotificationSid";

        /// <summary>
        /// Iso country code
        /// </summary>
        public const string IsoCountryCode = "IsoCountryCode";

        /// <summary>
        /// Incoming phone number
        /// </summary>
        public const string IncomingPhoneNumber = "IncomingPhoneNumberSid";

        /// <summary>
        /// Application Sid
        /// </summary>
        public const string ApplicationSid = "ApplicationSid";

        /// <summary>
        /// Recording Sid
        /// </summary>
        public const string RecordingSid = "RecordingSid";

        /// <summary>
        /// Transcription Sid
        /// </summary>
        public const string TranscriptionSid = "TranscriptionSid";

        /// <summary>
        /// Phone number
        /// </summary>
        public const string PhoneNumber = "PhoneNumber";
    }
}
