using BookStore.ViewModels.Book;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Book
{
    //TODO: Zrobić front + podpiąć model
    //TODO: Po stronie frontu, jeśli w modelu zostanie przekazany ItemId, to select z autorami ma zostać wybrany poprawny autor i nie ma być możliwości jego zmiany
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