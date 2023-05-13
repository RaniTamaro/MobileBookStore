using BookStore.Services.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    //TODO: Wypełnić!
    public class CustomerDataStore : AListDataStore<Customer>
    {
        public override Task<Customer> AddItemToService(Customer item)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemFromService(Customer item)
        {
            throw new NotImplementedException();
        }

        public override Task<Customer> Find(Customer item)
        {
            throw new NotImplementedException();
        }

        public override Task<Customer> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Task RefreshListFromService()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateItemInService(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
