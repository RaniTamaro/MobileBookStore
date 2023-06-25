using BookStore.ViewModels.User;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        private UserViewModel _viewModel;

        public UserPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new UserViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}