using BookStore.ViewModels.Category;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Category
{
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