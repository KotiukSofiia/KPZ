using System;
using DeviceFactory.Models;

namespace DeviceFactory.Factories
{
    public interface IProneFactory
    {
        ILaptop CreateLaptop();
        ISmartphone CreateSmartphone();
    }
}

