using BookStore.ViewModels.Genre;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Genre
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsGenrePage : ContentPage
    {
        public DetailsGenrePage()
        {
            InitializeComponent();
            BindingContext = new DetailsGenreViewModel();
        }
    }
}