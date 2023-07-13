using System;
using System.Collections.Generic;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Books;
using System.Linq;

namespace TrickyBookStore.Services.PurchaseTransactions;

internal class PurchaseTransactionService : IPurchaseTransactionService
{
    IBookService BookService { get; }

    public PurchaseTransactionService(IBookService bookService)
    {
        BookService = bookService;
    }

    public IList<PurchaseTransaction> GetPurchaseTransactions(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
    {
        return Store.PurchaseTransactions.Data
            .Where
            (
                transaction =>
                    transaction.CustomerId == customerId &&
                    transaction.CreatedDate >= fromDate &&
                    transaction.CreatedDate <= toDate
            )
            .Select
            (
                transaction =>
                {
                    transaction.Book = BookService
                        .GetBooks(transaction.Id)
                        .FirstOrDefault();
                    return transaction;
                }
            )
            .ToList();
    }
}

