using BookStore.ViewModels.Book;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Book
{
    //TODO: Zrobić front
    //TODO: Front - Id nie może być wyświetlane! Przekazuje je dla dodawania książek!
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsBookPage : ContentPage
    {
        public DetailsBookPage()
        {
            InitializeComponent();
            BindingContext = new DetailsBookViewModel();
        }
    }
}