using BookStore.ViewModels.Category;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Category
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCategoryPage : ContentPage
    {
        public BookStoreApi.CategoryForView Item { get; set; }
        public EditCategoryPage()
        {
            InitializeComponent();
            BindingContext = new EditCategoryViewModel();
        }
    }
}