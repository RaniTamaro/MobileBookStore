using BookStore.ViewModels.Abstract;
using BookStoreApi;
using Xamarin.Forms;

namespace BookStore.ViewModels.Category
{
    public class CategoryViewModel : AListViewModel<CategoryForView>
    {
        public CategoryViewModel()
            : base("Kategorie")
        {
        }

        public async override void OnItemSelected(CategoryForView item)
        {
            if (item == null)
                return;
            await Shell.Current.DisplayAlert("Wybrana kategoria", item.Name, "Anuluj");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewCategoryPage));
        }
    }
}
