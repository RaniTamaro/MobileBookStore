using BookStore.ViewModels.Author;
using BookStore.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Category
{
    //TODO: Wstawić View + podpiąć ViewModel
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