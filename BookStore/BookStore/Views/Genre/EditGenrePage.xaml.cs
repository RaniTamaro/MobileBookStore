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
    //TODO: Wstawić View + podpiąć ViewModel
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditGenrePage : ContentPage
    {
        public BookStoreApi.Genre Item { get; set; }
        public EditGenrePage()
        {
            InitializeComponent();
            BindingContext = new EditGenreViewModel();
        }
    }
}