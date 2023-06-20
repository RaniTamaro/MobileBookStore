using BookStore.ViewModels.User;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsUserPage : ContentPage
    {
        public DetailsUserPage()
        {
            InitializeComponent();
            BindingContext = new DetailsUserViewModel();
        }
    }
}