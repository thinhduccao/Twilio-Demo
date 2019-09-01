using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Twilio_SMS.Model
{
    class TwilioAccount
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string FromNumber { get; set; }


        /// <summary>
        /// Get twilio's account sid and token from at text file
        /// </summary>
        /// <param name="filePath"></param>
        public void GetSidAndAuthToken(string filePath)
        {
            try
            {
                string[] lines = File.ReadLines(filePath).ToArray();
                AccountSid = lines[0];
                AuthToken = lines[1];
            }
            catch (Exception)
            {
                ThrowConfigException();
            }
            
        }

        /// <summary>
        /// Set the number where we will be sending sms from
        /// </summary>
        /// <param name="filePath"></param>
        public void SetFromNumber(string filePath)
        {
            try
            {
                string[] lines = File.ReadLines(filePath).ToArray();
                FromNumber = lines[2];
            }
            catch (Exception)
            {
                ThrowConfigException();
            }
        }

        /// <summary>
        /// Send message to entered phone number
        /// </summary>
        /// <param name="msgContent"></param>
        /// <param name="toNumber"></param>
        public void SendMessage(string msgContent, string toNumber)
        {
            string formattedToNumber = "+1" + toNumber;
            StringBuilder summary = new StringBuilder("Summary: ");
            summary.AppendLine("Message content: " + msgContent);
            summary.AppendLine("Send to: " + formattedToNumber);
            try
            {
                var message = MessageResource.Create(
                    body: msgContent,
                    from: new Twilio.Types.PhoneNumber(FromNumber),
                    to: new Twilio.Types.PhoneNumber(formattedToNumber)
                );
                summary.AppendLine("Status: Successful!");
            }
            catch (Exception e)
            {
                summary.AppendLine("Status: Unsuccessful! See below for error");
                summary.AppendLine(e.ToString());
            }
            Console.WriteLine(summary.ToString());
        }

        /// <summary>
        /// Throw config file exception
        /// </summary>
        private void ThrowConfigException()
        {
            Console.WriteLine("Please make check your credential file!");
            throw new Exception("Config file is in the wrong format!");
        }
    }
}
