using BookStore.ViewModels.Abstract;
using BookStore.Views.Genre;
using Xamarin.Forms;

namespace BookStore.ViewModels.Genre
{
    public class DetailsGenreViewModel : AItemDetailsViewModel<BookStoreApi.Genre>
    {
        #region Fields
        private int id;
        private string name;
        private string description;
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
        #endregion

        public DetailsGenreViewModel()
            : base()
        {
        }

        public override void LoadProperties(BookStoreApi.Genre item)
        {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
        }

        public async override void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(EditGenrePage)}?{nameof(EditGenreViewModel.ItemId)}={Id}");
        }
    }
}
