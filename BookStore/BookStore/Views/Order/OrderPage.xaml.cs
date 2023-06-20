using BookStore.ViewModels.Order;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Order
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        private OrderViewModel _viewModel;

        public OrderPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new OrderViewModel(); 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}