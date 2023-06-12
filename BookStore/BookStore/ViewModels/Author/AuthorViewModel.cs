using BookStore.ViewModels.Abstract;
using BookStore.Views.Author;
using BookStoreApi;
using Xamarin.Forms;

namespace BookStore.ViewModels.Author
{
    public class AuthorViewModel : AListViewModel<AuthorForView>
    {
        public AuthorViewModel()
            : base("Autorzy")
        {
        }

        public async override void OnItemSelected(AuthorForView item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(DetailsAuthorPage)}?{nameof(DetailsAuthorViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewAuthorPage));
        }
    }
}
