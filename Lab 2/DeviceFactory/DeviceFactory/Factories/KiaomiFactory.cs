using System;
using DeviceFactory.Models;

namespace DeviceFactory.Factories
{
    public interface KiaomiFactory
    {
        ILaptop CreateLaptop();
        ISmartphone CreateSmartphone();
    }

}

