using BookStore.Helpers.Constants;
using BookStore.ViewModels;
using BookStore.ViewModels.Author;
using BookStore.Views;
using BookStore.Views.Author;
using BookStore.Views.Book;
using BookStore.Views.Category;
using BookStore.Views.Genre;
using BookStore.Views.Order;
using BookStore.Views.Review;
using BookStore.Views.User;
using System;
using Xamarin.Forms;

namespace BookStore
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewAuthorPage), typeof(NewAuthorPage));
            Routing.RegisterRoute(nameof(DetailsAuthorPage), typeof(DetailsAuthorPage));
            Routing.RegisterRoute(nameof(EditAuthorPage), typeof(EditAuthorPage));
            Routing.RegisterRoute(nameof(NewBookPage), typeof(NewBookPage));
            Routing.RegisterRoute(nameof(DetailsBookPage), typeof(DetailsBookPage));
            Routing.RegisterRoute(nameof(EditBookPage), typeof(EditBookPage));
            Routing.RegisterRoute(nameof(NewCategoryPage), typeof(NewCategoryPage));
            Routing.RegisterRoute(nameof(DetailsCategoryPage), typeof(DetailsCategoryPage));
            Routing.RegisterRoute(nameof(EditCategoryPage), typeof(EditCategoryPage));
            Routing.RegisterRoute(nameof(NewGenrePage), typeof(NewGenrePage));
            Routing.RegisterRoute(nameof(DetailsGenrePage), typeof(DetailsGenrePage));
            Routing.RegisterRoute(nameof(EditGenrePage), typeof(EditGenrePage));
            Routing.RegisterRoute(nameof(NewOrderPage), typeof(NewOrderPage));
            Routing.RegisterRoute(nameof(DetailsOrderPage), typeof(DetailsOrderPage));
            Routing.RegisterRoute(nameof(EditOrderPage), typeof(EditOrderPage));
            Routing.RegisterRoute(nameof(NewReviewPage), typeof(NewReviewPage));
            Routing.RegisterRoute(nameof(DetailsReviewPage), typeof(DetailsReviewPage));
            Routing.RegisterRoute(nameof(EditReviewPage), typeof(EditReviewPage));
            Routing.RegisterRoute(nameof(BookReviewPage), typeof(BookReviewPage));
            Routing.RegisterRoute(nameof(UserReviewPage), typeof(UserReviewPage));
            Routing.RegisterRoute(nameof(NewUserPage), typeof(NewUserPage));
            Routing.RegisterRoute(nameof(DetailsUserPage), typeof(DetailsUserPage));
            Routing.RegisterRoute(nameof(EditUserPage), typeof(EditUserPage));

            BindingContext = new AppShellViewModel();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Application.Current.Resources.Remove(RoleConstants.UserRole);
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
