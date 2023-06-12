using BookStore.ViewModels.Abstract;
using BookStore.ViewModels.Book;
using BookStore.Views.Category;
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
            await Shell.Current.GoToAsync($"{nameof(DetailsCategoryPage)}?{nameof(DetailsCategoryViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(NewCategoryPage));
        }
    }
}
