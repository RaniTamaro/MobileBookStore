using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;

namespace BookStore.ViewModels.Category
{
    public class EditCategoryViewModel : AEditItemViewModel<CategoryForView>
    {
        public EditCategoryViewModel()
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

        public override void LoadProperties(CategoryForView item)
        {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
            CreationDate = DateTime.Parse(item.CretionDate.ToString());
        }

        public override CategoryForView SetItem()
        {
            return new CategoryForView
            {
                CretionDate = CreationDate == new DateTime() ? DateTime.Now : CreationDate,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Id = Id,
                Name = Name,
                Description = Description
            }; ;
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(name);
        }
    }
}
