using BookStore.ViewModels.Order;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Order
{
    //TODO: Front - Id nie może być wyświetlane! Przekazuje je dla dodawania książek!
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsOrderPage : ContentPage
    {
        public DetailsOrderPage()
        {
            InitializeComponent();
            BindingContext = new DetailsOrderViewModel();
        }
    }
}