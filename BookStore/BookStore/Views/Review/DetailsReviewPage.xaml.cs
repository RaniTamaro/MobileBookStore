using BookStore.ViewModels.Review;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views.Review
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsReviewPage : ContentPage
    {
        public DetailsReviewPage()
        {
            InitializeComponent();
            BindingContext = new DetailsReviewViewModel();
        }
    }
}