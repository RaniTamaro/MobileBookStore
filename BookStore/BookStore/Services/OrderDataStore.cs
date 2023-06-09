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
    public class OrderDataStore : AListDataStore<OrderForView>
    {
        public override async Task<OrderForView> AddItemToService(OrderForView item)
        {
            return await _service.OrderPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(OrderForView item)
        {
            return await _service.OrderDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<OrderForView> Find(OrderForView item)
        {
            return await _service.OrderGETAsync(item.Id);
        }

        public override async Task<OrderForView> Find(int id)
        {
            return await _service.OrderGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = (await _service.OrderAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(OrderForView item)
        {
            return await _service.OrderPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
