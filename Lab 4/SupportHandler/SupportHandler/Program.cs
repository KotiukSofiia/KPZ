using System;

namespace SupportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            SupportHandler levelOne = new LevelOneHandler();
            SupportHandler levelTwo = new LevelTwoHandler();
            SupportHandler levelThree = new LevelThreeHandler();
            SupportHandler levelFour = new LevelFourHandler();

            levelOne.SetNextHandler(levelTwo);
            levelTwo.SetNextHandler(levelThree);
            levelThree.SetNextHandler(levelFour);

            Console.WriteLine("Welcome to the Support System!");
            levelOne.HandleRequest();

            Console.ReadLine();
        }
    }
}
