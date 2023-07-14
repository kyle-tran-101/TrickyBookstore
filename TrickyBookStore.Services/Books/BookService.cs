using System.Collections.Generic;
using TrickyBookStore.Models;
using System.Linq;

namespace TrickyBookStore.Services.Books;
public class BookService : IBookService
{
    public IList<Book> GetBooks(params long[] ids)
    {
        return Store.Books.Data
            .Where(book => ids.Contains(book.Id))
            .ToList();
    }
}

