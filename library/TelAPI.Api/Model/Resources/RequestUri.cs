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
    }
}
