using BookStore.Services.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    //TODO: Wypełnić!
    public class GenreDataStore : AListDataStore<Genre>
    {
        public override Task<Genre> AddItemToService(Genre item)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemFromService(Genre item)
        {
            throw new NotImplementedException();
        }

        public override Task<Genre> Find(Genre item)
        {
            throw new NotImplementedException();
        }

        public override Task<Genre> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Task RefreshListFromService()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateItemInService(Genre item)
        {
            throw new NotImplementedException();
        }
    }
}
