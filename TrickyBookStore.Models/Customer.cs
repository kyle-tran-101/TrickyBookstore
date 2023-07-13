using System.Collections.Generic;

namespace TrickyBookStore.Models;

public class Customer
{
    public long Id { get; set; }
    public string Name { get; set; }
    public IList<int> SubscriptionIds { get; set; }

    public IList<Subscription> Subscriptions { get; set; }
}

