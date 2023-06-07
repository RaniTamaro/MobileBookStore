using BookStore.Services.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    //TODO: Wypełnić!
    public class CategoryDataStore : AListDataStore<CategoryForView>
    {
        public override Task<CategoryForView> AddItemToService(CategoryForView item)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemFromService(CategoryForView item)
        {
            throw new NotImplementedException();
        }

        public override Task<CategoryForView> Find(CategoryForView item)
        {
            throw new NotImplementedException();
        }

        public override Task<CategoryForView> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Task RefreshListFromService()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateItemInService(CategoryForView item)
        {
            throw new NotImplementedException();
        }
    }
}
