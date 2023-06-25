using BookStore.Services;
using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.ViewModels.Review
{
    public class EditReviewViewModel : AEditItemViewModel<ReviewForView>
    {
        public EditReviewViewModel()
            : base()
        {
            bookDataStore = new BookDataStore();
            userDataStore = new UserDataStore();
            bookDataStore.RefreshListFromService();
            userDataStore.RefreshListFromService();
            books = bookDataStore.items;
            users = userDataStore.items;
        }

        #region Fields
        private BookDataStore bookDataStore;
        private UserDataStore userDataStore;
        private int id;
        private double rating;
        private string title;
        private string text;
        private UserForView selectedUser;
        private List<UserForView> users;
        private BookForView selectedBook;
        private List<BookForView> books;
        private DateTime creationDate;
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
            get
            {
                return books;
            }
        }

        public DateTime CreationDate
        {
            get => creationDate;
            set => SetProperty(ref creationDate, value);
        }
        #endregion

        public override void LoadProperties(ReviewForView item)
        {
            Id = item.Id;
            Rating = item.Rating;
            Title = item.Title;
            Text = item.Text;
            SelectedCustomer = userDataStore.items.Where(x => x.Id == item.IdUser).First();
            SelectedBook = bookDataStore.items.Where(x => x.Id == item.IdBook).First();
            CreationDate = DateTime.Parse(item.CretionDate.ToString());
        }

        public override ReviewForView SetItem()
        {
            return new ReviewForView
            {
                CretionDate = CreationDate == new DateTime() ? DateTime.Now : CreationDate,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Id = Id,
                Rating = Rating,
                Title = Title,
                Text = Text,
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
                && selectedBook?.Id > 0
                && selectedUser?.Id > 0;
        }
    }
}
