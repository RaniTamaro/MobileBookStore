using BookStore.Helpers;
using BookStore.Services.Abstract;
using BookStoreApi;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class GenreDataStore : AListDataStore<Genre>
    {
        public override async Task<Genre> AddItemToService(Genre item)
        {
            return await _service.GenrePOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Genre item)
        {
            return await _service.GenreDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Genre> Find(Genre item)
        {
            return await _service.GenreGETAsync(item.Id);
        }

        public override async Task<Genre> Find(int id)
        {
            return await _service.GenreGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = (await _service.GenreAllAsync()).ToList();
        }

        public override async Task<bool> UpdateItemInService(Genre item)
        {
            return await _service.GenrePUTAsync(item.Id, item).HandleRequest();
        }
    }
}
