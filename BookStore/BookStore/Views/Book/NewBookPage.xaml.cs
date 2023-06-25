using BookStore.ViewModels.Book;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Book
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBookPage : ContentPage
    {
        public BookStoreApi.BookForView Item { get; set; }

        public NewBookPage()
        {
            InitializeComponent();
            BindingContext = new NewBookViewModel();
        }
    }
}