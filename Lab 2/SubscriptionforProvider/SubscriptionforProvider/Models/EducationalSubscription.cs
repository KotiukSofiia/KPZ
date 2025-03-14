using System;
namespace SubscriptionforProvider.Models
{
    public class EducationalSubscription : Subscription
    {
        public EducationalSubscription()
        {
            MonthlyFee = 15.99m;
            MinimumSubscriptionPeriod = 3;
            Channels = new List<string> { "Educational Channel 1", "Educational Channel 2" };
            Features = new List<string> { "Access to Courses", "Ads Free" };
        }
    }

}

