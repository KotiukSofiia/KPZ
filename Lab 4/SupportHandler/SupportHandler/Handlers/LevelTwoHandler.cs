using System;

namespace SupportSystem
{
    public class LevelTwoHandler : SupportHandler
    {
        public override void HandleRequest()
        {
            Console.WriteLine("Handling intermediate queries...");
            string response = GetUserResponse();

            if (response == "yes")
            {
                Console.WriteLine("Request resolved at Level 2.");
            }
            else if (nextHandler != null)
            {
                Console.WriteLine("Level 3.");
                nextHandler.HandleRequest();
            }
            else
            {
                Console.WriteLine("No further escalation possible.");
            }
        }

        private string GetUserResponse()
        {
            Console.WriteLine("Is your issue resolved? (yes/no)");
            return Console.ReadLine().ToLower();
        }
    }
}


