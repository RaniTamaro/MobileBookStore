using BookStore.Helpers.Constants;
using BookStore.Services;
using BookStore.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookStore.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Fields
        private string nickname;
        private string password;
        #endregion

        #region Properties
        public string Nickname
        {
            get => nickname;
            set => SetProperty(ref nickname, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        #endregion

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }
        // TODO zmienić AboutPage na Home, gdy bedzie gotowa
        private async void OnLoginClicked(object obj)
        {
            var userDataService = new UserDataStore();
            var loginRole = await userDataService.CheckLogin(Nickname, Password);

            if (!string.IsNullOrEmpty(loginRole))
            {
                Application.Current.MainPage = new AppShell();

                Application.Current.Resources.Add(RoleConstants.UserRole, loginRole);
                MessagingCenter.Send<LoginViewModel>(this,
                    (loginRole == RoleConstants.Admin) ? RoleConstants.Admin : RoleConstants.User
                    );

                await Shell.Current.DisplayAlert("Login success", "Hi! You are login!", "Ok");
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Login failed", "Username or Password is incorrect or not exists", "Ok");
            }
        }
    }
}
