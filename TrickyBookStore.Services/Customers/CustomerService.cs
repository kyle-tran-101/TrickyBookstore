using System;
using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Store;
using TrickyBookStore.Services.Subscriptions;

namespace TrickyBookStore.Services.Customers;
public class CustomerService : ICustomerService
{
    ISubscriptionService SubscriptionService { get; }

    public CustomerService(ISubscriptionService subscriptionService)
    {
        SubscriptionService = subscriptionService;
    }

    public Customer GetCustomerById(long id)
    {
        return Store.Customers.Data
            .Where(customer => customer.Id == id)
            .Select
            (
                customer => handleSubscription(customer)
            )
            .FirstOrDefault();
    }

    private Customer handleSubscription(Customer customer)
    {
        if (customer.SubscriptionIds.Count < 1)
        {
            var freePlan = Store.Subscriptions.Data
                .Where(subscription => subscription.SubscriptionType == SubscriptionTypes.Free)
                .FirstOrDefault(); // add new Free Sub if not exits - need further inplementation

            if (customer.SubscriptionIds == null)
            {
                customer.SubscriptionIds = new List<int>();
            }
            customer.SubscriptionIds.Add(freePlan.Id);

            if (customer.Subscriptions == null)
            {
                customer.Subscriptions = new List<Subscription>();
            }
            customer.Subscriptions.Add(freePlan);
        }
        else
        {
            customer.Subscriptions = SubscriptionService
                .GetSubscriptions(customer.SubscriptionIds.ToArray())
                .ToList();
        }

        return customer;
    }
}

