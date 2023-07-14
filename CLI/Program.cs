// See https://aka.ms/new-console-template for more informationpublic class Program
using System;
using Microsoft.Extensions.DependencyInjection;
using TrickyBookStore.Services.Books;
using TrickyBookStore.Services.Customers;
using TrickyBookStore.Services.Payment;
using TrickyBookStore.Services.PurchaseTransactions;
using TrickyBookStore.Services.Subscriptions;

public class Program
{
    public static void Main(string[] args)
    {
        //setup our DI
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IBookService, BookService>()
            .AddSingleton<ICustomerService, CustomerService>()
            .AddSingleton<IPaymentService, PaymentService>()
            .AddSingleton<IPurchaseTransactionService, PurchaseTransactionService>()
            .AddSingleton<ISubscriptionService, SubscriptionService>()
            .BuildServiceProvider();

        //configure console logging
        Console.WriteLine("###############################");
        Console.WriteLine("Trick Book Store - Your payment");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Input year (E.g: 2018)");
        int year = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Input month (E.g: 1)");
        int month = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Input customer ID (E.g: 1)");
        long customerId = Convert.ToInt32(Console.ReadLine());

        DateTimeOffset startDate = new DateTimeOffset(new DateTime(year, month, 1));
        DateTimeOffset endDate = startDate.AddMonths(1).AddDays(-1);

        //do the actual work here
        try
        {
            var payment = serviceProvider.GetService<IPaymentService>();
            if (payment == null) throw new DllNotFoundException();
            Console.WriteLine(payment.GetPaymentAmount(customerId, startDate, endDate));
        }
        catch (DllNotFoundException)
        {
            Console.WriteLine("[ERROR] Missing DLLs");
        }
        catch (Exception error)
        {
            string msg = error.Message;
            while (error.InnerException != null)
            {
                var inner = error.InnerException;
                msg += $"\n\t{inner.Message}";
                error = error.InnerException;
            }
            Console.WriteLine($"[ERROR] Undefined Error Occurred: {msg}");
        }
    }
}
