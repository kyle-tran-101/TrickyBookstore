using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Customers;
using TrickyBookStore.Services.PurchaseTransactions;
using TrickyBookStore.Services.Store;

namespace TrickyBookStore.Services.Payment;

public class PaymentService : IPaymentService
{
    ICustomerService CustomerService { get; }
    IPurchaseTransactionService PurchaseTransactionService { get; }

    public PaymentService(ICustomerService customerService,
        IPurchaseTransactionService purchaseTransactionService)
    {
        CustomerService = customerService;
        PurchaseTransactionService = purchaseTransactionService;
    }

    public static double HandlePreferred(Book book, Subscription subscription)
    {
        var subscriptionType = subscription.SubscriptionType;
        var price = book.Price;

        if (book.IsOld)
        {
            price *= (1.0 - subscriptionType.OldBooksDiscount);
        }
        else if (subscriptionType.NewBooksApplied == SubscriptionType.All &&
                 subscriptionType.NewBooksApplied >= Convert.ToInt32(subscription.PriceDetails["NewBook"]))
        {
            price *= (1.0 - subscriptionType.NewBooksDiscount);
            subscription.PriceDetails["NewBook"] += 1;
        }

        return price;
    }

    public double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
    {
        var customer = CustomerService.GetCustomerById(customerId);

        var purchaseList = PurchaseTransactionService.GetPurchaseTransactions(customerId, fromDate, toDate);

        var preferenceList = customer.Subscriptions
            .Where(item => item.BookCategoryId != null)
            .ToList();

        double price = customer.Subscriptions.Aggregate(0.0, (prev, next) => prev + next.PriceDetails["FixedPrice"]);
        foreach (var item in purchaseList)
        {

            // Handle CategoryAddicted when a Category is in Preference List 
            var selection = preferenceList
                .Where(preference => preference.BookCategoryId == item.Book.CategoryId)
                .ToList();

            if (selection.Count > 0)
            {
                price += HandlePreferred(item.Book, selection.First());
                continue;
            }
            var bestPlan = customer.Subscriptions
                .OrderByDescending(plan => plan.SubscriptionType.Id)
                .ThenBy(plan => plan.PriceDetails["NewBook"])
                .First();

            price += HandlePreferred(item.Book, bestPlan);
        }


        return price;
    }
}