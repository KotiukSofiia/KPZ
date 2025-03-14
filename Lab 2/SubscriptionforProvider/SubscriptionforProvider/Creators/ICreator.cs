using System;
using SubscriptionforProvider.Models;

namespace SubscriptionforProvider.Creators
{
    public interface ICreator
    {
        ISubscription CreateSubscription();
    }

}

