using BookStore.ViewModels.Abstract;
using System;

namespace BookStore.ViewModels.Genre
{
    public class NewGenrePage : ANewViewModel<BookStoreApi.Genre>
    {
        public NewGenrePage()
            : base()
        {
        }

        #region Fields
        private string name = "";
        private string description = "";
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

        public override BookStoreApi.Genre SetItem()
        {
            return new BookStoreApi.Genre
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
