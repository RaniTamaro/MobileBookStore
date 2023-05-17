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
    public class NewBookPage : ANewViewModel<Book>
    {
        public NewBookPage()
            : base()
        {
        }

        #region Fields
        private string title;
        private string description = "";
        private string publishingHouse = "";
        private double price = 0;
        private int category;
        private int author;
        private List<BookGenre> bookGenres = new List<BookGenre>();
        #endregion

        #region Properties
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string PublishingHouse
        {
            get => publishingHouse;
            set => SetProperty(ref publishingHouse, value);
        }

        public double Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public int Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }

        public int Author
        {
            get => author;
            set => SetProperty(ref author, value);
        }

        public List<BookGenre> BookGenres
        {
            get => bookGenres;
            set => SetProperty(ref bookGenres, value);
        }
        #endregion

        public override Book SetItem()
        {
            var categoryDataStore = DependencyService.Get<CategoryDataStore>();
            var authorDataStore = DependencyService.Get<AuthorDataStore>();
            var genreDataStore = DependencyService.Get<GenreDataStore>();

            Category categoryToSet = categoryDataStore.items.Where(x => x.Id == category).FirstOrDefault();
            Author authorToSet = authorDataStore.items.Where(x => x.Id == author).FirstOrDefault();
            List<BookGenre> bookGenresToSet = new List<BookGenre>();

            var book = new Book
            {
                Title = this.Title,
                Description = this.Description,
                Price = this.Price,
                Category = categoryToSet,
                Author = authorToSet,
                IsActive = true,
                CretionDate = DateTime.Now,
                MmodifDate = DateTime.Now
            };

            foreach (var bookGenre in bookGenres)
            {
                if (genreDataStore.items.Contains(bookGenre.Genre))
                {
                    bookGenresToSet.Add(new BookGenre
                    {
                        Genre = bookGenre.Genre,
                        Book = book
                    });
                }
            }

            book.BookGenres = bookGenresToSet;
            return book;
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(title)
                && price > 0;
        }
    }
}
