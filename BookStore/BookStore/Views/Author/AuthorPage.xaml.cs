using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.ViewModels;
using BookStore.ViewModels.Author;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Author
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorPage : ContentPage
    {
        private AuthorViewModel _viewModel;

        public AuthorPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AuthorViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}