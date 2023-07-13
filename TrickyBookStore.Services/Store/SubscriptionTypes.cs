using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Store
{
    public static class SubscriptionTypes
    {
        public static readonly IList<SubscriptionType> Data = new List<SubscriptionType>
        {
            new SubscriptionType {
                Id = 0,
                Name = "Free",
                OldBooksDiscount = 0.1
            },
            new SubscriptionType {
                Id = 1,
                Name = "Paid",
                Price = 50,
                OldBooksDiscount = 0.95,
                NewBooksDiscount = 0.05,
                NewBooksApplied = 3
            },
            new SubscriptionType {
                Id = 2,
                Name = "CategoryAddicted",
                Price = 75,
                OldBooksDiscount = 1,
                NewBooksDiscount = 0.15,
                NewBooksApplied = 3
            },
            new SubscriptionType {
                Id = 3,
                Name = "Premium",
                Price = 200,
                OldBooksDiscount = 1,
                NewBooksDiscount = 0.15,
                NewBooksApplied = 3
            },
        };

        public static SubscriptionType Free
        {
            get => Data[0];
        }

        public static SubscriptionType Paid
        {
            get => Data[1];
        }
        public static SubscriptionType CategoryAddicted
        {
            get => Data[2];
        }
        public static SubscriptionType Premium
        {
            get => Data[3];
        }
    }
}
