using BookStore.ViewModels.User;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.User
{
    //TODO: Zrobić front
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