using BookStore.ViewModels.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Review
{
    //TODO: Wstawić View + podpiąć ViewModel
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditReviewPage : ContentPage
    {
        public BookStoreApi.ReviewForView Item { get; set; }
        public EditReviewPage()
        {
            InitializeComponent();
            BindingContext = new EditReviewViewModel();
        }
    }
}