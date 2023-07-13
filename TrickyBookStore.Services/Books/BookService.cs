using System;
using System.Collections.Generic;
using TrickyBookStore.Models;
using System.Linq;

namespace TrickyBookStore.Services.Books;
internal class BookService : IBookService
{
    public IList<Book> GetBooks(params long[] ids)
    {
        return Store.Books.Data
            .Where(book => Utilities<long>.IsIncluded(ids, book.Id))
            .ToList();
    }
}

