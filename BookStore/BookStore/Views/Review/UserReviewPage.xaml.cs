using BookStore.ViewModels.Review;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Review
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserReviewPage : ContentPage
    {
        private UserReviewViewModel _viewModel;
        public UserReviewPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new UserReviewViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}