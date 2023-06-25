using BookStore.ViewModels.Category;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Category
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCategoryPage : ContentPage
    {
        public BookStoreApi.CategoryForView Item { get; set; }

        public NewCategoryPage()
        {
            InitializeComponent();
            BindingContext = new NewCategoryViewModel();
        }
    }
}