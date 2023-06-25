using BookStore.ViewModels.Abstract;
using System;

namespace BookStore.ViewModels.Genre
{
    public class EditGenreViewModel : AEditItemViewModel<BookStoreApi.Genre>
    {
        public EditGenreViewModel()
            : base()
        {
        }

        #region Fields
        private int id;
        private string name;
        private string description;
        private DateTime creationDate;
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public DateTime CreationDate
        {
            get => creationDate;
            set => SetProperty(ref creationDate, value);
        }
        #endregion

        public override void LoadProperties(BookStoreApi.Genre item)
        {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
            CreationDate = DateTime.Parse(item.CretionDate.ToString());
        }

        public override BookStoreApi.Genre SetItem()
        {
            return new BookStoreApi.Genre
            {
                CretionDate = CreationDate == new DateTime() ? DateTime.Now : CreationDate,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Id = Id,
                Name = Name,
                Description = Description
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(name);
        }
    }
}
