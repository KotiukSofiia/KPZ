using System;
using DeviceFactory.Models;

namespace DeviceFactory.Factories
{
    public class KiaomiFactoryImpl : KiaomiFactory
    {
        public ILaptop CreateLaptop()
        {
            return new KiaomiLaptop();
        }

        public ISmartphone CreateSmartphone()
        {
            return new KiaomiSmartphone();
        }
    }

}

