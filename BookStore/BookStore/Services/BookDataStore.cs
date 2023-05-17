using BookStore.Helpers;
using BookStore.Services.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    //TODO: Wypełnić!
    public class BookDataStore : AListDataStore<Book>
    {
        public override async Task<Book> AddItemToService(Book item)
        {
            return await _service.BookPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Book item)
        {
            return await _service.BookDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Book> Find(Book item)
        {
            return await _service.BookGETAsync(item.Id);
        }

        public override async Task<Book> Find(int id)
        {
            return await _service.BookGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = (await _service.BookAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(Book item)
        {
            return await _service.BookPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
