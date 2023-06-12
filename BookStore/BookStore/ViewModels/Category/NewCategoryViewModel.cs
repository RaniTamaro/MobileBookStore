using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;

namespace BookStore.ViewModels.Category
{
    public class NewCategoryViewModel : ANewViewModel<CategoryForView>
    {
        public NewCategoryViewModel()
            : base()
        {
        }

        #region Fields
        private string name;
        private string description;
        #endregion

        #region Properties
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
        #endregion

        public override CategoryForView SetItem()
        {
            return new CategoryForView
            {
                CretionDate = DateTime.Now,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Name = this.Name,
                Description = this.Description
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(name);
        }
    }
}
