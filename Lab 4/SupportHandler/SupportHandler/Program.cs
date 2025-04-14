using System;

namespace SupportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Створення обробників
            SupportHandler levelOne = new LevelOneHandler();
            SupportHandler levelTwo = new LevelTwoHandler();
            SupportHandler levelThree = new LevelThreeHandler();
            SupportHandler levelFour = new LevelFourHandler();

            // Налаштовуємо ланцюжок обробників
            levelOne.SetNextHandler(levelTwo);
            levelTwo.SetNextHandler(levelThree);
            levelThree.SetNextHandler(levelFour);

            // Запуск процесу запиту
            Console.WriteLine("Welcome to the Support System!");
            levelOne.HandleRequest();

            Console.ReadLine();
        }
    }
}
