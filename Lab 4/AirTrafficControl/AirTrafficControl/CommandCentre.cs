using System;
namespace DesignPatterns.Mediator
{
    class CommandCentre
    {
        private List<Runway> _runways = new List<Runway>();
        private List<Aircraft> _aircrafts = new List<Aircraft>();

        public CommandCentre(Runway[] runways, Aircraft[] aircrafts)
        {
            this._runways.AddRange(runways);
            this._aircrafts.AddRange(aircrafts);
        }

        public void LandAircraft(Aircraft aircraft)
        {
            foreach (var runway in _runways)
            {
                if (runway.IsBusyWithAircraft == null)
                {
                    Console.WriteLine($"Aircraft {aircraft.Name} is landing on runway {runway.Id}.");
                    runway.IsBusyWithAircraft = aircraft;
                    runway.HighLightRed();
                    return;
                }
            }
            Console.WriteLine($"Aircraft {aircraft.Name} cannot land. No available runway.");
        }

        public void TakeOffAircraft(Aircraft aircraft)
        {
            foreach (var runway in _runways)
            {
                if (runway.IsBusyWithAircraft == aircraft)
                {
                    Console.WriteLine($"Aircraft {aircraft.Name} is taking off from runway {runway.Id}.");
                    runway.IsBusyWithAircraft = null;
                    runway.HighLightGreen();
                    return;
                }
            }
            Console.WriteLine($"Aircraft {aircraft.Name} is not on any runway.");
        }
    }
}


