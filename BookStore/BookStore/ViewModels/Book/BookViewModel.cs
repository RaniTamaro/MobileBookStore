using BookStore.ViewModels.Abstract;
using BookStoreApi;
using Xamarin.Forms;

namespace BookStore.ViewModels.Book
{
    public class BookViewModel : AListViewModel<BookForView>
    {
        public BookViewModel()
            : base("Książki")
        {
        }

        public async override void OnItemSelected(BookForView item)
        {
            if (item == null)
                return;
            await Shell.Current.DisplayAlert("Wybrana książka", $"{item.Title}", "Anuluj");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewBookPage));
        }
    }
}
