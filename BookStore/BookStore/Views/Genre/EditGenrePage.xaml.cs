using BookStore.ViewModels.Genre;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Genre
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditGenrePage : ContentPage
    {
        public BookStoreApi.Genre Item { get; set; }
        public EditGenrePage()
        {
            InitializeComponent();
            BindingContext = new EditGenreViewModel();
        }
    }
}