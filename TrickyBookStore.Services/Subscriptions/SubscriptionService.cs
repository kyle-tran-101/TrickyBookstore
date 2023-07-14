using System;
using System.Collections.Generic;
using TrickyBookStore.Models;
using System.Linq;  

namespace TrickyBookStore.Services.Subscriptions;

public class SubscriptionService : ISubscriptionService
{
    public IList<Subscription> GetSubscriptions(params int[] ids)
    {
        return Store.Subscriptions.Data
            .Where(subscription => ids.Contains(subscription.Id))
            .ToList();
    }
}

