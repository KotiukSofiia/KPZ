using System;
namespace SubscriptionforProvider.Models
{
    public interface ISubscription
    {
        decimal MonthlyFee { get; }
        int MinimumSubscriptionPeriod { get; }
        List<string> Channels { get; }
        List<string> Features { get; }
        string GetSubscriptionDetails();
    }

}

