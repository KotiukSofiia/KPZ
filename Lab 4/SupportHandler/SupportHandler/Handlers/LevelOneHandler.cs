using System;
using System;

namespace SupportSystem
{
    public class LevelOneHandler : SupportHandler
    {
        public override void HandleRequest()
        {
            Console.WriteLine("Level 1: Handling basic queries...");
            string response = GetUserResponse();

            if (response == "yes")
            {
                Console.WriteLine("Request resolved at Level 1.");
            }
            else if (nextHandler != null)
            {
                Console.WriteLine("Level 2.");
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
