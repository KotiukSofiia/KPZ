using System;
using DeviceFactory.Models;

namespace DeviceFactory.Factories
{
    public class IProneFactoryImpl : IProneFactory
    {
        public ILaptop CreateLaptop()
        {
            return new IProneLaptop();
        }

        public ISmartphone CreateSmartphone()
        {
            return new IProneSmartphone();
        }
    }

}

