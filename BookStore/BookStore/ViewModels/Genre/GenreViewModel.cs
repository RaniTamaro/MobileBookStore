using BookStore.ViewModels.Abstract;
using BookStore.Views.Genre;
using BookStoreApi;
using Xamarin.Forms;

namespace BookStore.ViewModels.Genre
{
    public class GenreViewModel : AListViewModel<BookStoreApi.Genre>
    {
        public GenreViewModel()
            : base("Gatunki")
        {
        }

        public async override void OnItemSelected(BookStoreApi.Genre item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(DetailsGenrePage)}?{nameof(DetailsGenreViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewGenrePage));
        }
    }
}
