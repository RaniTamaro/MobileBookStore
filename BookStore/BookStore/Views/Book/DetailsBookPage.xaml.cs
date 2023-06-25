using BookStore.ViewModels.Book;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Book
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsBookPage : ContentPage
    {
        public DetailsBookPage()
        {
            InitializeComponent();
            BindingContext = new DetailsBookViewModel();
        }
    }
}