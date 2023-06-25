using BookStore.ViewModels.Book;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Book
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditBookPage : ContentPage
    {
        public BookStoreApi.BookForView Item { get; set; }
        public EditBookPage()
        {
            InitializeComponent();
            BindingContext = new EditBookViewModel();
        }
    }
}