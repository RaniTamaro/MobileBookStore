using BookStore.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BookStore.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            ToLoginCommand = new Command(async () => await OpenLoginPageAsync());
        }

        public ICommand ToLoginCommand { get; }

        private async Task OpenLoginPageAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
