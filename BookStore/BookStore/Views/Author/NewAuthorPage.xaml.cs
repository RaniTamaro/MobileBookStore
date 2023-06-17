using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BookStore.ViewModels.Author;

namespace BookStore.Views.Author
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAuthorPage : ContentPage
    {
        public BookStoreApi.AuthorForView Item { get; set; }
        public NewAuthorPage()
        {
            InitializeComponent();
            BindingContext = new NewAuthorViewModel();
        }
    }
}