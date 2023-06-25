using BookStore.ViewModels.Review;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Review
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookReviewPage : ContentPage
    {
        private BookReviewViewModel _viewModel;
        public BookReviewPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new BookReviewViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}