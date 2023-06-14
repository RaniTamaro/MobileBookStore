using BookStore.Helpers;
using BookStore.Services.Abstract;
using BookStoreApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookDataStore : AListDataStore<BookForView>
    {
        public override async Task<BookForView> AddItemToService(BookForView item)
        {
            return await _service.BookPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(BookForView item)
        {
            return await _service.BookDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<BookForView> Find(BookForView item)
        {
            return await _service.BookGETAsync(item.Id);
        }

        public override async Task<BookForView> Find(int id)
        {
            return await _service.BookGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = (await _service.BookAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(BookForView item)
        {
            return await _service.BookPUTAsync(item.Id, item).HandleRequest();
        }

        public async Task<List<ReviewForView>> FindBookReview(BookForView item)
        {
            return (await _service.GetBookReviewAsync(item.Id)).ToList();
        }
    }
}
