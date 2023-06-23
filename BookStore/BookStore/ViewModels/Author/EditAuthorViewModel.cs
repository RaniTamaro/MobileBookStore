using BookStore.ViewModels.Abstract;
using BookStoreApi;
using System;

namespace BookStore.ViewModels.Author
{
    public class EditAuthorViewModel : AEditItemViewModel<AuthorForView>
    {
        public EditAuthorViewModel()
            : base()
        {
        }

        #region Fields
        private int id;
        private string name;
        private string surname;
        private string nickname;
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

        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }

        public string Nickname
        {
            get => nickname;
            set => SetProperty(ref nickname, value);
        }

        public DateTime CreationDate
        {
            get => creationDate;
            set => SetProperty(ref creationDate, value);
        }
        #endregion

        public override AuthorForView SetItem()
        {
            return new AuthorForView
            {
                CretionDate = CreationDate,
                MmodifDate = DateTime.Now,
                IsActive = true,
                Id = Id,
                Name = Name,
                Surname = Surname,
                Nickname = Nickname,
            };
        }

        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(Surname)
                || !string.IsNullOrEmpty(nickname);
        }

        public override async void LoadProperties(AuthorForView item)
        {
            Id = item.Id;
            Name = item.Name;
            Surname = item.Surname;
            Nickname = item.Nickname;
            CreationDate = DateTime.Parse(item.CretionDate.ToString());
        }
    }
}
