using BookStore.ViewModels.Abstract;
using BookStore.Views.User;
using BookStoreApi;
using Xamarin.Forms;

namespace BookStore.ViewModels.User
{
    public class UserViewModel : AListViewModel<UserForView>
    {
        public UserViewModel()
            : base("Użytkownicy")
        {
        }

        public async override void OnItemSelected(UserForView item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(DetailsUserPage)}?{nameof(DetailsUserViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewUserPage));
        }
    }
}
