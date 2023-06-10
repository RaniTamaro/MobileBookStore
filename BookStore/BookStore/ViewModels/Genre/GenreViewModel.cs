using BookStore.ViewModels.Abstract;
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
            await Shell.Current.DisplayAlert("Wybrany gatunek", item.Name, "Anuluj");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewGenrePage));
        }
    }
}
