using System;
using SubscriptionforProvider.Models;

namespace SubscriptionforProvider.Creators
{
    public class ManagerCall : ICreator
    {
        public ISubscription CreateSubscription()
        {
            return new EducationalSubscription();
        }
    }

}

