using BookStore.ViewModels.User;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUserPage : ContentPage
    {
        public BookStoreApi.UserForView Item { get; set; }
        public NewUserPage()
        {
            InitializeComponent();
            BindingContext = new NewUserViewModel();
        }
    }
}