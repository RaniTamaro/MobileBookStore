using BookStore.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.User
{
    //TODO: Wstawić View + podpiąć ViewModel
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