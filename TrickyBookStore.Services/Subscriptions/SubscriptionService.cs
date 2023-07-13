using System;
using System.Collections.Generic;
using TrickyBookStore.Models;
using System.Linq;  

namespace TrickyBookStore.Services.Subscriptions;

internal class SubscriptionService : ISubscriptionService
{
    public IList<Subscription> GetSubscriptions(params int[] ids)
    {
        return Store.Subscriptions.Data
            .Where(subscription => Utilities<int>.IsIncluded(ids, subscription.Id))
            .ToList();
    }
}

