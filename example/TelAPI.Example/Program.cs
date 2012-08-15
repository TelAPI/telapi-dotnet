using System;
using System.Threading;
using TelAPI.InboundXML;
using TelAPI.InboundXML.Element;

namespace TelAPI.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //var telApi = new TelAPIRestClient("{your-account-sid}", "{your-auth-token}");
            
            // another way of creating client with config class
            // var telApi = new TelAPIRestClient(new DefaultTelAPIConfiguration());

            //var account = telApi.GetAccount();
            //Console.WriteLine("Account Balance : {0}", account.AccountBalance);

            //Console.WriteLine("-------------------------------------------");

            //Console.WriteLine("SMSMessage GET");

            //try
            //{
            //    var smsMessage = telApi.GetSmsMessage("just-fake-sid");
            //    Console.WriteLine("SMS : {0}", smsMessage.Status);
            //}
            //catch (TelAPIException ex)
            //{
            //    Console.WriteLine(ex.Message);

            //}

            //Console.WriteLine("-------------------------------------------");

            //Console.WriteLine("SMSMessages  GET LIST");
            //var messages = telApi.GetSmsMessages();
            //foreach (var m in messages.SmsMessages)
            //{
            //    Console.WriteLine("From : {0}", m.From);
            //    Console.WriteLine("To : {0}", m.To);
            //    Console.WriteLine("Body : {0}", m.Body);
            //}

            //Console.WriteLine("SMSMessages  GET LIST - Condition");
            //var messagesWithCondition = telApi.GetSmsMessages(new SmsMessageListOptions
            //{
            //    To = "++1234567899",
            //    PageSize = 3
            //});

            //foreach (var m in messagesWithCondition.SmsMessages)
            //{
            //    Console.WriteLine("From : {0}", m.From);
            //    Console.WriteLine("To : {0}", m.To);
            //    Console.WriteLine("Body : {0}", m.Body);
            //}

            //Console.WriteLine("-------------------------------------------");

            //Console.WriteLine("SMSMessages SEND");
            //var message = telApi.SendSmsMessage("+1234567898", "+1234567899", "hello world from telapi-dotnet lib");
            //Console.WriteLine(message.Status);  

            //Console.WriteLine("Calls GET");
            //var calls = telApi.GetCalls();
            //foreach (var c in calls.Calls)
            //{
            //    Console.WriteLine("From : {0}", c.From);
            //    Console.WriteLine("To : {0}", c.To);
            //    Console.WriteLine("Price : {0}", c.Price);
            //    Console.WriteLine("Duration : {0}", c.Duration);
            //}


            //Console.WriteLine("-------------------------------------------");

            //Console.WriteLine("Calls GET - condition");
            //var callsCondition = telApi.GetCalls(new CallListOptions
            //{
            //    To = "+1234567899",
            //    PageSize = 2
            //});

            //foreach (var c in callsCondition.Calls)
            //{
            //    Console.WriteLine("From : {0}", c.From);
            //    Console.WriteLine("To : {0}", c.To);
            //    Console.WriteLine("Price : {0}", c.Price);
            //    Console.WriteLine("Duration : {0}", c.Duration);
            //}

            //Console.WriteLine("-------------------------------------------");

            // wait 5 seconds and do few call actions
            //Thread.Sleep(5000);

            //var call = telApi.MakeCall("+1234567899", "+1234567899", "http://www.xyz.com/fake-fake");
            //Console.WriteLine("Call : {0} -> {1}", call.Sid, call.Status);

            //var digits = telApi.SendDigits(call.Sid, "www12www", null);
            //Console.WriteLine("Send digits : {0}", digits.DateUpdated);

            //var audio = telApi.PlayAudio(call.Sid, "http://www.xyz.com/sound.fake.mp3");
            //Console.WriteLine("Play audio : {0}", audio.DateUpdated);

            //var effect = telApi.VoiceEffects(call.Sid, new VoiceEffectOptions
            //{
            //    Pitch = 0,
            //    Rate = 1
            //});
            //Console.WriteLine("Voice effect : {0}", effect.DateUpdated);

            //var record = telApi.RecordCall(call.Sid, true);
            //Console.WriteLine("Recording call [START] - {0} : {1}", record.Sid, record.Status);

            //Thread.Sleep(5000);

            //var stopRecord = telApi.RecordCall(call.Sid, false);
            //Console.WriteLine("Recording call [STOP] -  {0} : {1}", record.Sid, record.Status);

            //Thread.Sleep(5000);

            //var interrupt = telApi.InterruptLiveCall(call.Sid, "http://www.xyz.com/call", HttpMethod.Get, HangupCallStatus.Canceled);
            //Console.WriteLine("Interrupt live call [CANCELED] : {0}", interrupt.Status);

            //var hangupCall = telApi.HangupCall(call.Sid);
            //Console.WriteLine("Call {0} ended", hangupCall.Sid);

            //try
            //{
            //    var notification = telApi.GetNotification("neki-fake-sid");
            //}
            //catch (TelAPIException e)
            //{
            //    Console.WriteLine("Notification : {0}", e.Message);
            //}

            //Console.WriteLine("Account Notification - GET");
            //var accountNotifications = telApi.GetAccountNotifications(NotificationLog.Info, 1, 2);
            //foreach (var an in accountNotifications.Notifications)
            //{
            //    Console.WriteLine("Account notification : {0}", an.ErrorCode);
            //}

            //Console.WriteLine("Avaliable phone numbers - GET");
            //var avaliableNum = telApi.GetAvailablePhoneNumbers("US");
            //foreach (var a in avaliableNum.AvailablePhoneNumbers)
            //{
            //    Console.WriteLine("Avaliable phone number : {0}", a.PhoneNumber);
            //}

            //Console.WriteLine("Incoming phone numbers - GET LIST");
            //var numbers = telApi.GetIncomingPhoneNumbers();
            //foreach (var num in numbers.IncomingPhoneNumbers)
            //{
            //    Console.WriteLine("Incoming phone numbers : {0}", num.PhoneNumber);
            //}

            //Console.WriteLine("Buy incoming phone number - ADD");
            //try
            //{
            //    var buy = telApi.AddIncomingPhoneNumber(avaliableNum.AvailablePhoneNumbers[0].PhoneNumber, avaliableNum.AvailablePhoneNumbers[0].NPA);
            //    Console.WriteLine("New number : {0} ({1})", buy.PhoneNumber, buy.DateCreated);
            //}
            //catch (TelAPIException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //try
            //{
            //    var delete = telApi.DeleteIncomingPhoneNumber(numbers.IncomingPhoneNumbers[0].Sid);
            //    Console.WriteLine("Delete phone number : {0} ({1}", delete.PhoneNumber, delete.DateUpdated);
            //}
            //catch (TelAPIException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //var n = numbers.IncomingPhoneNumbers[0];
            //n.SmsFallbackUrl = "http://www.fakeaddress.com/sms-fallback";
            //var updatedNumber = telApi.UpdateIncomingPhoneNumber(n);
            //Console.WriteLine("Updated number : {0} ({1}", updatedNumber.SmsFallbackUrl, updatedNumber.DateUpdated);

            //Console.WriteLine("New application - GET");
            //var app = telApi.CreateApplication(new Application
            //{
            //    FriendlyName = "renato app #2"
            //});
            //Console.WriteLine("APP : {0}", app.DateCreated);

            //Console.WriteLine("List app - GET");
            //var singleApp = telApi.GetApplication("adsfasdfasdfasd");
            //Console.WriteLine("APP :");

            //Console.WriteLine("Applications - GET LIST");
            //var apps = telApi.GetApplications();
            //foreach (var a in apps.Applications)
            //{
            //    Console.WriteLine("App : {0}", a.FriendlyName);
            //}

            //var applicationEdit = apps.Applications[1];
            //applicationEdit.FriendlyName = "renato edit putem api-ja";
            //applicationEdit.HangupCallbackMethod = "GET";
            //telApi.UpdateApplication(applicationEdit);

            //telApi.DeleteApplication(applicationEdit.Sid);

            //var recordings = telApi.GetAccountRecordings();
            //foreach (var r in recordings.Recordings)
            //{
            //    Console.WriteLine("Record : {0}", r.RecordingUrl);
            //}

            //var transcription = telApi.GetAccountTranscriptions();
            //foreach (var t in transcription.Transcriptions)
            //{
            //    Console.WriteLine("Transcription : {0}", t.TranscriptionText);
            //}

            //var text = telApi.GetTranscriptionText(transcription.Transcriptions[1].Sid);
            //Console.WriteLine("Text : {0}", text);

            //var transcribe = telApi.TranscribeAudio("http://www.freeinfosociety.com/media/sounds/13.mp3");
            //Console.WriteLine("Transcribe started : {0}", transcribe.TranscriptionText);

            //var carrier = telApi.CarrierLookup("+12408446005");
            //Console.WriteLine("Carrier : {0}, {1}", carrier.Carrier, carrier.Country);

            //var cnam = telApi.CNAMLookup("+12408446005");
            //Console.WriteLine("CNAM : {0}, {1}", cnam.Body, cnam.Price);

            //var frauds = telApi.GetFraudControlResources();
            //foreach (var f in frauds.Frauds)
            //{
            //    Console.WriteLine("Resources : {0}", f.Outbound.MaxOutboundRate);
            //}

            var response = new Response();
            response.Say("Test");
            response.Dial(Dial.Create("+385989189623", "http://www.google.com", InboundXML.Enum.HttpMethod.POST, 5000, null, null, null, null, null, null, null, null, null, null, null, null, null).Number("+385989189623", "*121*", null, null));
            response.Sms("hello from inboundXml", "+385989189623", "+385918762345");
            response.Gather(Gather.Create("http://www.gather.com").Play("jupi", 102));
            response.Hangup();
            response.Hangup(5);
            response.Pause();
            response.Pause(10);
            response.Play("http://www.play.com");
            response.Play("http://www.play.com/null", 10);
            response.Redirect("http://www.google.com");
            response.Reject();
            response.Reject(InboundXML.Enum.RejectReason.busy);
            response.Record("http://www.record.com");
            response.Record("http://www.record.com/null", null, 100, "*", 10, true, null, true, true, InboundXML.Enum.RecordingFileFormat.mp3);
            response.GetSpeech(GetSpeech.Create("http://www.grammar.com", "http://www.action.com").Say("Hello", null, null));
            response.Gather(Gather.Create("http://www.gather.com").Pause());
            
            
            var xml = response.CreateXml();

            Console.ReadKey();   
         
            // the end :)
        }
    }
}
