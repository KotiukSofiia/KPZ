using System;
using DeviceFactory.Models;

namespace DeviceFactory.Factories
{
    public class BalaxyFactoryImpl : BalaxyFactory
    {
        public ILaptop CreateLaptop()
        {
            return new BalaxyLaptop();
        }

        public ISmartphone CreateSmartphone()
        {
            return new BalaxySmartphone();
        }
    }

}

