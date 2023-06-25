using BookStore.ViewModels.Order;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Order
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditOrderPage : ContentPage
    {
        public BookStoreApi.OrderForView Item { get; set; }
        public EditOrderPage()
        {
            InitializeComponent();
            BindingContext = new EditOrderViewModel();
        }
    }
}