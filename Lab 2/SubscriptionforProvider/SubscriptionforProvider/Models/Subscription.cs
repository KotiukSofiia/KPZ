using System;
namespace SubscriptionforProvider.Models
{
    public abstract class Subscription : ISubscription
    {
        public decimal MonthlyFee { get; protected set; }
        public int MinimumSubscriptionPeriod { get; protected set; }
        public List<string> Channels { get; protected set; }
        public List<string> Features { get; protected set; }

        public string GetSubscriptionDetails()
        {
            var channels = string.Join(", ", Channels);
            var features = string.Join(", ", Features);
            return $"Monthly Fee: {MonthlyFee} USD, Minimum Subscription Period: {MinimumSubscriptionPeriod} months, Channels: {channels}, Features: {features}";
        }
    }

}

