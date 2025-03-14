using System;
using SubscriptionforProvider.Models;

namespace SubscriptionforProvider.Creators
{
    public class WebSite : ICreator
    {
        public ISubscription CreateSubscription()
        {
            return new DomesticSubscription();  
        }
    }

}

