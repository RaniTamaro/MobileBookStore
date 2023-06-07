using BookStore.Services.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    //TODO: Wypełnić!
    public class CustomerDataStore : AListDataStore<CustomerForView>
    {
        public override Task<CustomerForView> AddItemToService(CustomerForView item)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemFromService(CustomerForView item)
        {
            throw new NotImplementedException();
        }

        public override Task<CustomerForView> Find(CustomerForView item)
        {
            throw new NotImplementedException();
        }

        public override Task<CustomerForView> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Task RefreshListFromService()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateItemInService(CustomerForView item)
        {
            throw new NotImplementedException();
        }
    }
}
