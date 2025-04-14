using System;
namespace DesignPatterns.Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Runway runway1 = new Runway();
            Runway runway2 = new Runway();
            CommandCentre commandCentre = new CommandCentre(new[] { runway1, runway2 }, new Aircraft[0]);

            Aircraft aircraft1 = new Aircraft("Aircraft1", commandCentre);
            Aircraft aircraft2 = new Aircraft("Aircraft2", commandCentre);

            aircraft1.Land();
            aircraft2.Land();

            aircraft1.TakeOff();
            aircraft2.TakeOff();
            Console.ReadLine();
        }
    }
}
