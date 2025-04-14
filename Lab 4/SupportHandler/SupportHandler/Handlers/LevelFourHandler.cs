using System;

namespace SupportSystem
{
    public class LevelFourHandler : SupportHandler
    {
        public override void HandleRequest()
        {
            Console.WriteLine("Handling complex technical issues...");
            string response = GetUserResponse();

            if (response == "yes")
            {
                Console.WriteLine("Request resolved at Level 4.");
            }
            else
            {
                Console.WriteLine("Request cannot be resolved. Please contact support team.");
            }
        }

        private string GetUserResponse()
        {
            Console.WriteLine("Is your issue resolved? (yes/no)");
            return Console.ReadLine().ToLower();
        }
    }
}
