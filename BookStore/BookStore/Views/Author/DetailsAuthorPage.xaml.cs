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
    //TODO : wyświetlanie książek przypisanych do autora
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsAuthorPage : ContentPage
    {
        public DetailsAuthorPage()
        {
            InitializeComponent();
            BindingContext = new DetailsAuthorViewModel();
        }
    }
}