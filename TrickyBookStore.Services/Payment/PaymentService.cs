using System;
using System.Linq;
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




    public double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
    {
        var customer = CustomerService.GetCustomerById(customerId);
        var purchase = PurchaseTransactionService.GetPurchaseTransactions(customerId, fromDate, toDate);
        double amount = 0;
        foreach (var trasaction in purchase)
        {
            List<long> 
            if (Utilities<long>.IsIncluded(customer.SubscriptionIds, SubscriptionTypes.))) {

            }            
        }


        throw new NotImplementedException();
    }
}
