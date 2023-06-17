using BookStore.ViewModels.Abstract;
using BookStore.ViewModels.Author;
using BookStore.ViewModels.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Genre
{
    //TODO: Zrobić front + podpiąć model
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenrePage : ContentPage
    {
        private GenreViewModel _viewModel;

        public GenrePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new GenreViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}