using BookStore.ViewModels.Review;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Review
{
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