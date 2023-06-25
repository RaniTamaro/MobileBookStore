using BookStore.ViewModels.Book;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Book
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {
        private BookViewModel _viewModel;

        public BookPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new BookViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}