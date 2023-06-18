using BookStore.ViewModels.Category;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Category
{
    //TODO: Zrobić front
    //TODO: Front - Id nie może być wyświetlane! Przekazuje je dla dodawania książek!
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsCategoryPage : ContentPage
    {
        public DetailsCategoryPage()
        {
            InitializeComponent();
            BindingContext = new DetailsCategoryViewModel();
        }
    }
}