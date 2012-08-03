## TelAPI .NET Wrapper

This TelAPI .NET wrapper is an open source tool built for easy access to the [TelAPI.com](http://telapi.com) API infrastructure. TelAPI is a powerful cloud communications API built to enable your apps to send and receive SMS messages and phone calls — all while controlling the call flow. Some features are conferencing, phone calls, text-to-speech, recordings, transcriptions and much more.

For more information about what TelAPI is, please visit: [TelAPI Features](http://www.telapi.com/features) or [TelAPI REST documentation](http://www.telapi.com/docs/api/rest/)

What can you do with TelAPI? Here's an example SMS burglar alarm: https://github.com/mattwilliamson/arduino-sms-alarm

---

### REST Introduction

Everything you need to know how to use the TelAPI .NET Wrapper can be found in the [/examples directory](https://github.com/teltechsystems/telapi-dotnet/tree/master/example).
Just replace `{AccountSid}` and `{AuthToken}` with the values from your [TelAPI Account Dashboard](https://www.telapi.com/dashboard/).

##### Currently available REST API resources

* **accounts**                  - Fetch account details
* **sms_messages**              - Send or view SMS messages
* **calls**                     - View or place calls

##### Example usage - Sending an SMS

```c#
var telApi = new TelAPIRestClient("{your-account-sid}", "{your-auth-token}");

var message = telApi.SendSmsMessage("+12233312344", "+12233312345", "hello world!");
Console.WriteLine(message.Status);  
```


For more information such as which properties are available for existing resources, please visit [TelAPI REST Documenatation](http://www.telapi.com/docs/api/rest/)

----

