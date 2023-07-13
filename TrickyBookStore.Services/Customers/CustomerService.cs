﻿using System;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Subscriptions;

namespace TrickyBookStore.Services.Customers;
internal class CustomerService : ICustomerService
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
                customer => 
                {
                    customer.Subscriptions = SubscriptionService
                        .GetSubscriptions(customer.SubscriptionIds.ToArray())
                        .ToList();
                    return customer;
                }
            )
            .FirstOrDefault();
    }
}

