telapi-dotnet
==========

This .net library is an open source tool built to simplify interaction with the [TelAPI](http://telapi.com) telephony platform. TelAPI makes adding voice and SMS to applications fun and easy.

For this libraries full documentation visit: http://telapi.github.com/telapi-dotnet

For more information about TelAPI, please visit:  [telapi.com/features](http://www.telapi.com/features) or [telapi.com/docs](http://www.telapi.com/docs)

---

Installation
============

### Windows

Download the zip of this repo and add the desired DLLs to your project.

**Important!**

*If you are adding TelAPI functionality to a windows 8 metro app, you want the [WinRT DLLs](https://github.com/TelAPI/telapi-dotnet/tree/master/dll/WinRT).

*If you are using .NET to for web development or non-metro apps, you want the [net-3.5-4 DLLs](https://github.com/TelAPI/telapi-dotnet/tree/master/dll/net-3.5-4).

### Mac/Linux

The easiest way to work with C# on Mac or Linux is to download [Mono](http://mono-project.com/Main_Page), a cross platform .NET development framework.

Once Mono is set up, you can simply clone this repository:

`git clone git@github.com:TelAPI/telapi-dotnet.git`

Put the cloned repository somewhere your .NET project can access it and then link the [net-3.5-4 DLLs](https://github.com/TelAPI/telapi-dotnet/tree/master/dll/net-3.5-4) in Mono.

---

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
using System;
using TelAPI.InboundXML;
using TelAPI.InboundXML.Enum;
 
namespace TelAPI.InboundXML.Example
{
    public class SayExample
    {
        static void Main(string[] args)
        {
            var response = new Response();
            response.Say("Welcome to TelAPI. This is a sample InboundXML document.", Voice.man, null); 
            Console.WriteLine("{0}", response.CreateXml());
        }
    }
}  
```

will render

```xml
<?xml version="1.0" encoding="UTF-8"?>
<Response>
  <Say voice="man">Welcome to TelAPI. This is a sample InboundXML document.</Say>
</Response>
```
---

Documentation
=============
http://telapi.github.com/telapi-dotnet

