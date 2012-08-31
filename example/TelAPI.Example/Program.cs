using System;
using System.Threading;

using TelAPI;

namespace TelAPI.Example
{
    class Program
    {
        /// <summary>
        /// TelApi account sid. You can get it from TelApi dashboard.
        /// </summary>
        private const string AccountSid = "your-account-sid";

        /// <summary>
        /// TelApi auth token. You can get it from TelApi dashboard
        /// </summary>
        private const string AuthToken = "your-auth-token";

        /// <summary>
        /// Phone number which will receive our sms and calls from TelApi service
        /// </summary>
        private const string PhoneNumberTo = "phone-number-to";

        /// <summary>
        /// Our valid Telapi phone number that we purchased and we will use it for sending SMS and calls
        /// </summary>
        private const string PhoneNumberFrom = "phone-number-from";    

        static void Main(string[] args)
        {
            // First we need to create TelApi Rest client. To do so, we need to provide accountSid, and authToken.
            var telApi = new TelAPIRestClient(AccountSid, AuthToken);
            
            // Also there is another way of creating TelApi Rest client with TelAPIConfiguration interface.
            // Check DefaultTelAPIConfiguration class for exammple
            // var telApi = new TelAPIRestClient(new DefaultTelAPIConfiguration());


            // First we will get our Telapi account information
            
            var account = telApi.GetAccount();
            Console.WriteLine("Account Sid     : {0}", account.Sid);
            Console.WriteLine("Account Balance : {0}", account.AccountBalance);
            Console.WriteLine("Account Created : {0}", account.DateCreated);
            Console.WriteLine("Account Status  : {0}", account.Status);

            Console.WriteLine();

            // Now we will try to send our first SMS message using TelAPI service.
            // It's always good to decorate all API calls with the try / catch block
            // so that we can catch any exception if something wrong occurs.

            try
            {
                var sms = telApi.SendSmsMessage(PhoneNumberFrom, PhoneNumberTo, "Hello from TelApi.");
                Console.WriteLine("SMS Sid  : {0}", sms.Sid);
                Console.WriteLine("SMS Cost : {0}", sms.Price);
                Console.WriteLine("SMS Sent : {0}", sms.DateSent);
                Console.WriteLine("SMS Type : {0}", sms.Direction);
            }
            catch (TelAPIException ex)
            {
                //If something wrong happens we will catch Telapi exception and print it out
                Console.WriteLine("Error message         : {0}", ex.Message);                
            }

            Console.WriteLine();

            // We can also get all SMS messages that we SENT and RECEIVED from TelApi service.
            // We can also filter list with some Sms message options using SmsMessageListOptions() class
            // We will ask for all SMS that we sent or received today.

            Console.WriteLine("SMS Messages List");
            
            var messageOptions = new SmsMessageListOptions();
            messageOptions.DateSent = DateTime.Today;

            var messages = telApi.GetSmsMessages(messageOptions);
            foreach (var m in messages.SmsMessages)
            {
                Console.WriteLine("From : {0}  To : {1}   Body : {2}", m.From, m.To, m.Body);                
            }

            Console.WriteLine();
      
            // Also we can make calls with just one method call.
            // We need to provide number from which we will make call (our Telapi purchased number)
            // and number which we will call. Also valid URL is needed where Telapi will send some call data

            var call = telApi.MakeCall(PhoneNumberFrom, PhoneNumberTo, "http://www.some-url-for-telapi-data.com");
            Console.WriteLine("Call Sid     : {0}", call.Sid);            
            Console.WriteLine("Call Status  : {0}", call.Status.ToString());
            Console.WriteLine("Call Created : {0}", call.DateCreated);

            Console.WriteLine();

            // We can do various task on calls like sending digits, voice effects, interrupt or hangup call
            // We can also RECORD call which we will do in the next lines. We will wait some time, before turning recording ON
            // Then after another SLEEP we will turn OFF recording
                        
            Thread.Sleep(5000);

            try
            {
                var startRecord = telApi.RecordCall(call.Sid, true);
                Console.WriteLine("[ON] Recording Call Sid     : {0}", startRecord.Sid);
                Console.WriteLine("[ON] Recording Call Started : {0}", startRecord.DateUpdated);
            }
            catch (TelAPIException ex)
            {
                //If something wrong happens we will catch Telapi exception and print it out
                Console.WriteLine("Error message         : {0}", ex.Message);                
            }

            Console.WriteLine();
            Thread.Sleep(5000);

            try
            {
                var stopRecord = telApi.RecordCall(call.Sid, false);
                Console.WriteLine("[0FF] Recording Call Sid     : {0}", stopRecord.Sid);
                Console.WriteLine("[OFF] Recording Call Started : {0}", stopRecord.DateUpdated);
            }
            catch (TelAPIException ex)
            {
                //If something wrong happens we will catch Telapi exception and print it out
                Console.WriteLine("Error message         : {0}", ex.Message);                
            }

            Console.WriteLine();

            // Now we will hangup our call using HangupCall(). Also you can hangup call using
            // InterruptCall() method and specify the reason of interruption

            var hangupCall = telApi.HangupCall(call.Sid);
            Console.WriteLine("Hangup Call Sid      : {0}", hangupCall.Sid);
            Console.WriteLine("Hangup Call Duration : {0}", hangupCall.Duration);
            Console.WriteLine("Hangup Call Status   : {0}", hangupCall.Status.ToString());

            Console.WriteLine();
            
            // We also can query TelApi service for avaliable phone number which we want to purchase.
            // We can also filter that list with various parameters
            // For example we will query for all avaliable US numbers

            var numbers = telApi.GetAvailablePhoneNumbers("US");
            foreach (var a in numbers.AvailablePhoneNumbers)
            {
                Console.WriteLine("Avaliable Phone Number : {0}", a.PhoneNumber);                
            }

            Console.WriteLine();

            // There is also options to query our own TelApi numbers that we purchased            
            
            var incomingNumbers = telApi.GetIncomingPhoneNumbers();
            foreach (var i in incomingNumbers.IncomingPhoneNumbers)
            {
                Console.WriteLine("Incoming Phone Number : {0}", i.PhoneNumber);
            }

            Console.WriteLine();

            // Telapi service provide us with Transcribing feauture. That means
            // that we can provide some external audio Url which Telapi will transcribe for us
            // and save result on our account which then we can get using TelApi api

            var transcribe = telApi.TranscribeAudio("http://www.some-external-audio-url.com");
            Console.WriteLine("Transcribe Sid     : {0}", transcribe.Sid);
            Console.WriteLine("Transcribe Started : {0}", transcribe.DateCreated);
            Console.WriteLine("Transcribe Status  : {0}", transcribe.Status.ToString());

            Console.WriteLine();

            // If we want to find some information about Phone or Landline numbers
            // we can use Carrier and CNAM lookup using TelApi service
            
            var carrier = telApi.CarrierLookup(PhoneNumberFrom);
            Console.WriteLine("Carrier Name         : {0}", carrier.Carrier);
            Console.WriteLine("Carrier Country      : {0}", carrier.Country);
            Console.WriteLine("Carrier Lookup Price : {0}", carrier.Price);

            Console.WriteLine();

            var cnams = telApi.CNAMLookup(PhoneNumberFrom);
            foreach (var cnam in cnams.CNAMDips)
            {
                Console.WriteLine("CNAM Body : {0}", cnam.Body);
            }

            // The End :)
            Console.WriteLine("The end :)");
            Console.ReadKey();            
        }
    }
}
