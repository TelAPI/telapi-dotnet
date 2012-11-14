using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using TelAPI;
using TelAPI.InboundXML;
using TelAPI.InboundXML.Enum;
using TelAPI.InboundXML.Element;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WinRT.Demo.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void btnGet_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(tbAccountSid.Text) || String.IsNullOrEmpty(tbAuthToken.Text))
            {
                var info = new MessageDialog("Account sid and Auth token are required fields!");
                await info.ShowAsync();

                return;
            }

            var telapi = new TelAPIRestClient(tbAccountSid.Text, tbAuthToken.Text);
            var messages = await telapi.GetSmsMessages();

            this.DataContext = messages.SmsMessages;
        }

        private async void btnGenerateInboundXML_Click(object sender, RoutedEventArgs e)
        {
            var response = new Response();

            response.Say("Hello", null, null)
                    .Say("This is automated message", Voice.woman, null)
                    .Say("From now I will record this call", Voice.man, null)
                    .Record("http://url-post.com", null, 5, "#", 30, null, null, true, null, null)
                    .Say("I will dial another number now.")
                    .Dial(Dial.Create("+1234556"))
                    .Play("url-to-play.com")
                    .GetSpeech(GetSpeech.Create("gramar-url.com", "action-url.com").Say("Pausing...", null, null).Pause())
                    .Say("I will hangup now. Goodbye!", null, null)
                    .Hangup();

            var info = new MessageDialog(response.CreateXml());
            await info.ShowAsync();
        }
    }
}
