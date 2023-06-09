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
    public class CustomerDataStore : AListDataStore<CustomerForView>
    {
        public override async Task<CustomerForView> AddItemToService(CustomerForView item)
        {
            return await _service.CustomerPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(CustomerForView item)
        {
            return await _service.CustomerDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<CustomerForView> Find(CustomerForView item)
        {
            return await _service.CustomerGETAsync(item.Id);
        }

        public override async Task<CustomerForView> Find(int id)
        {
            return await _service.CustomerGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = (await _service.CustomerAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(CustomerForView item)
        {
            return await _service.CustomerPUTAsync(item.Id, item).HandleRequest();
        }

        public async Task<List<ReviewForView>> FindBookReview(CustomerForView item)
        {
            return (await _service.GetCustomerReviewAsync(item.Id)).ToList();
        }
    }
}
