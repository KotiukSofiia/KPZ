using System;

namespace SupportSystem
{
    public class LevelThreeHandler : SupportHandler
    {
        public override void HandleRequest()
        {
            Console.WriteLine("Handling technical queries...");
            string response = GetUserResponse();

            if (response == "yes")
            {
                Console.WriteLine("Request resolved at Level 3.");
            }
            else if (nextHandler != null)
            {
                Console.WriteLine("Level 4.");
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
