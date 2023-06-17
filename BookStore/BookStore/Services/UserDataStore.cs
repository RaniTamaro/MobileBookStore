using BookStore.Helpers;
using BookStore.Services.Abstract;
using BookStoreApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class UserDataStore : AListDataStore<UserForView>
    {
        public async Task<string> CheckLogin(string username, string password)
        {
            var login = await _service.LoginAsync(username, password);

            return string.IsNullOrEmpty(login.Role) ? "" : login.Role;
        }

        public override async Task<UserForView> AddItemToService(UserForView item)
        {
            return await _service.UserPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(UserForView item)
        {
            return await _service.UserDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<UserForView> Find(UserForView item)
        {
            return await _service.UserGETAsync(item.Id);
        }

        public override async Task<UserForView> Find(int id)
        {
            return await _service.UserGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = (await _service.UserAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(UserForView item)
        {
            return await _service.UserPUTAsync(item.Id, item).HandleRequest();
        }

        public async Task<List<ReviewForView>> FindBookReview(UserForView item)
        {
            return (await _service.GetCustomerReviewAsync(item.Id)).ToList();
        }
    }
}
