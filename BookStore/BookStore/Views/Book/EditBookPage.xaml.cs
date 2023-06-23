using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Book
{
    //TODO: Wstawić View + podpiąć ViewModel
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditBookPage : ContentPage
    {
        public EditBookPage()
        {
            InitializeComponent();
        }
    }
}