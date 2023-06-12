using BookStore.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BookStore.Views
{
    //TODO: Do usunięcia!
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}