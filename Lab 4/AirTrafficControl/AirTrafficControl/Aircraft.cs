using System;
namespace DesignPatterns.Mediator
{
    class Aircraft
    {
        public string Name;
        public bool IsTakingOff { get; set; }
        private CommandCentre _commandCentre;

        public Aircraft(string name, CommandCentre commandCentre)
        {
            this.Name = name;
            this._commandCentre = commandCentre;
        }

        public void Land()
        {
            Console.WriteLine($"Aircraft {this.Name} is requesting to land.");
            _commandCentre.LandAircraft(this);
        }

        public void TakeOff()
        {
            Console.WriteLine($"Aircraft {this.Name} is requesting to take off.");
            _commandCentre.TakeOffAircraft(this);
        }
    }
}


