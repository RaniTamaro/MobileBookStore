using BookStore.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookStore.ViewModels.Genre
{
    public class DetailsGenreViewModel : AItemDetailsViewModel<BookStoreApi.Genre>
    {
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

        public DetailsGenreViewModel()
            : base()
        {
        }

        public override void LoadProperties(BookStoreApi.Genre item)
        {
            Name = item.Name;
            Description = item.Description;
        }
    }
}
