using BookStore.Helpers.Constants;
using Xamarin.Forms;

namespace BookStore.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        private bool isAdmin;
        private bool isUser;

        public bool IsAdmin
        {
            get => isAdmin;
            set => SetProperty(ref isAdmin, value);
        }

        public bool IsUser
        {
            get => isUser;
            set => SetProperty(ref isUser, value);
        }

        public AppShellViewModel()
        {
            MessagingCenter.Subscribe<LoginViewModel>(this, message: RoleConstants.Admin, (sender) =>
            {
                IsUser = true;
                IsAdmin = true;
            });

            MessagingCenter.Subscribe<LoginViewModel>(this, message: RoleConstants.User, (sender) =>
            {
                IsUser = true;
                IsAdmin = false;
            });
        }
    }
}
