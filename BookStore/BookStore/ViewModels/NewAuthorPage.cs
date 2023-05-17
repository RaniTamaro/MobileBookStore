using BookStore.Services;
using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace BookStore.ViewModels
{
    public class NewAuthorPage : ANewViewModel<Author>
    {
        public NewAuthorPage()
            : base()
        {
        }

        #region Fields
        private string name = "";
        private string surname = "";
        private string nickname = "";
        private List<Book> books = new List<Book>();
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

        public List<Book> Books
        {
            get => books;
            set => SetProperty(ref books, value);
        }
        #endregion

        public override Author SetItem()
        {
            var bookDataStore = DependencyService.Get<BookDataStore>();
            List<Book> booksToSet = new List<Book>();

            foreach (var book in books)
            {
                if (bookDataStore.items.Contains(book))
                {
                    booksToSet.Add(bookDataStore.items.FirstOrDefault(x => x.Id == book.Id));
                }
            }

            return new Author
            {
                Name = this.Name,
                Surname = this.Surname,
                Nickname = this.Nickname,
                Books = booksToSet,
                IsActive = true,
                CretionDate = DateTime.Now,
                MmodifDate = DateTime.Now
            };
        }

        public override bool ValidateSave()
        {
            return (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(Surname))
                || !string.IsNullOrEmpty(nickname);
        }
    }
}
