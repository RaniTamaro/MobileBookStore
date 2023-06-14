using BookStore.Services;
using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.ViewModels.Review
{
    public class NewReviewViewModel : ANewViewModel<ReviewForView>
    {
        public NewReviewViewModel()
            : base()
        {
            var bookDataStore = new BookDataStore();
            var userDataStore = new UserDataStore();
            bookDataStore.RefreshListFromService();
            userDataStore.RefreshListFromService();
            books = bookDataStore.items;
            users = userDataStore.items;
            selectedBook = bookDataStore.items.FirstOrDefault() ?? new BookForView();
            selectedUser = userDataStore.items.FirstOrDefault() ?? new UserForView();
        }

        #region Fields
        private double rating;
        private string title;
        private string text;
        private UserForView selectedUser;
        private List<UserForView> users;
        private BookForView selectedBook;
        private List<BookForView> books;
        #endregion

        #region Properties
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

        public UserForView SelectedCustomer
        {
            get => selectedUser;
            set => SetProperty(ref selectedUser, value);
        }

        public List<UserForView> Users
        {
            get => users;
            set => SetProperty(ref users, value);
        }

        public BookForView SelectedBook
        {
            get => selectedBook;
            set => SetProperty(ref selectedBook, value);
        }

        public List<BookForView> Books
        {
            get => books;
            set => SetProperty(ref books, value);
        }
        #endregion

        public override ReviewForView SetItem()
        {
            return new ReviewForView
            {
                CretionDate = DateTime.Now,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Rating = this.Rating,
                Title = this.Title,
                Text = this.Text,
                IdUser = selectedUser.Id,
                UserFullName = $"{selectedUser.Name} {selectedUser.Surname}",
                IdBook = selectedBook.Id,
                BookTitle = selectedBook.Title
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(title)
                && rating > 0
                && selectedBook.Id > 0
                && selectedUser.Id > 0;
        }
    }
}
