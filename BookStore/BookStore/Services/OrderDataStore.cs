using BookStore.Services.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    //TODO: Wypełnić!
    public class OrderDataStore : AListDataStore<OrderForView>
    {
        public override Task<OrderForView> AddItemToService(OrderForView item)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemFromService(OrderForView item)
        {
            throw new NotImplementedException();
        }

        public override Task<OrderForView> Find(OrderForView item)
        {
            throw new NotImplementedException();
        }

        public override Task<OrderForView> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Task RefreshListFromService()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateItemInService(OrderForView item)
        {
            throw new NotImplementedException();
        }
    }
}
