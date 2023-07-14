using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Store
{
    public static class Subscriptions
    {
        public static readonly IEnumerable<Subscription> Data = new List<Subscription>
        {
            new()
            {
                Id = 1, SubscriptionType = SubscriptionTypes.Paid,
                PriceDetails = new Dictionary<string, double>()
            },
            new()
            {
                Id = 2, SubscriptionType = SubscriptionTypes.Free,
                PriceDetails = new Dictionary<string, double>()
            },
            new()
            {
                Id = 3, SubscriptionType = SubscriptionTypes.Premium,
                PriceDetails = new Dictionary<string, double>()
            },
            new()
            {
                Id = 4, SubscriptionType = SubscriptionTypes.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>()
            },
            new()
            {
                Id = 5, SubscriptionType = SubscriptionTypes.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>(),
                BookCategoryId = 1
            },
            new()
            {
                Id = 6, SubscriptionType = SubscriptionTypes.CategoryAddicted,
                PriceDetails = new Dictionary<string, double>(),
                BookCategoryId = 3
            }
        }.Select(subscription =>
        {
            subscription.PriceDetails.Add("FixedPrice", subscription.SubscriptionType.Price);
            return subscription;
        });
    }
}