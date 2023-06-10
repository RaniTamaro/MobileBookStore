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
    public class CategoryDataStore : AListDataStore<CategoryForView>
    {
        public override async Task<CategoryForView> AddItemToService(CategoryForView item)
        {
            return await _service.CategoryPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(CategoryForView item)
        {
            return await _service.CategoryDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<CategoryForView> Find(CategoryForView item)
        {
            return await _service.CategoryGETAsync(item.Id);
        }

        public override async Task<CategoryForView> Find(int id)
        {
            return await _service.CategoryGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = (await _service.CategoryAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(CategoryForView item)
        {
            return await _service.CategoryPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
