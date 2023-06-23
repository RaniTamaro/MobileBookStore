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
            Routing.RegisterRoute(nameof(NewCategoryPage), typeof(NewCategoryPage));
            Routing.RegisterRoute(nameof(DetailsCategoryPage), typeof(DetailsCategoryPage));
            Routing.RegisterRoute(nameof(NewGenrePage), typeof(NewGenrePage));
            Routing.RegisterRoute(nameof(DetailsGenrePage), typeof(DetailsGenrePage));
            Routing.RegisterRoute(nameof(NewOrderPage), typeof(NewOrderPage));
            Routing.RegisterRoute(nameof(DetailsOrderPage), typeof(DetailsOrderPage));
            Routing.RegisterRoute(nameof(NewReviewPage), typeof(NewReviewPage));
            Routing.RegisterRoute(nameof(DetailsReviewPage), typeof(DetailsReviewPage));
            Routing.RegisterRoute(nameof(NewUserPage), typeof(NewUserPage));
            Routing.RegisterRoute(nameof(DetailsUserPage), typeof(DetailsUserPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
