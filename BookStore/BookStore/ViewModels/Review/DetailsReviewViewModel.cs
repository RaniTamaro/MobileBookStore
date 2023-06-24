using BookStore.ViewModels.Abstract;
using BookStore.Views.Review;
using BookStoreApi;
using Xamarin.Forms;

namespace BookStore.ViewModels.Review
{
    public class DetailsReviewViewModel : AItemDetailsViewModel<ReviewForView>
    {
        #region Fields
        private int id;
        private double rating;
        private string title;
        private string text;
        private string userFullName;
        private string bookTitle;
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public double Rating
        {
            get => rating;
            set => SetProperty(ref rating, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string UserFullName
        {
            get => userFullName;
            set => SetProperty(ref userFullName, value);
        }

        public string BookTitle
        {
            get => bookTitle;
            set => SetProperty(ref bookTitle, value);
        }
        #endregion

        public DetailsReviewViewModel()
            : base()
        {
        }

        public override void LoadProperties(ReviewForView item)
        {
            Id = item.Id;
            Rating = item.Rating;
            Title = item.Title;
            Text = item.Text;
            UserFullName = item.UserFullName;
            BookTitle = item.BookTitle;
        }

        public async override void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(EditReviewPage)}?{nameof(EditReviewViewModel.ItemId)}={Id}");
        }
    }
}
