using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BookStore.ViewModels.Genre;

namespace BookStore.Views.Genre
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGenrePage : ContentPage
    {
        public BookStoreApi.Genre Item { get; set; }

        public NewGenrePage()
        {
            InitializeComponent();
            BindingContext = new NewGenreViewModel();
        }
    }
}