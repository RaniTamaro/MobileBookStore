﻿using BookStore.Services;
using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookStore.ViewModels.Book
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class NewBookViewModel : ANewViewModel<BookForView>
    {
        public NewBookViewModel()
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

            selectedCategory = new CategoryForView();
            selectedAuthor = new AuthorForView();
        }

        #region Fields
        private int? itemId;
        private readonly GenreDataStore genreDataStore;
        private readonly CategoryDataStore categoryDataStore;
        private readonly AuthorDataStore authorDataStore;
        private string title;
        private string description = "";
        private string publishingHouse = "";
        private double price = 0;
        private CategoryForView selectedCategory;
        private AuthorForView selectedAuthor;
        private IList<object> selectedGenres;
        private List<BookStoreApi.Genre> genres;
        private List<CategoryForView> categories;
        private List<AuthorForView> authors;
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

        public IList<object> SelectedGenres
        {
            get { return selectedGenres; }
            set
            {
                selectedGenres = value;
                OnPropertyChanged(nameof(SelectedGenres));
            }
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

        public int? ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
            }
        }

        public ICommand ItemSelectedCommand { get; }
        #endregion

        public override BookForView SetItem()
        {
            List<BookStoreApi.Genre> bookGenresToSet = new List<BookStoreApi.Genre>();
            foreach (BookStoreApi.Genre genre in SelectedGenres.ToList())
            {
                if (genreDataStore.items.Contains(genre))
                {
                    bookGenresToSet.Add(genreDataStore.items.Where(x => x.Id == genre.Id).First());
                }
            }

            return new BookForView
            {
                CretionDate = DateTime.Now,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Title = Title,
                Description = Description,
                PublishingHouse = PublishingHouse,
                Price = Price,
                IdCategory = selectedCategory.Id,
                CategoryName = selectedCategory.Name,
                IdAuthor = ItemId ?? selectedAuthor.Id,
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
