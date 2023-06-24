using BookStore.Services;
using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace BookStore.ViewModels.Book
{
    public class EditBookViewModel : AEditItemViewModel<BookForView>
    {
        public EditBookViewModel()
            : base()
        {
            genreDataStore = new GenreDataStore();
            categoryDataStore = new CategoryDataStore();
            authorDataStore = new AuthorDataStore();

            genreDataStore.RefreshListFromService();
            categoryDataStore.RefreshListFromService();
            authorDataStore.RefreshListFromService();
            genres = genreDataStore.items;
            categories = categoryDataStore.items;
            authors = authorDataStore.items;
        }

        #region Fields
        private int id;
        private readonly GenreDataStore genreDataStore;
        private readonly CategoryDataStore categoryDataStore;
        private readonly AuthorDataStore authorDataStore;
        private string title;
        private string description = "";
        private string publishingHouse = "";
        private double price = 0;
        private CategoryForView selectedCategory;
        private AuthorForView selectedAuthor;
        private BookStoreApi.Genre selectedGenre;
        private List<BookStoreApi.Genre> genres;
        private List<CategoryForView> categories;
        private List<AuthorForView> authors;
        private DateTime creationDate;
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

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

        public CategoryForView SelectedCategory
        {
            get => selectedCategory;
            set => SetProperty(ref selectedCategory, value);
        }

        public AuthorForView SelectedAuthor
        {
            get => selectedAuthor;
            set => SetProperty(ref selectedAuthor, value);
        }

        public BookStoreApi.Genre SelectedGenre
        {
            get => selectedGenre;
            set => SetProperty(ref selectedGenre, value);
        }

        public List<BookStoreApi.Genre> Genres
        {
            get => genres;
        }

        public List<CategoryForView> Categories
        {
            get => categories;
        }

        public List<AuthorForView> Authors
        {
            get => authors;
        }

        public DateTime CreationDate
        {
            get => creationDate;
            set => SetProperty(ref creationDate, value);
        }

        public ICommand ItemSelectedCommand { get; }
        #endregion

        public override void LoadProperties(BookForView item)
        {
            Id = item.Id;
            Title = item.Title;
            Description = item.Description;
            PublishingHouse = item.PublishingHouse;
            Price = item.Price;
            SelectedCategory = categoryDataStore.items.Where(x => x.Id ==  item.IdCategory).FirstOrDefault();
            SelectedAuthor = authorDataStore.items.Where(x => x.Id == item.IdAuthor).FirstOrDefault();
            genres = item.BookGenres.ToList();
            CreationDate = DateTime.Parse(item.CretionDate.ToString());
        }

        public override BookForView SetItem()
        {
            List<BookStoreApi.Genre> bookGenresToSet = new List<BookStoreApi.Genre>();
            if (genreDataStore.items.Contains(SelectedGenre))
            {
                bookGenresToSet.Add(genreDataStore.items.Where(x => x.Id == SelectedGenre.Id).First());
            }

            return new BookForView
            {
                CretionDate = CreationDate,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Id = Id,
                Title = Title,
                Description = Description,
                PublishingHouse = PublishingHouse,
                Price = Price,
                IdCategory = selectedCategory.Id,
                CategoryName = selectedCategory.Name,
                IdAuthor = selectedAuthor.Id,
                AuthorName = string.IsNullOrEmpty(selectedAuthor.Nickname) ? $"{selectedAuthor.Name} {selectedAuthor.Surname}" : selectedAuthor.Nickname,
                BookGenres = bookGenresToSet,
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(title)
                && price > 0;
        }
    }
}
