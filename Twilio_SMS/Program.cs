using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio_SMS.Model;

namespace Twilio_SMS
{
    class Program
    {
        // Substitute this with your Twilio account in the format:
        // AccountSid
        // AuthToken
        // Twilio phone number
        private const string FilePath = @"F:\Asp.NetProjects\Twilio_SMS\twilioAccount.txt"; 
        static void Main(string[] args)
        {
            // Init a TwilioAccount object. Get Sid, authToken, and set fromNumber
            TwilioAccount twilioAccount = new TwilioAccount();
            twilioAccount.GetSidAndAuthToken(FilePath);
            twilioAccount.SetFromNumber(FilePath);
            TwilioClient.Init(twilioAccount.AccountSid, twilioAccount.AuthToken);

            // Ask user for the number and message content
            Console.WriteLine("Quick and dirty test of Twilio");
            Console.WriteLine("Enter a message: ");
            string msgContent = Console.ReadLine();
            Console.WriteLine("Message entered: " + msgContent);
            Console.WriteLine("Enter phone#: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Phone# entered: " + msgContent);

            // Send message
            twilioAccount.SendMessage(msgContent, phoneNumber);
            
            // Exit
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

        }
    }
}
