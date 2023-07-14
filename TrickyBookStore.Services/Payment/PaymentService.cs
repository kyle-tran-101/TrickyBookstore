using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Customers;
using TrickyBookStore.Services.PurchaseTransactions;
using TrickyBookStore.Services.Store;

namespace TrickyBookStore.Services.Payment;

internal class PaymentService : IPaymentService
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
        if (subscription.BookCategoryId != null)
        {
            return price;
        } 
        
        if (book.IsOld)
        {
            price *= (1 - subscriptionType.OldBooksDiscount);
        }
        // PriceDetails includes FixedPrice, so check it by subtracting its Count by 1 
        else if (subscriptionType.NewBooksApplied == SubscriptionType.All &&
                 subscriptionType.NewBooksApplied >= subscription.PriceDetails.Count - 1)
        {
            price *= (1 - subscriptionType.NewBooksDiscount);
        }

        return price;
    }

    public double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
    {
        var customer = CustomerService.GetCustomerById(customerId);

        var purchaseList = PurchaseTransactionService.GetPurchaseTransactions(customerId, fromDate, toDate);

        


        return 0.0;
    }
}