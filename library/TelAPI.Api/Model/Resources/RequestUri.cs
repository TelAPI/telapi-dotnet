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
        public const string NotificationUri = "Accounts/{AccountSid}/Notifications/{NotificationsSid}.json";

       /// <summary>
       /// Uri to get notifications
       /// </summary>
        public const string NotificationsUri = "Accounts/{AccountSid}/Notifications.json";

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

        /// <summary>
        /// Uri to conference
        /// </summary>
        public const string ConferenceUri = "Accounts/{AccountSid}/Conferences/{ConferenceName}.json";

        /// <summary>
        /// Uri to conferences
        /// </summary>
        public const string ConferencesUri = "Accounts/{AccountSid}/Conferences.json";

        /// <summary>
        /// Uri to mute member in conference call
        /// </summary>
        public const string ConferenceMuteMemberUri = "Accounts/{AccountSid}/Conferences/{ConferenceName}/Mute.json";

        /// <summary>
        /// Uri to unmute member in conference call
        /// </summary>
        public const string ConferenceUnmuteMemberUri = "Accounts/{AccountSid}/Conferences/{ConferenceName}/UnMute.json";

        /// <summary>
        /// Uri to deaf member in conference call
        /// </summary>
        public const string ConferenceDeafMemberUri = "Accounts/{AccountSid}/Conferences/{ConferenceName}/Deaf.json";

        /// <summary>
        /// Uri to undeaf member in conference call
        /// </summary>
        public const string ConferenceUndeafMemberUri = "Accounts/{AccountSid}/Conferences/{ConferenceName}/UnDeaf.json";

        /// <summary>
        /// Uri to hangup member in conference call
        /// </summary>
        public const string ConferenceHangupMemberUri = "Accounts/{AccountSid}/Conferences/{ConferenceName}/Hangup.json";

        /// <summary>
        /// Uri to kick member from conference call
        /// </summary>
        public const string ConferenceKickMemberUri = "Accounts/{AccountSid}/Conferences/{ConferenceName}/Kick.json";

        /// <summary>
        /// Uri to speach text to member in conference call
        /// </summary>
        public const string ConferenceSpeachTextToMemberUri = "Accounts/{AccountSid}/Conferences/{ConferenceName}/Say.json";

        /// <summary>
        /// Uri to play audio to member in conference call
        /// </summary>
        public const string ConferencePlayAudioToMemberUri = "Accounts/{AccountSid}/Conferences/{ConferenceName}/Play.json";

        /// <summary>
        /// Uri to start recording conference call
        /// </summary>
        public const string ConferenceStartRecordingUri = "Accounts/{AccountSid}/Conferences/{ConferenceName}/RecordStart.json";

        /// <summary>
        /// Uri to stop recording conference call
        /// </summary>
        public const string ConferenceStopRecording = "Accounts/{AccountSid}/Conferences/{ConferenceName}/RecordStop.json";

        /// <summary>
        /// Uri to get all fraud control resources
        /// </summary>
        public const string FraudControlResourcesUri = "Accounts/{AccountSid}/Fraud.json";

        /// <summary>
        /// Uri to authorize destination
        /// </summary>
        public const string FraudAuthorizeDestination = "Accounts/{AccountSid}/Fraud/Authorize/{CountryCode}.json";

        /// <summary>
        /// Uri to block destination
        /// </summary>
        public const string FraudBlockDestination = "Accounts/{AccountSid}/Fraud/Block/{CountryCode}.json";

        /// <summary>
        /// Uri to extend authorization of destination
        /// </summary>
        public const string FraudExtendDestinationAuthUri = "Accounts/{AccountSid}/Fraud/Extend/{CountryCode}.json";

        /// <summary>
        /// Uri to whitelist destination
        /// </summary>
        public const string FraudWhitelistDestination = "Accounts/{AccountSid}/Fraud/Whitelist/{CountryCode}.json";
    }

    /// <summary>
    /// List of all required Request Uri params
    /// </summary>
    public static class RequestUriParams
    {
        /// <summary>
        /// Sms message Sid
        /// </summary>
        public const string SmsMessageSid = "SMSMessageSid";
        
        /// <summary>
        /// Call Sid
        /// </summary>
        public const string CallSid = "CallSid";

        /// <summary>
        /// Notification Sid
        /// </summary>
        public const string NotificationSid = "NotificationsSid";

        /// <summary>
        /// Iso country code
        /// </summary>
        public const string IsoCountryCode = "IsoCountryCode";

        /// <summary>
        /// Incoming phone number
        /// </summary>
        public const string IncomingPhoneNumberSid = "IncomingPhoneNumberSid";

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

        /// <summary>
        /// Conference name
        /// </summary>
        public const string ConferenceName = "ConferenceName";
    }
}
