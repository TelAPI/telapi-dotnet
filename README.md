telapi-dotnet
==========

This .net library is an open source tool built to simplify interaction with the [TelAPI](http://telapi.com) telephony platform. TelAPI makes adding voice and SMS to applications fun and easy.

For more information about TelAPI, please visit:  [telapi.com/features](http://www.telapi.com/features) or [telapi.com/docs](http://www.telapi.com/docs)

---

Installation
============

Usage
======

### REST

[TelAPI REST API documenatation](http://www.telapi.com/docs/api/rest/) 

##### Send SMS Example

```csharp
using System;
using TelAPI;
 
namespace TelAPI.Example
{
    public class SendSmsMessage
    {
        public static void Main(string[] args)
        {
            var client = new TelAPIRestClient(
                "********************************", 
                "********************************"
            );
 
            try
            {
                var sms = client.SendSmsMessage(
                    "(XXX) XXX-XXXX",
                    "(XXX) XXX-XXXX",
                    "This is an SMS message sent from the TelAPI .NET helper! Easy as 1, 2, 3!",
                );
                Console.WriteLine("Sms Sid : {0}", sms.Sid);
            }
            catch (TelAPIException ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }
    }
}
```

### InboundXML

InboundXML is an XML dialect which enables you to control phone call flow. For more information please visit the [TelAPI InboundXML documenatation](http://www.telapi.com/docs/api/inboundxml/)

##### <Say> Example

```csharp
var telApi = new TelAPIRestClient("{your-account-sid}", "{your-auth-token}");

var message = telApi.SendSmsMessage("+12233312344", "+12233312345", "hello world!");
Console.WriteLine(message.Status);   
```

will render

```xml
<?xml version="1.0" encoding="UTF-8"?>
<Response>
  <Say voice="man">Welcome to TelAPI. This is a sample InboundXML document.</Say>
</Response>
```

---
