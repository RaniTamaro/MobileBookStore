using BookStore.Services;
using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;

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

            selectedBook = bookDataStore.items.FirstOrDefault() ?? new BookForView();
        }

        #region Fields
        private readonly BookDataStore bookDataStore;
        private string name = "";
        private string surname = "";
        private string nickname = "";
        private BookForView selectedBook;
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

        public BookForView SelectedBook
        {
            get => selectedBook;
            set => SetProperty(ref selectedBook, value);
        }

        public List<BookForView> Books
        {
            get => books;
        }
        #endregion

        public override AuthorForView SetItem()
        {
            return new AuthorForView
            {
                CretionDate = DateTime.Now,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Name = Name,
                Surname = Surname,
                Nickname = Nickname,
                Books = new List<BookForView>() { SelectedBook }
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(Surname)
                || !string.IsNullOrEmpty(nickname);
        }
    }
}
