using BookStore.ViewModels.User;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUserPage : ContentPage
    {
        public BookStoreApi.AuthorForView Item { get; set; }
        public EditUserPage()
        {
            InitializeComponent();
            BindingContext = new EditUserViewModel();
        }
    }
}