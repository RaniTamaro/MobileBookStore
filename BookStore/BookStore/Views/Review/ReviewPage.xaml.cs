using BookStore.ViewModels.Review;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Review
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewPage : ContentPage
    {
        private ReviewViewModel _viewModel;

        public ReviewPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ReviewViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}