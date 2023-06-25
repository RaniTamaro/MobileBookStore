using BookStore.ViewModels.Author;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Author
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsAuthorPage : ContentPage
    {
        public DetailsAuthorPage()
        {
            InitializeComponent();
            BindingContext = new DetailsAuthorViewModel();
        }
    }
}