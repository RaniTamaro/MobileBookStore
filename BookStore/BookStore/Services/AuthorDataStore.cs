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
    public class AuthorDataStore : AListDataStore<AuthorForView>
    {
        public AuthorDataStore()
            : base()
        {
        }

        public override async Task<AuthorForView> AddItemToService(AuthorForView item)
        {
            return await _service.AuthorPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(AuthorForView item)
        {
            return await _service.AuthorDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<AuthorForView> Find(AuthorForView item)
        {
            return await _service.AuthorGETAsync(item.Id);
        }

        public override async Task<AuthorForView> Find(int id)
        {
            return await _service.AuthorGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = (await _service.AuthorAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(AuthorForView item)
        {
            return await _service.AuthorPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
