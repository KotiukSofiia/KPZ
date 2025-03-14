using System;
using DeviceFactory.Models;

namespace DeviceFactory.Factories
{
    public interface BalaxyFactory
    {
        ILaptop CreateLaptop();
        ISmartphone CreateSmartphone();
    }

}

