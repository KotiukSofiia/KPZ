using System;
using SubscriptionforProvider.Models;

namespace SubscriptionforProvider.Creators
{
    public class MobileApp : ICreator
    {
        public ISubscription CreateSubscription()
        {
            return new PremiumSubscription();
        }
    }

}

