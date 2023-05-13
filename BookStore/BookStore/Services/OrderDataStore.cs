using BookStore.Services.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    //TODO: Wypełnić!
    public class OrderDataStore : AListDataStore<Order>
    {
        public override Task<Order> AddItemToService(Order item)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemFromService(Order item)
        {
            throw new NotImplementedException();
        }

        public override Task<Order> Find(Order item)
        {
            throw new NotImplementedException();
        }

        public override Task<Order> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Task RefreshListFromService()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateItemInService(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
