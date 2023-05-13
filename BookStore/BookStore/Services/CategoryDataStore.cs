using BookStore.Services.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    //TODO: Wypełnić!
    public class CategoryDataStore : AListDataStore<Category>
    {
        public override Task<Category> AddItemToService(Category item)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemFromService(Category item)
        {
            throw new NotImplementedException();
        }

        public override Task<Category> Find(Category item)
        {
            throw new NotImplementedException();
        }

        public override Task<Category> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Task RefreshListFromService()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateItemInService(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
