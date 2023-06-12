using BookStore.Models;
using BookStore.Services;
using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace BookStore.ViewModels.Author
{
    //TODO: Klaudia - tu możliwe, że będzie zmiania book, bo w api przyjmuje coś innego!
    public class NewAuthorViewModel : ANewViewModel<AuthorForView>
    {
        public NewAuthorViewModel()
            : base()
        {
            bookDataStore = new BookDataStore();
            bookDataStore.RefreshListFromService();
            books = bookDataStore.items;
        }

        #region Fields
        private readonly BookDataStore bookDataStore;
        private string name = "";
        private string surname = "";
        private string nickname = "";
        private List<BookForView> selectedBooks = new List<BookForView>();
        private List<BookForView> books;
        #endregion

        #region Properties
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }

        public string Nickname
        {
            get => nickname;
            set => SetProperty(ref nickname, value);
        }

        public List<BookForView> SelectedBooks
        {
            get => selectedBooks;
            set => SetProperty(ref selectedBooks, value);
        }

        public List<BookForView> Books
        {
            get => books;
            set => SetProperty(ref books, value);
        }
        #endregion

        public override AuthorForView SetItem()
        {
            List<SelectListItem> booksToSet = new List<SelectListItem>();

            foreach (var book in selectedBooks)
            {
                if (bookDataStore.items.Contains(book))
                {
                    var findBook = bookDataStore.items.FirstOrDefault(x => x.Id == book.Id);
                    booksToSet.Add(new SelectListItem
                    {
                        Value = findBook.Id.ToString(),
                        Text = findBook.Title
                    });
                }
            }

            return new AuthorForView
            {
                CretionDate = DateTime.Now,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Name = Name,
                Surname = Surname,
                Nickname = Nickname,
                Books = booksToSet
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(Surname)
                || !string.IsNullOrEmpty(nickname);
        }
    }
}
