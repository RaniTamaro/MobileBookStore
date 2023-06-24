using BookStore.Helpers;
using BookStore.Services.Abstract;
using BookStoreApi;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class ReviewDataStore : AListDataStore<ReviewForView>
    {
        public override async Task<ReviewForView> AddItemToService(ReviewForView item)
        {
            return await _service.ReviewPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(ReviewForView item)
        {
            return await _service.ReviewDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<ReviewForView> Find(ReviewForView item)
        {
            return await _service.ReviewGETAsync(item.Id);
        }

        public override async Task<ReviewForView> Find(int id)
        {
            return await _service.ReviewGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.ReviewAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(ReviewForView item)
        {
            return await _service.ReviewPUTAsync(item.Id, item).HandleRequest();
        }

        public async Task GetReviewForBook(int bookId)
        {
            items = _service.GetBookReviewAsync(bookId).Result.ToList();
        }

        public async Task GetReviewForUser (int userId)
        {
            items = _service.GetCustomerReviewAsync(userId).Result.ToList();
        }
    }
}
