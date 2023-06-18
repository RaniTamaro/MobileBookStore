using BookStore.ViewModels.Genre;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Genre
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenrePage : ContentPage
    {
        private GenreViewModel _viewModel;

        public GenrePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new GenreViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}