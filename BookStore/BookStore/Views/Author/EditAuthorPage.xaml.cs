using BookStore.ViewModels.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Author
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAuthorPage : ContentPage
    {
        public BookStoreApi.AuthorForView Item { get; set; }
        public EditAuthorPage()
        {
            InitializeComponent();
            BindingContext = new EditAuthorViewModel();
        }
    }
}