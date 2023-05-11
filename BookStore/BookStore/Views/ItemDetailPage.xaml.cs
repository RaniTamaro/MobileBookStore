using BookStore.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BookStore.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}