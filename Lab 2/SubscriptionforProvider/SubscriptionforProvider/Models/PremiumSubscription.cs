using System;
namespace SubscriptionforProvider.Models
{
    public class PremiumSubscription : Subscription
    {
        public PremiumSubscription()
        {
            MonthlyFee = 29.99m;
            MinimumSubscriptionPeriod = 6;
            Channels = new List<string> { "Premium Channel 1", "Premium Channel 2" };
            Features = new List<string> { "4K Streaming", "No Ads", "Exclusive Content" };
        }
    }

}

