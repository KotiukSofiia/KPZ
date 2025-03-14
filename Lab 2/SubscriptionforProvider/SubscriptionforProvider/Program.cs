using SubscriptionforProvider.Creators;
using SubscriptionforProvider.Models;

class Program
{
    static void Main()
    {
        ICreator websiteCreator = new WebSite();
        ISubscription websiteSubscription = websiteCreator.CreateSubscription();
        Console.WriteLine("WebSite Subscription: ");
        Console.WriteLine(websiteSubscription.GetSubscriptionDetails());

        ICreator appCreator = new MobileApp();
        ISubscription appSubscription = appCreator.CreateSubscription();
        Console.WriteLine("\nMobileApp Subscription: ");
        Console.WriteLine(appSubscription.GetSubscriptionDetails());

        ICreator managerCreator = new ManagerCall();
        ISubscription managerSubscription = managerCreator.CreateSubscription();
        Console.WriteLine("\nManagerCall Subscription: ");
        Console.WriteLine(managerSubscription.GetSubscriptionDetails());

        Console.ReadLine();
    }
}