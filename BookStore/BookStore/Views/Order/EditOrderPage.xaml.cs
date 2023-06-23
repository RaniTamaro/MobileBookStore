using BookStore.ViewModels.Author;
using BookStore.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Order
{
    //TODO: Wstawić View + podpiąć ViewModel
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