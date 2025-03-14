using System;
using DeviceFactory.Factories;
using DeviceFactory.Models;

class Program
{
    static void Main(string[] args)
    {
        IProneFactory iproneFactory = new IProneFactoryImpl();
        ILaptop iproneLaptop = iproneFactory.CreateLaptop();
        ISmartphone iproneSmartphone = iproneFactory.CreateSmartphone();

        Console.WriteLine("IProne Laptop: " + iproneLaptop.GetModel());
        Console.WriteLine("IProne Smartphone: " + iproneSmartphone.GetModel());

        KiaomiFactory kiaomiFactory = new KiaomiFactoryImpl();
        ILaptop kiaomiLaptop = kiaomiFactory.CreateLaptop();
        ISmartphone kiaomiSmartphone = kiaomiFactory.CreateSmartphone();

        Console.WriteLine("\nKiaomi Laptop: " + kiaomiLaptop.GetModel());
        Console.WriteLine("Kiaomi Smartphone: " + kiaomiSmartphone.GetModel());

        BalaxyFactory balaxyFactory = new BalaxyFactoryImpl();
        ILaptop balaxyLaptop = balaxyFactory.CreateLaptop();
        ISmartphone balaxySmartphone = balaxyFactory.CreateSmartphone();

        Console.WriteLine("\nBalaxy Laptop: " + balaxyLaptop.GetModel());
        Console.WriteLine("Balaxy Smartphone: " + balaxySmartphone.GetModel());
        Console.ReadLine();

    }
}
