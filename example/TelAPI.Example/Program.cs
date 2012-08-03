using System;

namespace TelAPI.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var telApi = new TelAPIRestClient("{your-account-sid}", "{your-auth-token}");
            //var telApi = new TelAPIRestClient(new DefaultTelAPIConfiguration());

            var account = telApi.GetAccount();
            Console.WriteLine("Account Balance : {0}", account.AccountBalance);

            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("SMSMessage GET");

            try
            {
                var smsMessage = telApi.GetSmsMessage("fake-sid");
                Console.WriteLine("SMS : {0}", smsMessage.Status);
            }
            catch (TelAPIException ex)
            {
                Console.WriteLine(ex.Message);

            }

            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("SMSMessages  GET LIST");
            var messages = telApi.GetSmsMessages();
            foreach (var m in messages.SmsMessages)
            {
                Console.WriteLine("From : {0}", m.From);
                Console.WriteLine("To : {0}", m.To);
                Console.WriteLine("Body : {0}", m.Body);
            }

            Console.WriteLine("SMSMessages  GET LIST - Condition");
            var messagesWithCondition = telApi.GetSmsMessages(new SmsMessageListOptions
            {
                To = "+12233312345",
                PageSize = 3
            });

            foreach (var m in messagesWithCondition.SmsMessages)
            {
                Console.WriteLine("From : {0}", m.From);
                Console.WriteLine("To : {0}", m.To);
                Console.WriteLine("Body : {0}", m.Body);
            }

            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("SMSMessages SEND");
            var message = telApi.SendSmsMessage("+12233312344", "+12233312345", "hello world!");
            Console.WriteLine(message.Status);  

            Console.WriteLine("Calls GET");
            var calls = telApi.GetCalls();
            foreach (var c in calls.Calls)
            {
                Console.WriteLine("From : {0}", c.From);
                Console.WriteLine("To : {0}", c.To);
                Console.WriteLine("Price : {0}", c.Price);
                Console.WriteLine("Duration : {0}", c.Duration);
            }


            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("Calls GET - condition");
            var callsCondition = telApi.GetCalls(new CallListOptions
            {
                To = "+12233312345",
                PageSize = 2
            });

            foreach (var c in callsCondition.Calls)
            {
                Console.WriteLine("From : {0}", c.From);
                Console.WriteLine("To : {0}", c.To);
                Console.WriteLine("Price : {0}", c.Price);
                Console.WriteLine("Duration : {0}", c.Duration);
            }

            Console.WriteLine("-------------------------------------------");

            Console.ReadKey();

            var call = telApi.MakeCall("+12233312344", "+12233312345", "http://www.fake.com/fake-fake");
            Console.WriteLine("Call : {0} -> {1}", call.Sid, call.Status);

            Console.ReadKey();

            var hangupCall = telApi.HangupCall(call.Sid);
            Console.WriteLine("Call {0} ended", hangupCall.Sid);

            Console.ReadKey();
        }
    }
}
