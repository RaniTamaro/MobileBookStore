using BookStore.Services.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    //TODO: Wypełnić!
    public class BookDataStore : AListDataStore<Book>
    {
        public override Task<Book> AddItemToService(Book item)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemFromService(Book item)
        {
            throw new NotImplementedException();
        }

        public override Task<Book> Find(Book item)
        {
            throw new NotImplementedException();
        }

        public override Task<Book> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Task RefreshListFromService()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateItemInService(Book item)
        {
            throw new NotImplementedException();
        }
    }
}
