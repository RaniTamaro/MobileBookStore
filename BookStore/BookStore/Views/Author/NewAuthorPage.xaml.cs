using BookStore.ViewModels.Author;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Author
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAuthorPage : ContentPage
    {
        public BookStoreApi.AuthorForView Item { get; set; }

        public NewAuthorPage()
        {
            InitializeComponent();
            BindingContext = new NewAuthorViewModel();
        }
    }
}